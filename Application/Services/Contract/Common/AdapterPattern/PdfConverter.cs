using System.Text;
using Core.Services.Contract.Common.AdapterPattern.Interfaces;
using PuppeteerSharp;
using PuppeteerSharp.Media;

namespace Core.Services.Contract.Common.AdapterPattern;

public class PdfConverter : IPdfConverter
{
    private readonly PdfOptions _pdfOptions = new()
    {
        PrintBackground = true,
        Format = PaperFormat.A4
    };
    private readonly LaunchOptions _launchOptions = new()
    {
        Headless = true,
    };

    public async Task<string> ConvertToPdf(Stream base64)
    {
        var htmlContent = ConvertStreamToStringAsync(base64, default).Result;
        var browser = NewBrowserAsync().Result;
        
        var page = browser.NewPageAsync().Result;
        page.SetContentAsync(htmlContent).GetAwaiter().GetResult();
        
        var pdfResultBytes = page.PdfDataAsync(_pdfOptions).Result;
        var pdfResultString = System.Convert.ToBase64String(pdfResultBytes);
        
        browser.CloseAsync().GetAwaiter().GetResult();
        
        return pdfResultString;
    }
    
    private async Task<IBrowser> NewBrowserAsync()
    {
        var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync();
        var browser = await Puppeteer.LaunchAsync(_launchOptions);
        return browser;
    }
    
    private static async Task<string> ConvertStreamToStringAsync(Stream stream, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(stream, Encoding.UTF8);
        var result = await reader.ReadToEndAsync(cancellationToken);
        return result;
    }
}