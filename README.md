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

dotnet run 

Open:

- `http://localhost:5108`

## Current MVP Scope

The current implementation is intentionally simple and focused on demo readiness:

- Data is stored in memory
- No database persistence yet
- No create/edit/delete workflow yet
- No authentication yet

## Next Steps

- Add create, edit, and delete inventory screens
- Add SQLite or SQL Server persistence
- Add stock movement history and reorder workflows
- Add supplier management
