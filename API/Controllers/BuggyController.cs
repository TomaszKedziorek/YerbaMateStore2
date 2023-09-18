using API.Errors;
using Infrastructure.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuggyController : ControllerBase
{

  public readonly AppDbContext _dbContext;

  public BuggyController(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  [HttpGet("notfound")]
  public ActionResult GetNotFoundRequest()
  {
    var thing = _dbContext.Products.Find(450);
    if (thing == null)
    {
      return NotFound(new ApiResponse(404));
    }
    return Ok();
  }

  [HttpGet("servererror")]
  public ActionResult GetServerError()
  {
    var thing = _dbContext.Products.Find(45);
    thing.ToString();
    return Ok();
  }

  [HttpGet("badrequest")]
  public ActionResult GetBadRequest()
  {
    return BadRequest(new ApiResponse(400));
  }

  [HttpGet("badrequest/{id}/{type}")]
  public ActionResult GetBadRequest(int id, bool type)
  {
    return BadRequest();
  }
}
