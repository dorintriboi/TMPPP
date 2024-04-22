using Core.Services.CompanyEvent.Common.ObserverPattern.Observers.Interfaces;
using Core.Services.CompanyEvent.Common.ObserverPattern.Subjects.Interfaces;

namespace Core.Services.CompanyEvent.Common.ObserverPattern.Subjects;

public class EventSubject : ISubject
{
    private ICollection<IObserver> _observers;
    
    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.SendEmail(observer.Email);
        }
    }
}