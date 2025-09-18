Get-ChildItem -Path .\ -Filter *.sln -Recurse | ForEach-Object {
    Write-Host $_.FullName
    dotnet build $_.FullName
    $status = $LASTEXITCODE
    if ($status -eq 0) {
        Write-Host "No errors found"
    }
    else {
        exit $status
    }
}

Get-ChildItem -Path .\iOSExtensions -Filter *.csproj -Recurse | ForEach-Object {
    Write-Host $_.FullName
    dotnet build $_.FullName
    $status = $LASTEXITCODE
    if ($status -eq 0) {
        Write-Host "No errors found"
    }
    else {
        exit $status
    }
}