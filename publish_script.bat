cd ProgramExec
dotnet clean
dotnet publish -r win-x64 --self-contained false -p:PublishSingleFile=true -p:DebugType=embedded -p:PublishTrimmed=false -p:PublishReadyToRun=false
dotnet publish -r osx-x64 --self-contained false -p:PublishSingleFile=true -p:DebugType=embedded -p:PublishTrimmed=false -p:PublishReadyToRun=false
dotnet publish -r linux-x64 --self-contained false -p:PublishSingleFile=true -p:DebugType=embedded -p:PublishTrimmed=false -p:PublishReadyToRun=false