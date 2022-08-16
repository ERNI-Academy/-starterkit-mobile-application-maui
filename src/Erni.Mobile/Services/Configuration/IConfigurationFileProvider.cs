namespace Erni.Mobile.Services.Configuration;

public interface IConfigurationFileProvider
{
    Stream GetConfigurationStream();
}
