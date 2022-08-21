using ApplicationServices.Commands;
using ApplicationServices.Queries.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace EShop.RestApi.Swagger.Examples;

public sealed class CreateUserCommandExample : IExamplesProvider<CreateUserCommand>
{
    public CreateUserCommand GetExamples()
    {
        return new CreateUserCommand
        {
            FullName = "Farshad Goodarzi",
            Email = "farshad@goodarzi.com"
        };
    }
}

public sealed class CreateOrderCommandExample : IExamplesProvider<CreateOrderCommand>
{
    public CreateOrderCommand GetExamples()
    {
        return new CreateOrderCommand
        {
            UserId = 1,
            Description = "Ordering samsung s22",
            OrderLines = new List<OrderLineCommandDto>
            {
                new OrderLineCommandDto { Quantity = 10, ProductId = 1 },
            },
        };
    }
}
