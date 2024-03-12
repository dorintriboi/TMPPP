namespace Proiect_Teatru.Models.Interfaces.In;

public interface IRequest<T>
{
    T Convert();
}