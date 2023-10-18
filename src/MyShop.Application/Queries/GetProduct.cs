using MyShop.Application.Abstractions;
using MyShop.Application.DTO;

namespace MyShop.Application.Queries;

public record GetProduct(Guid ProductId) : IQuery<ProductDto>;
