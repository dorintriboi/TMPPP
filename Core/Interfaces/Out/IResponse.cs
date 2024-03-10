namespace Core.Interfaces.Out;

public interface IResponse<T, TT>
{
    static abstract IResponse<T, TT> Convert(TT entity);
}