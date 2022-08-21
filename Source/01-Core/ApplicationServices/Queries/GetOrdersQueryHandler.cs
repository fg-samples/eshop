using ApplicationServices.Queries.Dtos;
using AutoMapper;
using DomainModels.OrderAggregate.Data;
using MediatR;

namespace ApplicationServices.Queries;

public sealed class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<OrderQueryDto>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderQueryDto>> Handle(GetOrdersQuery rq, CancellationToken ct)
    {
        var dbOrders = await _orderRepository.Get(ct);

        var orderDtos = _mapper.Map<IEnumerable<OrderQueryDto>>(dbOrders);

        return orderDtos;
    }
}
