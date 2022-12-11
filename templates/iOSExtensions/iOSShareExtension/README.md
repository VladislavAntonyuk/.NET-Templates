Add the next code to your app project:

```xml
<ItemGroup>
    <ProjectReference Include="..\AppContainerExtension\AppContainerExtension.csproj">
        <IsAppExtension>true</IsAppExtension>
        <IsWatchApp>false</IsWatchApp>
    </ProjectReference>
</ItemGroup>
```