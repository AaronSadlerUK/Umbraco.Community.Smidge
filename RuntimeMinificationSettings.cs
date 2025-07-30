using System.ComponentModel;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Configuration.Models;

namespace Umbraco.Community.Smidge;

[UmbracoOptions("smidge")]
public class RuntimeMinificationSettings
{
    internal const bool StaticUseInMemoryCache = false;
    internal const string StaticCacheBuster = "Version";
    internal const string? StaticVersion = null;

    /// <summary>
    ///     Use in memory cache
    /// </summary>
    [DefaultValue(StaticUseInMemoryCache)]
    public bool UseInMemoryCache { get; set; } = StaticUseInMemoryCache;

    /// <summary>
    ///     The cache buster type to use
    /// </summary>
    [DefaultValue(StaticCacheBuster)]
    public RuntimeMinificationCacheBuster CacheBuster { get; set; } = Enum.Parse<RuntimeMinificationCacheBuster>(StaticCacheBuster);

    /// <summary>
    ///     The unique version string used if CacheBuster is 'Version'.
    /// </summary>
    [DefaultValue(StaticVersion)]
    public string? Version { get; set; } = StaticVersion;
}