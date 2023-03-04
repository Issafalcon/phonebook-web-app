using Microsoft.AspNetCore.Mvc;
using phonebook_core.Entities;
using phonebook_core.Interfaces;
using phonebook_spa.Models;

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
    public async Task<ActionResult<List<PhoneBookEntry>>> GetAllAsync()
    {
        var entries = await _phoneBookRepository.GetAllAsync();
        return Ok(entries);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PhoneBookEntry>> CreateEntryAsync([FromBody] CreatePhoneBookEntryRequest request)
    {
        var entry = await _phoneBookRepository.AddAsync(new PhoneBookEntry()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber
        });

        return Created("", entry);
    }
}
