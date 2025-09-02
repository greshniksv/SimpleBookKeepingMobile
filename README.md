
# Migration
dotnet ef migrations add AddFree --project SimpleBookKeepingMobile --framework net9.0-windows10.0.19041.0

# Build project
dotnet publish -f:net9.0-android -c Release -o ./publish /p:AndroidPackageFormat=apk