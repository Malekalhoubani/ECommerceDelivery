using BuildingBlocks.Common.Exceptions;
using BuildingBlocks.SharedKernel.ValueObjects;
using DataAccess.Models;
using DataAccess.Repositories.GenericRepository;
using DataAccess.UnitOfWork;
using ECommerceService.Application.DTOs;
using ECommerceService.Application.DTOs.Products;
using ECommerceService.Application.Models;
using ECommerceService.Application.Specifications;
using ECommerceService.Domain.Entities;
namespace ECommerceService.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IRepository<Product> productRepositry, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepositry;
            _unitOfWork = unitOfWork;

        }

        public async Task<int> CreateAsync(CreateProductDto dto, CancellationToken cancellationToken = default)
        {
            var price = new Money(dto.Price, dto.Currency);

            var product = new Product(dto.Name, dto.Description, price, dto.StockQuantity, dto.SKU, dto.CategoryId,dto.BrandId);

            await _productRepository.AddAsync(product, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return product.Id;
        }

        public async Task UpdateAsync(int id, UpdateProductDto dto, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.GetByIdAsync(id, cancellationToken);
            if (product is null)
                throw new NotFoundException("Product", id);

            var price = new Money(dto.Price, dto.Currency);
            product.Update(dto.Name, dto.Description, price, dto.StockQuantity, dto.SKU, dto.CategoryId , dto.BrandId);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.GetByIdAsync(id, cancellationToken);
            if (product is null)
                throw new NotFoundException("Product", id);
            _productRepository.Delete(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        public async Task<ProductDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.GetByIdAsync(id,cancellationToken);

            if (product is null)
                throw new NotFoundException("Product", id);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price.Amount,
                Currency = product.Price.Currency,
                StockQuantity = product.StockQuantity,
                SKU = product.SKU,
                Status = product.Status.ToString(),
                CategoryId = product.CategoryId,
                BrandId = product.BrandId
            };
        }
        public async Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var products = await _productRepository.GetAllAsync(
                cancellationToken);

            return products
                .Select(product => new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price.Amount,
                    Currency = product.Price.Currency,
                    StockQuantity = product.StockQuantity,
                    SKU = product.SKU,
                    Status = product.Status.ToString(),
                    CategoryId = product.CategoryId ,
                    BrandId = product.BrandId
                })
                .ToList();
        }
        public async Task<PagedResult<ProductDto>> SearchAsync(ProductFilterModel filter,CancellationToken cancellationToken = default)
        {
            var pagedSpecification = new ProductSpecification(filter);

            var countSpecification = new ProductSpecification(filter,false);

            var products = await _productRepository.ListAsync(pagedSpecification,cancellationToken);

            var totalCount = await _productRepository.CountAsync(countSpecification,cancellationToken);

            var items = products
                .Select(product => new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price.Amount,
                    Currency = product.Price.Currency,
                    StockQuantity = product.StockQuantity,
                    SKU = product.SKU,
                    Status = product.Status.ToString(),
                    CategoryId = product.CategoryId,
                    BrandId = product.BrandId
                })
                .ToList();

            return new PagedResult<ProductDto>
            {
                Items = items,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalCount = totalCount
            };
        }
    }
}
