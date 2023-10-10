using MyShop.Application.Abstractions;

namespace MyShop.Application.Commands;

public sealed record UpdateCategory(Guid CategoryId, string Name) : ICommand;
