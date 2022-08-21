using ApplicationServices.Queries.Dtos;
using AutoMapper;
using DomainModels.UserAggregate.Data;
using MediatR;

namespace ApplicationServices.Queries;

public sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery rq, CancellationToken ct)
    {
        var dbUsers = await _userRepository.Get(ct);

        var userDtos = _mapper.Map<IEnumerable<UserDto>>(dbUsers);

        return userDtos;
    }
}
