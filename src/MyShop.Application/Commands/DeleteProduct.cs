using MyShop.Application.Abstractions;

namespace MyShop.Application.Commands;

public sealed record DeleteProduct(Guid ProductId) : ICommand;

