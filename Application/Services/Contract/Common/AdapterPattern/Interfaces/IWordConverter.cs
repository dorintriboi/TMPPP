namespace Core.Services.Contract.Common.AdapterPattern.Interfaces;

public interface IWordConverter
{
    public Task<string> ConvertToWord(Stream base64);
}