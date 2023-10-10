using MyShop.Application.Abstractions;

namespace MyShop.Application.Commands;

public sealed record UpdateProduct(Guid ProductId, string Name, string Description, double Price, Guid CategoryId) : ICommand;

