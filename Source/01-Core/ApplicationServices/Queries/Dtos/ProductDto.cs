namespace ApplicationServices.Queries.Dtos;

public sealed class ProductDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public ulong Price { get; init; }
    public bool IsBreakable { get; init; }
}
