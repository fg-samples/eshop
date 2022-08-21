using DomainModels.UserAggregate.Data;
using DomainModels.UserAggregate.Entities;
using Framework.Data;
using MediatR;

namespace ApplicationServices.Commands;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateUserCommand rq, CancellationToken ct)
    {
        var user = User.Create(rq.FullName, rq.Email);
        var dbUser = await _userRepository.Insert(user, ct);
        await _unitOfWork.SaveChanges(ct);

        return dbUser.Id;
    }
}
