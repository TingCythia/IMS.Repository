using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly List<Inventory> inventories;

        public InventoryRepository()
        {
            inventories = new List<Inventory>
            {
                new()
                {
                    InventoryId = 1,
                    Sku = "PRD-LAP-001",
                    InventoryName = "Latitude Pro 14 Laptop",
                    Category = "Computing",
                    Supplier = "Northwind Devices",
                    StorageLocation = "Aisle A1",
                    Quantity = 18,
                    ReorderLevel = 8,
                    UnitPrice = 1299.00m,
                    LastRestockedOn = new DateTime(2026, 4, 18)
                },
                new()
                {
                    InventoryId = 2,
                    Sku = "PRD-MON-003",
                    InventoryName = "UltraView 27 Monitor",
                    Category = "Displays",
                    Supplier = "Vista Industrial",
                    StorageLocation = "Aisle A3",
                    Quantity = 9,
                    ReorderLevel = 6,
                    UnitPrice = 349.00m,
                    LastRestockedOn = new DateTime(2026, 4, 12)
                },
                new()
                {
                    InventoryId = 3,
                    Sku = "PRD-KEY-014",
                    InventoryName = "Mechanical Keyboard",
                    Category = "Peripherals",
                    Supplier = "Keyline Supplies",
                    StorageLocation = "Aisle B2",
                    Quantity = 41,
                    ReorderLevel = 15,
                    UnitPrice = 109.00m,
                    LastRestockedOn = new DateTime(2026, 4, 21)
                },
                new()
                {
                    InventoryId = 4,
                    Sku = "PRD-MSE-007",
                    InventoryName = "Wireless Precision Mouse",
                    Category = "Peripherals",
                    Supplier = "Keyline Supplies",
                    StorageLocation = "Aisle B2",
                    Quantity = 36,
                    ReorderLevel = 12,
                    UnitPrice = 59.00m,
                    LastRestockedOn = new DateTime(2026, 4, 16)
                },
                new()
                {
                    InventoryId = 5,
                    Sku = "PRD-DOC-022",
                    InventoryName = "USB-C Docking Station",
                    Category = "Accessories",
                    Supplier = "Urban Harbor Tech",
                    StorageLocation = "Aisle C1",
                    Quantity = 7,
                    ReorderLevel = 10,
                    UnitPrice = 189.00m,
                    LastRestockedOn = new DateTime(2026, 4, 5)
                },
                new()
                {
                    InventoryId = 6,
                    Sku = "PRD-SSD-011",
                    InventoryName = "1TB NVMe SSD",
                    Category = "Components",
                    Supplier = "Core Circuits",
                    StorageLocation = "Secure Bin S4",
                    Quantity = 24,
                    ReorderLevel = 10,
                    UnitPrice = 139.00m,
                    LastRestockedOn = new DateTime(2026, 4, 14)
                },
                new()
                {
                    InventoryId = 7,
                    Sku = "PRD-RAM-009",
                    InventoryName = "32GB DDR5 Memory Kit",
                    Category = "Components",
                    Supplier = "Core Circuits",
                    StorageLocation = "Secure Bin S2",
                    Quantity = 13,
                    ReorderLevel = 8,
                    UnitPrice = 169.00m,
                    LastRestockedOn = new DateTime(2026, 4, 10)
                },
                new()
                {
                    InventoryId = 8,
                    Sku = "PRD-WEB-020",
                    InventoryName = "4K Conference Webcam",
                    Category = "Collaboration",
                    Supplier = "Nova Vision",
                    StorageLocation = "Aisle D1",
                    Quantity = 5,
                    ReorderLevel = 6,
                    UnitPrice = 219.00m,
                    LastRestockedOn = new DateTime(2026, 4, 2)
                },
                new()
                {
                    InventoryId = 9,
                    Sku = "PRD-HST-013",
                    InventoryName = "Noise-Canceling Headset",
                    Category = "Collaboration",
                    Supplier = "Nova Vision",
                    StorageLocation = "Aisle D2",
                    Quantity = 0,
                    ReorderLevel = 5,
                    UnitPrice = 149.00m,
                    LastRestockedOn = new DateTime(2026, 3, 28)
                },
                new()
                {
                    InventoryId = 10,
                    Sku = "PRD-CHA-030",
                    InventoryName = "ErgoTask Office Chair",
                    Category = "Furniture",
                    Supplier = "Studio Form",
                    StorageLocation = "Bulk Zone F1",
                    Quantity = 11,
                    ReorderLevel = 4,
                    UnitPrice = 429.00m,
                    LastRestockedOn = new DateTime(2026, 4, 9)
                },
                new()
                {
                    InventoryId = 11,
                    Sku = "PRD-DSK-031",
                    InventoryName = "Height-Adjustable Desk",
                    Category = "Furniture",
                    Supplier = "Studio Form",
                    StorageLocation = "Bulk Zone F3",
                    Quantity = 4,
                    ReorderLevel = 4,
                    UnitPrice = 699.00m,
                    LastRestockedOn = new DateTime(2026, 4, 1)
                },
                new()
                {
                    InventoryId = 12,
                    Sku = "PRD-CBL-018",
                    InventoryName = "USB-C Cable 2m",
                    Category = "Accessories",
                    Supplier = "Urban Harbor Tech",
                    StorageLocation = "Aisle C3",
                    Quantity = 96,
                    ReorderLevel = 30,
                    UnitPrice = 14.00m,
                    LastRestockedOn = new DateTime(2026, 4, 20)
                }
            };
        }

        public Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Task.FromResult<IEnumerable<Inventory>>(inventories
                    .OrderBy(item => item.Category)
                    .ThenBy(item => item.InventoryName)
                    .ToList());
            }

            var searchText = name.Trim();

            var results = inventories
                .Where(item =>
                    item.InventoryName.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                    item.Sku.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                    item.Category.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                    item.Supplier.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                .OrderBy(item => item.Category)
                .ThenBy(item => item.InventoryName)
                .ToList();

            return Task.FromResult<IEnumerable<Inventory>>(results);
        }
    }
}
