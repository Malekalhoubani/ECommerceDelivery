using DataAccess.Models;
using ECommerceService.Application.DTOs;
using ECommerceService.Application.DTOs.Products;
using ECommerceService.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceService.Application.Services.Products
{
    public interface IProductService
    {
        Task<int> CreateAsync(CreateProductDto dto , CancellationToken cancellationToken = default);
        Task UpdateAsync(int id, UpdateProductDto dto, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id,CancellationToken cancellationToken = default);
        Task<ProductDto> GetByIdAsync(int id,CancellationToken cancellationToken = default);
        Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<PagedResult<ProductDto>> SearchAsync(ProductFilterModel filter,CancellationToken cancellationToken = default);

    }
}
