using ECommerceService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var inventory = await _inventoryService.GetByIdAsync(id);

        if (inventory is null)
            return NotFound();

        return Ok(inventory);
    }

    [HttpPost("{id:int}/stock-in")]
    public async Task<IActionResult> StockIn(int id, int quantity)
    {
        await _inventoryService.StockInAsync(id, quantity);
        return NoContent();
    }

    [HttpPost("{id:int}/stock-out")]
    public async Task<IActionResult> StockOut(int id, int quantity)
    {
        await _inventoryService.StockOutAsync(id, quantity);
        return NoContent();
    }

    [HttpPost("{id:int}/reserve")]
    public async Task<IActionResult> Reserve(int id, int quantity)
    {
        await _inventoryService.ReserveAsync(id, quantity);
        return NoContent();
    }

    [HttpPost("{id:int}/release")]
    public async Task<IActionResult> Release(int id, int quantity)
    {
        await _inventoryService.ReleaseReservationAsync(id, quantity);
        return NoContent();
    }
}