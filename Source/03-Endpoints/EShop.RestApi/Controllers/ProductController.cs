using ApplicationServices.Commands;
using ApplicationServices.Queries;
using EShop.RestApi.Swagger.Examples;
using Framework.ApiResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace EShop.RestApi.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Creates product
    /// </summary>
    /// <param name="command"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost]
    [SwaggerRequestExample(typeof(CreateProductCommand), typeof(CreateProductCommandExample))]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command, CancellationToken ct)
    {
        var rs = await _mediator.Send(command, ct);
        var location = new Uri($"{Request.Path.Value}/{rs}", UriKind.Relative).ToString();
        return rs.ToActionResult(location);
    }

    /// <summary>
    /// Gets all product
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        var rq = new GetProductsQuery();
        var rs = await _mediator.Send(rq, ct);
        return rs.ToActionResult();
    }

    /// <summary>
    /// Gets product by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken ct)
    {
        var rq = new GetProductQuery { Id = id };
        var rs = await _mediator.Send(rq, ct);
        return rs.ToActionResult();
    }
}