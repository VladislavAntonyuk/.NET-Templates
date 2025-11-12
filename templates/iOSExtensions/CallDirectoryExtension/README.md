# Call Directory Extension

## Setup

Add the next code to your app project:

```xml
<ItemGroup>
    <ProjectReference Include="..\App1\App1.csproj">
        <IsAppExtension>true</IsAppExtension>
        <IsWatchApp>false</IsWatchApp>
    </ProjectReference>
</ItemGroup>
```

## Important Requirements

### App Groups
Call Directory extensions require App Groups to share data between the main app and the extension. Make sure to:
1. Enable App Groups capability in both the main app and the extension
2. Use the same App Group identifier in both targets
3. Configure the App Group in Apple Developer Portal with proper provisioning profiles

### Performance Considerations
Call Directory extensions have strict performance requirements:
- Extensions must complete quickly (typically under 10 seconds)
- When adding many phone numbers (thousands+), use incremental loading
- Phone numbers must be provided in numerically ascending order
- Consider using autorelease pools when loading large datasets

### Testing
To test your Call Directory extension:
1. Install the app on a physical device (Call Directory extensions don't work in simulator)
2. Go to Settings > Phone > Call Blocking & Identification
3. Enable your extension
4. Check the extension logs in Xcode Console if the extension fails to activate

### Common Issues
- **Extension immediately deactivates**: Check that App Groups are properly configured with matching identifiers
- **Numbers not blocking**: Ensure phone numbers are in correct E.164 format (e.g., 14085551234 for US numbers) and sorted in ascending order
- **Extension times out**: Extensions must complete within 10-30 seconds. For large datasets (>10,000 numbers), implement incremental loading with autorelease pools