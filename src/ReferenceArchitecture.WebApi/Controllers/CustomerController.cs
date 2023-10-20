using Microsoft.AspNetCore.Mvc;
using ReferenceArchitecture.Domain.CustomerContext.Commands;
using ReferenceArchitecture.Shared.Mediator;

namespace ReferenceArchitecture.WebApi.Controllers
{
  [ApiController]
  [Route("v1/[controller]")]
  public class CustomerController : ControllerBase
  {
    private readonly IMediatorHandler _mediator;

    public CustomerController(IMediatorHandler mediator)
    {
      _mediator = mediator;
    }

    //[Authorize(PolicyConstants.Default)]
    //[ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCustomerCommand command)
    {
      var response = await _mediator.SendCommand(command)
        .ConfigureAwait(false);

      return Ok();
    }
  }
}
