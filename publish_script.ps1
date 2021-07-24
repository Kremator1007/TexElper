function publishRuntime {
	param(
		$runtime
	)
	buildRuntime -runtime $runtime
	copyRuntimeIntoAppropriateFolde $runtime
}
	
function buildRuntime {
	param(
		$runtime
	)
	$publishCommand = "dotnet publish ProgramExec/ -r $runtime --self-contained false -p:PublishSingleFile=true -p:DebugType=embedded -p:PublishTrimmed=false -p:PublishReadyToRun=false"
	Invoke-Expression -Command $publishCommand
}
		
function copyRuntimeIntoAppropriateFolde {
	param(
		$runtime
	)
	$runtimePath = (Get-Item "ProgramExec\bin\Debug\net5.0\$runtime\publish\ProgramExec*").FullName
	$runtimeExtension = [System.IO.Path]::GetExtension($runtimePath).ToString()
	Copy-Item $runtimePath -Destination "publishToGitHub/$runtime$runtimeExtension"
}
function clearPublishToGithubFolder {
	cd .\publishToGithub
	rm *
	cd ..
}

clearPublishToGithubFolder
$runtimes = 'win-x64', 'linux-x64', 'osx-x64'
foreach ($runtime in $runtimes) {
	publishRuntime -runtime $runtime
}