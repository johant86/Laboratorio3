param([ValidateSet('build','run')][string]$Action = 'build')
$ErrorActionPreference = 'Stop'
Push-Location $PSScriptRoot
try {
    dotnet build Laboratorio3.csproj
    if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
    if ($Action -eq 'run') { dotnet run --no-build --project Laboratorio3.csproj --urls http://localhost:5086 }
} finally { Pop-Location }
