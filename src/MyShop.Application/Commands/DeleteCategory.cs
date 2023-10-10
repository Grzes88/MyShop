using MyShop.Application.Abstractions;

namespace MyShop.Application.Commands;

public sealed record DeleteCategory(Guid CategoryId) : ICommand;

