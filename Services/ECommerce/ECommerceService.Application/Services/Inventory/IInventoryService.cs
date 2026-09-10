using ECommerceService.Domain.Entities;

namespace ECommerceService.Application.Interfaces;

public interface IInventoryService
{
    Task<Inventory?> GetByIdAsync(int id);

    Task StockInAsync(int inventoryId, int quantity);

    Task StockOutAsync(int inventoryId, int quantity);

    Task ReserveAsync(int inventoryId, int quantity);

    Task ReleaseReservationAsync(int inventoryId, int quantity);
}