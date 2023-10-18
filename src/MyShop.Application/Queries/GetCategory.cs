using MyShop.Application.Abstractions;
using MyShop.Application.DTO;

namespace MyShop.Application.Queries;

public record GetCategory(Guid CategoryId) : IQuery<CategoryDto>;
