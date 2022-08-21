using ApplicationServices.Queries.Dtos;
using MediatR;

namespace ApplicationServices.Queries;

public sealed class GetUserQuery : IRequest<UserDto>
{
    public int Id { get; init; }
}
