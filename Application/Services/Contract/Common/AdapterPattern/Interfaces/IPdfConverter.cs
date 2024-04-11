namespace Core.Services.Contract.Common.AdapterPattern.Interfaces;

public interface IPdfConverter
{
    public Task<string> ConvertToPdf(Stream base64);
}