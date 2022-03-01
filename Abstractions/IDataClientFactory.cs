namespace Abstractions;

public interface IDataClientFactory<T>
{
    T GetClient();
}
