dotnet tool install --global dotnet-outdated-tool;
for f in $(find ./ -name '*.csproj'); do 
  echo $f;
  dotnet outdated $f -u;
done