using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using Core.Services.Contract.Common.AdapterPattern.Interfaces;
using HtmlAgilityPack;
using DocumentFormat.OpenXml.Packaging;
using OpenXmlPowerTools;

namespace Core.Services.Contract.Common.AdapterPattern;

public class WordConverter : IWordConverter
{
    public async Task<string> ConvertToWord(Stream base64)
    {
        return Convert(base64);
    }

    public string Convert(Stream stream)
    {
        var byteArray = ReadFully(stream);
        var html = ConvertToHtml(byteArray);
        var fixedHtml = FixImages(html);
        return fixedHtml;
    }

    private static byte[] ReadFully(Stream input)
    {
        var buffer = new byte[16 * 1024];
        using var ms = new MemoryStream();
        int read;
        while ((read = input.Read(buffer, 0, buffer.Length)) > 0) ms.Write(buffer, 0, read);
        return ms.ToArray();
    }

    private static string ConvertToHtml(byte[] byteArray)
    {
        using var memoryStream = new MemoryStream();
        memoryStream.Write(byteArray, 0, byteArray.Length);
        using var wDoc = WordprocessingDocument.Open(memoryStream, true);
        var settings = new WmlToHtmlConverterSettings
        {
            PageTitle = "",
            FabricateCssClasses = true,
            CssClassPrefix = "pt-",
            RestrictToSupportedLanguages = false,
            RestrictToSupportedNumberingFormats = false,
            ImageHandler = imageInfo =>
            {
                var extension = imageInfo.ContentType.Split('/')[1].ToLower();
                var imageFormat = extension switch
                {
                    "png" => ImageFormat.Png,
                    "gif" => ImageFormat.Gif,
                    "bmp" => ImageFormat.Bmp,
                    "jpeg" => ImageFormat.Jpeg,
                    "tiff" => ImageFormat.Gif,
                    "x-wmf" => ImageFormat.Wmf,
                    _ => null
                };

                // If the image format isn't one that we expect, ignore it,
                // and don't return markup for the link.
                if (imageFormat == null)
                    return null;

                string base64;
                try
                {
                    using var ms = new MemoryStream();
                    imageInfo.Bitmap.Save(ms, imageFormat);
                    var ba = ms.ToArray();
                    base64 = System.Convert.ToBase64String(ba);
                }
                catch (ExternalException)
                {
                    return null;
                }

                var format = imageInfo.Bitmap.RawFormat;
                var codec = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == format.Guid);
                var mimeType = codec.MimeType;

                var imageSource = $"data:{mimeType};base64,{base64}";

                var img = new XElement(Xhtml.img,
                    new XAttribute(NoNamespace.src, imageSource),
                    imageInfo.ImgStyleAttribute,
                    imageInfo.AltText != null ? new XAttribute(NoNamespace.alt, imageInfo.AltText) : null);
                return img;
            }
        };
        var htmlElement = WmlToHtmlConverter.ConvertToHtml(wDoc, settings);
        var html = new XDocument(new XDocumentType("html", null, null, null), htmlElement);
        return html.ToString().Replace("\n", "");
    }

    private static string FixImages(string convertedHtml)
    {
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(convertedHtml);
        var imageSpanNodes = htmlDoc.DocumentNode.SelectNodes("//span/img");

        if (imageSpanNodes == null)
            return convertedHtml;


        foreach (var imgNode in imageSpanNodes)
        {
            var spanParent = imgNode.ParentNode;
            var mainParent = spanParent.ParentNode;
            mainParent.ReplaceChild(imgNode, spanParent);
        }

        using var writer = new StringWriter();
        htmlDoc.Save(writer);
        var result = writer.ToString();

        return result;
    }
}