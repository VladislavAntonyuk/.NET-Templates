Add the next code to your app project:

```xml
<ItemGroup>
    <ProjectReference Include="..\App1\App1.csproj">
        <IsAppExtension>true</IsAppExtension>
    </ProjectReference>
    <ProjectReference Include="..\App1UI\App1UI.csproj">
        <IsAppExtension>true</IsAppExtension>
    </ProjectReference>
</ItemGroup>
```