using System.Web.Mvc;
using System.Web.Configuration;
namespace OnlineGame.Web.WebShared
{
    public class CustomizeCacheAttribute : OutputCacheAttribute
    {
        public CustomizeCacheAttribute(string cacheProfileName)
        {
            OutputCacheSettingsSection cacheSettings =
                (OutputCacheSettingsSection)WebConfigurationManager
                .GetSection("system.web/caching/outputCacheSettings");
            OutputCacheProfile cacheProfile = cacheSettings.OutputCacheProfiles[cacheProfileName];
            Duration = cacheProfile.Duration;
            VaryByParam = cacheProfile.VaryByParam;
            VaryByCustom = cacheProfile.VaryByCustom;
        }
    }
}