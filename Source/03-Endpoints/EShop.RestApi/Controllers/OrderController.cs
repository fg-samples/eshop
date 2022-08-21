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
public sealed class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Creates order
    /// </summary>
    /// <param name="command"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost]
    [SwaggerRequestExample(typeof(CreateOrderCommand), typeof(CreateOrderCommandExample))]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command, CancellationToken ct)
    {
        var rs = await _mediator.Send(command, ct);
        var location = new Uri($"{Request.Path.Value}/{rs}", UriKind.Relative).ToString();
        return rs.ToActionResult(location);
    }

    /// <summary>
    /// Gets all order
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        var rq = new GetOrdersQuery();
        var rs = await _mediator.Send(rq, ct);
        return rs.ToActionResult();
    }

    /// <summary>
    /// Gets order by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken ct)
    {
        var rq = new GetOrderQuery { Id = id };
        var rs = await _mediator.Send(rq, ct);
        return rs.ToActionResult();
    }
}
