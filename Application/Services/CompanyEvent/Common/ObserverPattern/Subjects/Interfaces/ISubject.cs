using Core.Services.CompanyEvent.Common.ObserverPattern.Observers.Interfaces;

namespace Core.Services.CompanyEvent.Common.ObserverPattern.Subjects.Interfaces;

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}