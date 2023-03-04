using Microsoft.AspNetCore.Mvc;
using phonebook_core.Entities;
using phonebook_core.Interfaces;

namespace phonebook_spa.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("[controller]")]
public class PhoneBookController : ControllerBase
{
    private readonly ILogger<PhoneBookController> _logger;
    private readonly IRepository<PhoneBookEntry> _phoneBookRepository;

    public PhoneBookController(ILogger<PhoneBookController> logger, IRepository<PhoneBookEntry> phoneBookRepository)
    {
        _logger = logger;
        _phoneBookRepository = phoneBookRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<PhoneBookEntry>>> GetAll()
    {
        var entries = await _phoneBookRepository.GetAllAsync();
        return Ok(entries);
    }
}
