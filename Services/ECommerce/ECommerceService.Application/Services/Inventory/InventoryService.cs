using DataAccess.Repositories.GenericRepository;
using DataAccess.UnitOfWork;
using ECommerceService.Application.Interfaces;
using ECommerceService.Domain.Entities;

namespace ECommerceService.Application.Services;

public class InventoryService : IInventoryService
{
    private readonly IRepository<Inventory> _inventoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InventoryService(
        IRepository<Inventory> inventoryRepository,
        IUnitOfWork unitOfWork)
    {
        _inventoryRepository = inventoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Inventory?> GetByIdAsync(int id)
    {
        return await _inventoryRepository.GetByIdAsync(id);
    }

    public async Task StockInAsync(int inventoryId, int quantity)
    {
        var inventory = await GetInventoryAsync(inventoryId);

        inventory.StockIn(quantity);

        _inventoryRepository.Update(inventory);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task StockOutAsync(int inventoryId, int quantity)
    {
        var inventory = await GetInventoryAsync(inventoryId);

        inventory.StockOut(quantity);

        _inventoryRepository.Update(inventory);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task ReserveAsync(int inventoryId, int quantity)
    {
        var inventory = await GetInventoryAsync(inventoryId);

        inventory.Reserve(quantity);

        _inventoryRepository.Update(inventory);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task ReleaseReservationAsync(int inventoryId, int quantity)
    {
        var inventory = await GetInventoryAsync(inventoryId);

        inventory.ReleaseReservation(quantity);

        _inventoryRepository.Update(inventory);

        await _unitOfWork.SaveChangesAsync();
    }

    private async Task<Inventory> GetInventoryAsync(int id)
    {
        var inventory = await _inventoryRepository.GetByIdAsync(id);

        if (inventory is null)
            throw new KeyNotFoundException(
                $"Inventory with id {id} was not found.");

        return inventory;
    }
}