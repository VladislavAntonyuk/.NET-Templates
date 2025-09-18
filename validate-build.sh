for f in $(find ./ -name '*.sln'); do 
  echo $f;
  dotnet build $f;
  status=$?
  [ $status -eq 0 ] && echo "No errors found" || exit $status
done

for f in $(find ./iOSExtensions -name '*.csproj'); do 
  echo $f;
  dotnet build $f;
  status=$?
  [ $status -eq 0 ] && echo "No errors found" || exit $status
done