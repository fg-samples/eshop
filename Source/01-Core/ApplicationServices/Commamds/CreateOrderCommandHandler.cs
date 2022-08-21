using AutoMapper;
using DomainModels.OrderAggregate.Data;
using DomainModels.OrderAggregate.Entities;
using DomainModels.ProductAggregate.Data;
using DomainServices.Abstractions;
using Framework.Data;
using MediatR;

namespace ApplicationServices.Commands;

public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderService _orderService;
    private readonly IPostOfficeService _postDeterminer;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository, 
        IUnitOfWork unitOfWork, IOrderService orderService, IPostOfficeService postDeterminer, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _orderService = orderService;
        _postDeterminer = postDeterminer;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateOrderCommand rq, CancellationToken ct)
    {
        _orderService.ValidateMarketTime();

        var productIds = rq.OrderLines.Select(o => o.ProductId);
        var products = await _productRepository.GetRange(productIds, ct);
        var postType = _postDeterminer.DeterminePostType(products, ct);

        var productsWithQuantity = rq.OrderLines
            .Select(o => (products.Single(p => p.Id == o.ProductId), o.Quantity));

        var orderLines = _orderService.CalculateOrderLinesExecutionPrices(productsWithQuantity);

        var orderPrice = _orderService.CalculateOrderPrice(orderLines);
        _orderService.ValidateOrderPrice(orderPrice);

        var order = Order.Create(rq.UserId, rq.Description, postType, orderLines);
        var dbOrder = await _orderRepository.Insert(order, ct);
        await _unitOfWork.SaveChanges(ct);

        return dbOrder.Id;
    }
}
