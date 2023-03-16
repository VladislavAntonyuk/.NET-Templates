dotnet tool install --global dotnet-outdated-tool;
Get-ChildItem -Recurse -Include *.csproj | ForEach-Object {
  Write-Output $_.FullName
  dotnet outdated $_.FullName -u
}
