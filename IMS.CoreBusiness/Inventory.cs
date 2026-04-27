namespace IMS.CoreBusiness
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public string Sku { get; set; } = string.Empty;
        public string InventoryName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Supplier { get; set; } = string.Empty;
        public string StorageLocation { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime LastRestockedOn { get; set; }

        public decimal InventoryValue => Quantity * UnitPrice;

        public bool IsLowStock => Quantity <= ReorderLevel;

        public string StockStatus => Quantity == 0
            ? "Out of stock"
            : IsLowStock
                ? "Low stock"
                : "In stock";
    }
}
