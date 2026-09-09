namespace ECommerceService.Application.DTOs;

public class CreateProductDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; } = "JOD"; 
    public int StockQuantity { get; set; }
    public string? SKU { get; set; }
    public int CategoryId { get; set; }

    public int? BrandId { get; set; }
}