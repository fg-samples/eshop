using ApplicationServices.Queries.Dtos;
using AutoMapper;
using DomainModels.UserAggregate.Data;
using MediatR;

namespace ApplicationServices.Queries;

public sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserQuery rq, CancellationToken ct)
    {
        var dbUser = await _userRepository.GetById(rq.Id, ct);

        var userDto = _mapper.Map<UserDto>(dbUser);

        return userDto;
    }
}
