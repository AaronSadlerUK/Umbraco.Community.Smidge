# Umbraco.Community.Smidge

## Overview

This project restores the `RuntimeMinifier` functionality to Umbraco v16.1.1+, powered by [Smidge](https://github.com/Shazwazza/Smidge). The `RuntimeMinifier` was removed in Umbraco v14, and this package reintroduces it for developers who need runtime minification of CSS and JavaScript assets.

## Features
- Runtime minification of CSS and JavaScript using Smidge
- Easy integration with Umbraco v16.1.1+
- Configuration options for bundling and cache busting

## Installation

1. Add the NuGet package to your Umbraco project:
   ```shell
   dotnet add package Umbraco.Community.Smidge
   ```
2. Ensure your project is running Umbraco v16.1.1 or later.

## Usage

1. Add `.AddRuntimeMinifier()` to your UmbracoBuilder:
   ```csharp
   // In your Startup or Program.cs
    builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .AddRuntimeMinifier()
    .Build();
   ```

   And add `app.UseSmidge();`

2. Use the `IRuntimeMinifier` interface to minify assets at runtime.

#### Example

```csharp
// Example usage in a notification handler
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services;
using Umbraco.Community.Smidge;

public class CreateBundlesNotificationHandler : INotificationHandler<UmbracoApplicationStartingNotification>
{
    private readonly IRuntimeMinifier _runtimeMinifier;
    private readonly IRuntimeState _runtimeState;

    public CreateBundlesNotificationHandler(IRuntimeMinifier runtimeMinifier, IRuntimeState runtimeState)
    {
        _runtimeMinifier = runtimeMinifier;
        _runtimeState = runtimeState;
    }
    public void Handle(UmbracoApplicationStartingNotification notification)
    {
        if (_runtimeState.Level == RuntimeLevel.Run)
        {
            _runtimeMinifier.CreateJsBundle("core-javascript-bundle",
                BundlingOptions.OptimizedNotComposite,
                ["~/scripts/main.min.js"]);

            _runtimeMinifier.CreateCssBundle("core-style-bundle",
                BundlingOptions.OptimizedNotComposite,
                ["~/css/bootstrap.min.css", "~/css/main.min.css"]);
        }
    }
}
```

## Configuration

- You can customize bundling and cache busting via the provided options classes (`BundlingOptions`, `RuntimeMinificationSettings`, etc.).
- Refer to the source files for advanced configuration.

## Contributing

Contributions are welcome! Please submit issues or pull requests via GitHub.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

## Credits

- [Smidge](https://github.com/Shazwazza/Smidge) by Shannon Deminick
- Umbraco Community

---

For more information, see the source code and comments in this repository.
