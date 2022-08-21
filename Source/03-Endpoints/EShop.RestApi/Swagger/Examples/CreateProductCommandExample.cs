using ApplicationServices.Commands;
using Swashbuckle.AspNetCore.Filters;

namespace EShop.RestApi.Swagger.Examples;

public sealed class CreateProductCommandExample : IExamplesProvider<CreateProductCommand>
{
    public CreateProductCommand GetExamples()
    {
        return new CreateProductCommand
        {
            Name = "Samsung S22",
            Price = 5000,
            IsBreakable = false,
        };
    }
}
