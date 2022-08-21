using MediatR;

namespace ApplicationServices.Commands;

public sealed class CreateProductCommand : IRequest<int>
{
    public string Name { get; init; } = string.Empty;
    public ulong Price { get; init; }
    public bool IsBreakable { get; init; }
}
