using MyShop.Application.Abstractions;

namespace MyShop.Application.Commands;

public sealed record CreateCategory(string Name) : ICommand;
