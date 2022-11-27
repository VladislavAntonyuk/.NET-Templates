# .NET-Templates

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

## Templates

### Onion Architecture Cross-Platform Application

Cross-platform application (Blazor Server WebApp + .NET MAUI) with onion archirecture.

#### Create project

```pwsh
dotnet new onion-app -n MyProjectName --entityName MyEntityName
```

### Onion Architecture Blazor Application

Blazor Server application with onion archirecture.

#### Create project

```pwsh
dotnet new onion-blazor-server -n MyProjectName --entityName MyEntityName
```

### Onion Architecture .NET MAUI Application

.NET MAUI application with onion archirecture.

#### Create project

```pwsh
dotnet new onion-maui -n MyProjectName --entityName MyEntityName
```


### iOS Extension for .NET MAUI Application

iOS Extension for .NET MAUI application.

#### Create project

```pwsh
dotnet new ios-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp-Share
```
