dotnet dev-certs https --trust
cd ../panel
xcopy "dist/spa" "C:/Projects/Publish/Panel" /e /h /c /i
cd ..
cd api-service
dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained false -o C:/Projects/Publish/Api
cd ..
cd cdn-service
dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained false -o C:/Projects/Publish/Cdn
cd ..
cd core-service
dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained false -o C:/Projects/Publish/Core
cd ..
cd flow-service
dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained false -o C:/Projects/Publish/Flow
cd ..
cd identity-service
dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained false -o C:/Projects/Publish/Identity
xcopy "Certificate" "C:/Projects/Publish/Identity/Certificate" /i
cd ..
cd tenant-service
dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained false -o C:/Projects/Publish/Tenant
cd ..
xcopy "release_bats" "C:/Projects/Publish" /e /h /c /i
cd C:/Projects/Publish/Panel
npm i