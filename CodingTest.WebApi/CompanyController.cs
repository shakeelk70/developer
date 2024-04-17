using CodingTest.Database;
using CodingTest.Domain;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingTest.WebApi.Controllers;

public class CompanyController : ControllerBase 
{
    private readonly IRepository repository;
    private readonly ILogger<CompanyController> logger;

    public CompanyController(IRepository repository, ILogger<CompanyController> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    [Route("company")]
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType<IEnumerable<Company>>(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Company>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        logger.LogInformation("Get companies - page {page} with a page size of {pageSize}", page, pageSize);
        // Just test database connectivity
        var retval = new [] {repository.Query<Company>().FirstAsync()};
        return Ok(retval);
    }

    [Route("company/{id:int}")]
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType<Company>(StatusCodes.Status200OK)]
    [ProducesResponseType<Company>(StatusCodes.Status404NotFound)]
    public ActionResult<Company> Get([FromRoute] int id)
    {
        throw new NotImplementedException();
    }
}