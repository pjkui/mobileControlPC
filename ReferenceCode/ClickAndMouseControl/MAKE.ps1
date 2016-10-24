param (
    [string]$msbuild = "C:\Windows\Microsoft.NET\Framework64\v3.5\MSBuild.exe",
    [string]$pathToSolution = $PWD,
    [string]$outputFolder = $PWD,
    [string]$options = "/p:Configuration=Release"
 )

$solutionName = "ClickAndMouseControl"
$solutionFileName = $solutionName + ".sln"
$executableFileName = $solutionName + ".exe"
$releaseFolder = $pathToSolution + "\" + $solutionName + "\bin\Release"

cd $pathToSolution

$clean = $msbuild + " "+ $solutionFileName + " " + $options + " /t:Clean"
$build = $msbuild + " "+ $solutionFileName + " " + $options + " /t:Build"
Invoke-Expression $clean
Invoke-Expression $build

[System.IO.File]::Move($releaseFolder + "\"+ $executableFileName, $outputFolder + "\" + $executableFileName)