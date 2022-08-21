using ApplicationServices.Queries.Dtos;
using AutoMapper;
using DomainModels.OrderAggregate.Data;
using MediatR;

namespace ApplicationServices.Queries;

public sealed class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderQueryDto>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<OrderQueryDto> Handle(GetOrderQuery rq, CancellationToken ct)
    {
        var dbOrder = await _orderRepository.GetById(rq.Id, ct);

        var orderDto = _mapper.Map<OrderQueryDto>(dbOrder);

        return orderDto;
    }
}
