using BuildingBlocks.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceService.Domain.Entities
{
    public class Inventory : AuditableEntity
    {
        public int ProductId { get; private set; }
        public int AvailableQuantity { get; private set; }
        public int ReservedQuantity { get; private set; }

        public Product Product { get; private set; } = null!;

        public const int LowStockThreshold = 5;
        public Inventory()
        {
            
        }

        public Inventory(int productId, int availableQuantity)
        {
            if (productId <= 0)
                throw new ArgumentException("ProductId must be greater than zero.");

            if (availableQuantity < 0)
                throw new ArgumentException("Available quantity cannot be negative.");

            ProductId = productId;
            AvailableQuantity = availableQuantity;
            ReservedQuantity = 0;
        }
        public void StockIn(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Stock in quantity must be greater than zero.");

            AvailableQuantity += quantity;
        }
        public void StockOut(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Stock out quantity must be greater than zero.");

            if (quantity > AvailableQuantity)
                throw new InvalidOperationException("Insufficient stock.");

            AvailableQuantity -= quantity;
        }
        public void Reserve(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Reserved quantity must be greater than zero.");

            if (quantity > AvailableQuantity)
                throw new InvalidOperationException("Insufficient available stock.");

            AvailableQuantity -= quantity;
            ReservedQuantity += quantity;
        }

        public void ReleaseReservation(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Release quantity must be greater than zero.");

            if (quantity > ReservedQuantity)
                throw new InvalidOperationException("Cannot release more than reserved quantity.");

            ReservedQuantity -= quantity;
            AvailableQuantity += quantity;
        }
        public bool IsLowStock()
        {
            return AvailableQuantity <= LowStockThreshold;
        }

    }
}
