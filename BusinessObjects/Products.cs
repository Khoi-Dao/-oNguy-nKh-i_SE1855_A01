using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string? QuantityPerUnit { get; set; }
        public double? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public int? UnitsOnOrder { get; set; }
        public int? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        
        public virtual Categories? Category { get; set; }

        public Products()
        {
            // Default constructor
        }
        public Products(int productId, string productName, int? supplierId, int? categoryId, string? quantityPerUnit, double? unitPrice, int? unitsInStock, int? unitsOnOrder, int? reorderLevel, bool discontinued)
        {
            this.ProductID = productId;
            this.ProductName = productName;
            this.SupplierID = supplierId;
            this.CategoryID = categoryId;
            this.QuantityPerUnit = quantityPerUnit;
            this.UnitPrice = unitPrice;
            this.UnitsInStock = unitsInStock;
            this.UnitsOnOrder = unitsOnOrder;
            this.ReorderLevel = reorderLevel;
            this.Discontinued = discontinued;
        }
    }
}
