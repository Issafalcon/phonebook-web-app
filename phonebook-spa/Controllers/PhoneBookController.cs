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
    public async Task<ActionResult<PhoneBookEntry>> CreateEntryAsync([FromBody] PhoneBookEntryRequest request)
    {
        var entry = await _phoneBookRepository.AddAsync(new PhoneBookEntry()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber
        });

        return Created("", entry);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteEntryAsync([FromQuery] int id)
    {
        var entry = await _phoneBookRepository.GetByIdAsync(id);

        if (entry == null)
        {
            return NotFound(id);
        }

        await _phoneBookRepository.DeleteAsync(entry);
        return NoContent();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateEntryAsync([FromQuery] int id, [FromBody] PhoneBookEntryRequest request)
    {
        var entry = await _phoneBookRepository.GetByIdAsync(id);

        if (entry == null)
        {
            return NotFound(id);
        }

        entry.FirstName = request.FirstName;
        entry.LastName = request.LastName;
        entry.PhoneNumber = request.PhoneNumber;

        await _phoneBookRepository.UpdateAsync(entry);
        return Accepted();
    }
}
