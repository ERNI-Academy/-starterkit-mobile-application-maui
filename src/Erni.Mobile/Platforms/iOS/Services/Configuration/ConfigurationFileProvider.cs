using Erni.Mobile.Services.Configuration;

namespace Erni.Mobile.Platforms;

internal class ConfigurationFileProvider : IConfigurationFileProvider
{
    public Stream GetConfigurationStream()
    {
        return FileSystem.OpenAppPackageFileAsync("appsettings.json").GetAwaiter().GetResult();
    }
}
