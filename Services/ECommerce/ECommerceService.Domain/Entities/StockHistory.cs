using BuildingBlocks.SharedKernel.Entities;

namespace ECommerceService.Domain.Entities;

public class StockHistory : AuditableEntity
{
    public int InventoryId { get; private set; }

    public int Quantity { get; private set; }

    public string TransactionType { get; private set; } = null!;

    public int QuantityBefore { get; private set; }

    public int QuantityAfter { get; private set; }

    public string? Notes { get; private set; }

    public Inventory Inventory { get; private set; } = null!;

    private StockHistory()
    {
    }

    public StockHistory(
        int inventoryId,
        int quantity,
        string transactionType,
        int quantityBefore,
        int quantityAfter,
        string? notes = null)
    {
        if (inventoryId <= 0)
            throw new ArgumentException("InventoryId must be greater than zero.");

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        if (string.IsNullOrWhiteSpace(transactionType))
            throw new ArgumentException("Transaction type is required.");

        InventoryId = inventoryId;
        Quantity = quantity;
        TransactionType = transactionType;
        QuantityBefore = quantityBefore;
        QuantityAfter = quantityAfter;
        Notes = notes;
    }
}