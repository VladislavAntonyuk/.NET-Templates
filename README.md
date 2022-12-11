# .NET-Templates

[![Buy Me A Coffee](https://ik.imagekit.io/VladislavAntonyuk/vladislavantonyuk/misc/bmc-button.png)](https://www.buymeacoffee.com/vlad.antonyuk)

[![Stand With Ukraine](https://img.shields.io/badge/made_in-ukraine-ffd700.svg?labelColor=0057b7)](https://stand-with-ukraine.pp.ua)

[![NuGet](https://img.shields.io/nuget/v/VladislavAntonyuk.DotNetTemplates?color=blue&style=flat-square&logo=nuget)](https://www.nuget.org/packages/VladislavAntonyuk.DotNetTemplates)
[![NuGet](https://img.shields.io/nuget/dt/VladislavAntonyuk.DotNetTemplates.svg?style=flat-square)](https://www.nuget.org/packages/VladislavAntonyuk.DotNetTemplates)


## Templates

### Onion Architecture Cross-Platform Application

Cross-platform application (Blazor Server WebApp + .NET MAUI) with onion archirecture.

#### Create project

```pwsh
dotnet new onion-app -n MyProjectName --entityName MyEntityName
```

### Onion Architecture Blazor Server Application

Blazor Server application with onion archirecture.

#### Create project

```pwsh
dotnet new onion-blazor-server -n MyProjectName --entityName MyEntityName
```

### Onion Architecture Blazor WebAssembly Application

Blazor WebAssembly application with onion archirecture.

#### Create project

```pwsh
dotnet new onion-blazor-webassembly -n MyProjectName --entityName MyEntityName
```

### Onion Architecture .NET MAUI Application

.NET MAUI application with onion archirecture.

#### Create project

```pwsh
dotnet new onion-maui -n MyProjectName --entityName MyEntityName
```

### iOS Share Extension for .NET MAUI Application

iOS Share Extension for .NET MAUI application.

#### Create project

```pwsh
dotnet new ios-share-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp-Share
```

## Build 

```pwsh
dotnet pack
```

## Install Templates

From NuGet:

```pwsh
dotnet new install VladislavAntonyuk.DotNetTemplates
```

From file:

```pwsh
dotnet new install VladislavAntonyuk.DotNetTemplates.2.0.0.nupkg
```

## Uninstall

```pwsh
dotnet new uninstall VladislavAntonyuk.DotNetTemplates
```

[![Stand With Ukraine](https://img.shields.io/badge/made_in-ukraine-ffd700.svg?labelColor=0057b7)](https://stand-with-ukraine.pp.ua)