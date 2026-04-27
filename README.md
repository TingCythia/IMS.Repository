# IMS

Inventory Management System MVP for ProData, built with ASP.NET Core Blazor on .NET 8.

This repo currently contains a small inventory dashboard with:

- Seeded in-memory product data
- Search by product name, SKU, category, or supplier
- Category and stock status filters
- Low stock visibility
- Inventory value summary cards

## Tech Stack

- .NET 8
- ASP.NET Core Blazor Web App
- In-memory repository for demo data

## Project Structure

- `IMS.CoreBusiness` - domain models such as `Inventory`
- `IMS.UseCases` - application contracts and use cases
- `IMS.Plugins/IMS.Plugins.InMemory` - seeded demo repository implementation
- `IMS.WebApp` - Blazor UI

## Prerequisites

- Windows PowerShell
- .NET SDK `8.0.203`

The repo includes `global.json` to pin the SDK version used during local development.

## Run The App

From the repo root:

```powershell
cd "D:\C Sharp Practice Projects\IMS"
$env:DOTNET_CLI_HOME = (Join-Path $PWD '.dotnet')
$env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = '1'
dotnet run --project .\IMS.WebApp\IMS.WebApp.csproj --launch-profile http -m:1 -p:BuildInParallel=false
```

Open:

- `http://localhost:5108`

## Rebuild Only

```powershell
cd "D:\C Sharp Practice Projects\IMS"
$env:DOTNET_CLI_HOME = (Join-Path $PWD '.dotnet')
$env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = '1'
dotnet build .\IMS.WebApp\IMS.WebApp.csproj -m:1 -p:BuildInParallel=false
```

## If You See Locked DLL Errors

If `dotnet run` or `dotnet build` fails with `MSB3021` or `MSB3027`, an older app instance is still running and locking the output files.

Stop the running app first:

```powershell
Get-Process dotnet | Stop-Process -Force
```

Then rerun the `dotnet build` or `dotnet run` command.

If you only want to stop the process using the app port:

```powershell
netstat -ano | findstr :5108
Stop-Process -Id <PID> -Force
```

## Why The Extra Build Flags Matter

This machine has shown intermittent parallel MSBuild issues when project references are evaluated. These flags make local builds reliable:

- `-m:1`
- `-p:BuildInParallel=false`

## Current MVP Scope

The current implementation is intentionally simple and focused on demo readiness:

- Data is stored in memory
- No database persistence yet
- No create/edit/delete workflow yet
- No authentication yet

## Suggested Next Steps

- Add create, edit, and delete inventory screens
- Add SQLite or SQL Server persistence
- Add stock movement history and reorder workflows
- Add supplier management
