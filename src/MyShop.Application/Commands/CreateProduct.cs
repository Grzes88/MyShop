using MyShop.Application.Abstractions;

namespace MyShop.Application.Commands;

public sealed record CreateProduct(string Name, string Description, decimal Price, Guid CategoryId) : ICommand;