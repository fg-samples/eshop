using ApplicationServices.Queries.Dtos;
using MediatR;

namespace ApplicationServices.Queries;

public sealed class GetUsersQuery : IRequest<IEnumerable<UserDto>>
{ }
