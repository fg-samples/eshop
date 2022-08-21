using AutoMapper;
using MediatR;

namespace ApplicationServices.Commands;

public sealed class CreateUserCommand: IRequest<int>
{
    public string FullName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}
