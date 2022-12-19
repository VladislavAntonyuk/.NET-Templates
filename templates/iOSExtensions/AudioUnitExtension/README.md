Add the next code to your app project:

```xml
<ItemGroup>
    <ProjectReference Include="..\App1\App1.csproj">
        <IsAppExtension>true</IsAppExtension>
        <IsWatchApp>false</IsWatchApp>
    </ProjectReference>
</ItemGroup>
```