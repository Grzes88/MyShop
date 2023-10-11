using MyShop.Application.Abstractions;
using MyShop.Application.DTO;

namespace MyShop.Application.Queries;

public class GetProducts : IQuery<IEnumerable<ProductDto>>
{
}
