using ApplicationServices.Queries.Dtos;
using AutoMapper;
using DomainModels.OrderAggregate.Entities;
using DomainModels.ProductAggregate.Entities;
using DomainModels.UserAggregate.Entities;

namespace ApplicationServices.Utility;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, OrderQueryDto>();
        CreateMap<Order, OrderCommandDto>();
        CreateMap<OrderLine, OrderLineQueryDto>();
        CreateMap<OrderLine, OrderLineCommandDto>();
        CreateMap<OrderLineQueryDto, OrderLine>();
        CreateMap<OrderLineCommandDto, OrderLine>();
        CreateMap<Product, ProductDto>();
        CreateMap<User, UserDto>();
    }
}
