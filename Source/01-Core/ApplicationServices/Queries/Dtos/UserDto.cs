namespace ApplicationServices.Queries.Dtos;

public sealed class UserDto
{
    public int Id { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}
