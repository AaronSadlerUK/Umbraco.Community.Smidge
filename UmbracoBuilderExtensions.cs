using Microsoft.Extensions.DependencyInjection;
using Smidge;
using Smidge.Cache;
using Smidge.FileProcessors;
using Smidge.InMemory;
using Smidge.Nuglify;
using Smidge.Options;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Extensions;

namespace Umbraco.Community.Smidge
{
    public static class UmbracoBuilderExtensions
    {
        /// <summary>
        ///     Add runtime minifier support for Umbraco
        /// </summary>
        public static IUmbracoBuilder AddRuntimeMinifier(this IUmbracoBuilder builder)
        {
            builder.Services.AddUnique<ICacheBuster, UmbracoSmidgeConfigCacheBuster>();
            builder.Services.AddSmidge(builder.Config.GetSection("smidge"));

            builder.Services.AddSmidgeNuglify();
            builder.Services.AddSmidgeInMemory(false); // it will be enabled based on config/cachebuster

            builder.Services.AddUnique<IRuntimeMinifier, SmidgeRuntimeMinifier>();
            builder.Services.AddSingleton<SmidgeHelperAccessor>();
            builder.Services.AddTransient<IPreProcessor, SmidgeNuglifyJs>();
            builder.Services.ConfigureOptions<SmidgeOptionsSetup>();

            return builder;
        }
    }
}
