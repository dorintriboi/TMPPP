using Core.Services.Contract.Common.AdapterPattern.Interfaces;

namespace Core.Services.Contract.Common.AdapterPattern;

public class PdfAdapter(IPdfConverter pdfConverter) : IWordConverter
{
    public async Task<string> ConvertToWord(Stream base64)
    {
         return await pdfConverter.ConvertToPdf(base64);
    }
}