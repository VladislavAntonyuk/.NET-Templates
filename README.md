# .NET Templates

[![Buy Me A Coffee](https://ik.imagekit.io/VladislavAntonyuk/vladislavantonyuk/misc/bmc-button.png)](https://www.buymeacoffee.com/vlad.antonyuk)

[![Stand With Ukraine](https://img.shields.io/badge/made_in-ukraine-ffd700.svg?labelColor=0057b7)](https://stand-with-ukraine.pp.ua)

[![NuGet Version](https://img.shields.io/nuget/v/VladislavAntonyuk.DotNetTemplates?color=blue&style=flat-square&logo=nuget)](https://www.nuget.org/packages/VladislavAntonyuk.DotNetTemplates)
[![NuGet Downloads](https://img.shields.io/nuget/dt/VladislavAntonyuk.DotNetTemplates.svg?style=flat-square)](https://www.nuget.org/packages/VladislavAntonyuk.DotNetTemplates)

Table of contents:
* [BlazorMauiShared](#blazor-maui-shared)
* [Onion Architecture Templates](#onion-architecture-templates)
  + [Onion Architecture Cross-Platform Application](#onion-architecture-cross-platform-application)
  + [Onion Architecture Cross-Platform Application Repository](#onion-architecture-cross-platform-application-repository)
  + [Onion Architecture Blazor Application](#onion-architecture-blazor-application)
  + [Onion Architecture Blazor Application Repository](#onion-architecture-blazor-application-repository)
  + [Onion Architecture Blazor WebAssembly Application](#onion-architecture-blazor-webassembly-application)
  + [Onion Architecture .NET MAUI Application](#onion-architecture-net-maui-application)
  + [Onion Architecture .NET MAUI Application Repository](#onion-architecture-net-maui-application-repository)
* [iOS Extensions for .NET MAUI Application](#ios-extensions-for-net-maui-application)
  + [Action Extension](#action-extension)
  + [Audio Unit Extension](#audio-unit-extension)
  + [Broadcast UI Extension](#broadcast-ui-extension)
  + [Broadcast Upload Extension](#broadcast-upload-extension)
  + [CallDirectory Extension](#calldirectory-extension)
  + [Content Blocker Extension](#content-blocker-extension)
  + [Custom Keyboard Extension](#custom-keyboard-extension)
  + [Document Picker Extension](#document-picker-extension)
  + [Document Picker File Provider Extension](#document-picker-file-provider-extension)
  + [iMessage Extension](#imessage-extension)
  + [Intents Extension](#intents-extension)
  + [Intents UI Extension](#intents-ui-extension)
  + [Notification Content Extension](#notification-content-extension)
  + [Notification Service Extension](#notification-service-extension)
  + [Photo Editing Extension](#photo-editing-extension)
  + [Shared Links Extension](#shared-links-extension)
  + [Share Extension](#share-extension)
  + [Spotlight Index Extension](#spotlight-index-extension)
  + [Today Extension](#today-extension)
* [Build](#build)
* [Install Templates](#install-templates)
* [Uninstall](#uninstall)

[<a href='http://ecotrust-canada.github.io/markdown-toc/'>Table of contents generated with markdown-toc</a>]: <>

## BlazorMauiShared

Creates .NET MAUI application, Blazor Server and Blazor WebAssembly projects with shared UI.

Create solution:

```pwsh
dotnet new blazor-maui-shared -n MyProductName --ApplicationId com.vladislavantonyuk.myapp
```

## Onion Architecture Templates

### Onion Architecture Cross-Platform Application

Cross-platform application (Blazor Server WebApp + .NET MAUI) with onion architecture.

Create solution:

```pwsh
dotnet new onion-app -n MyProductName --entityName MyEntityName

### Onion Architecture Cross-Platform Application Repository

Cross-platform application (Blazor Server WebApp + .NET MAUI) with onion architecture, using Repository pattern.

Create solution:

```pwsh
dotnet new onion-app-repository -n MyProductName --entityName MyEntityName
```

### Onion Architecture Blazor Application

Blazor application with onion architecture.

Create solution:

```pwsh
dotnet new onion-blazor -n MyProductName --entityName MyEntityName
```

### Onion Architecture Blazor Application Repository

Blazor application with onion architecture, using Repository pattern.

Create solution:

```pwsh
dotnet new onion-blazor-repository -n MyProductName --entityName MyEntityName
```

### Onion Architecture Blazor WebAssembly Application

Blazor WebAssembly application with onion architecture.

Create solution:

```pwsh
dotnet new onion-blazor-webassembly -n MyProductName --entityName MyEntityName
```

### Onion Architecture .NET MAUI Application

.NET MAUI application with onion architecture.

Create solution:

```pwsh
dotnet new onion-maui -n MyProductName --entityName MyEntityName
```

### Onion Architecture .NET MAUI Application Repository

.NET MAUI application with onion architecture, using Repository pattern.

Create solution:

```pwsh
dotnet new onion-maui-repository -n MyProductName --entityName MyEntityName
```

## iOS Extensions for .NET MAUI Application

### Action Extension

iOS Action Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-action-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-ActionExtension`.

### Audio Unit Extension

iOS Audio Unit Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-audio-unit-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-AudioUnitExtension`.

### Broadcast UI Extension

iOS Broadcast UI Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-broadcast-ui-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-BroadcastUIExtension`.

### Broadcast Upload Extension

iOS Broadcast Upload Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-broadcast-upload-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-BroadcastUploadExtension`.

### CallDirectory Extension

iOS Call Directory Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-call-directory-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-CallDirectoryExtension`.

### Content Blocker Extension

iOS Content Blocker Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-content-blocker-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-ContentBlockerExtension`.

### Custom Keyboard Extension

iOS Custom Keyboard Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-custom-keyboard-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-CustomKeyboardExtension`.

### Document Picker Extension

iOS Document Picker Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-document-picker-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-DocumentPickerExtension`.

### Document Picker File Provider Extension

iOS Document Picker File Provider Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-document-picker-file-provider-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-DocumentPickerFileProviderExtension`.

### iMessage Extension

iOS iMessage Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-imessage-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-IMessageExtension`.

### Intents Extension

iOS Intents Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-intents-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-IntentsExtension`.

### Intents UI Extension

iOS Intents UI Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-intents-ui-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-IntentsUIExtension`.

### Notification Content Extension

iOS Notification Content Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-notification-content-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-NotificationContentExtension`.

### Notification Service Extension

iOS Notification Service Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-notification-service-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-NotificationServiceExtension`.

### Photo Editing Extension

iOS Photo Editing Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-photo-editing-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-PhotoEditingExtension`.

### Shared Links Extension

iOS Shared Links Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-shared-links-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-SharedLinksExtension`.

### Share Extension

iOS Share Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-share-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-ShareExtension`.

### Spotlight Index Extension

iOS Spotlight Index Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-spotlight-index-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-SpotlightIndexExtension`.

### Today Extension

iOS Today Extension for .NET MAUI application.

Create project:

```pwsh
dotnet new ios-today-extension -n MyProjectName --applicationId com.vladislavantonyuk.myapp.myapp
```

The final application id: `com.vladislavantonyuk.myapp.myapp-TodayExtension`.

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

[![Buy Me A Coffee](https://ik.imagekit.io/VladislavAntonyuk/vladislavantonyuk/misc/bmc-button.png)](https://www.buymeacoffee.com/vlad.antonyuk)

[![Stand With Ukraine](https://img.shields.io/badge/made_in-ukraine-ffd700.svg?labelColor=0057b7)](https://stand-with-ukraine.pp.ua)