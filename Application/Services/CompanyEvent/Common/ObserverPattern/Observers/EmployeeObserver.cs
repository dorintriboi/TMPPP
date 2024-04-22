using Core.Services.CompanyEvent.Common.ObserverPattern.Observers.Interfaces;

namespace Core.Services.CompanyEvent.Common.ObserverPattern.Observers;

public class EmployeeObserver : IObserver
{
    public string Email { get; set; }
    public Task SendEmail(string email)
    {
        throw new NotImplementedException();
    }
}