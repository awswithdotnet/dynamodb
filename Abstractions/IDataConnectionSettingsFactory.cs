namespace Abstractions;

public interface IDataConnectionSettingsFactory<T>
{
    T GetSettings();
}
