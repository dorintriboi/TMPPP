namespace Core.Services.CompanyEvent.Common.ObserverPattern.Observers.Interfaces;

public interface IObserver
{
    string Email { get; set; }
    Task SendEmail(string email);
}