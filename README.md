# .NET-Templates

## Build 

```pwsh
dotnet pack
```

## Install Templates

From NuGet:

```pwsh
dotnet new -i VladislavAntonyuk.DotNetTemplates
```

From file:

```pwsh
dotnet new -i VladislavAntonyuk.DotNetTemplates.1.0.0.nupkg
```

## Uninstall

```pwsh
dotnet new -u VladislavAntonyuk.DotNetTemplates
```

## Templates

### OnionArchitectureCrossPlatformApplication

Cross-platform application (Blazor Server WebApp + .NET MAUI) with onion archirecture.

#### Create project

```pwsh
dotnet new onionapp -n MyProjectName --entityName MyEntityName
```

