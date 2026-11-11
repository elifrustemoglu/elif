using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EgitimPortali.API.DTOs;
using EgitimPortali.API.Services;

namespace EgitimPortali.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMessagesController : ControllerBase
    {
        private readonly IContactMessageService _contactMessageService;

        public ContactMessagesController(IContactMessageService contactMessageService)
        {
            _contactMessageService = contactMessageService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var message = await _contactMessageService.GetByIdAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactMessageDto newDto)
        {
            var createdMessage = await _contactMessageService.CreateMessageAsync(newDto);
            return Ok(createdMessage);
        }
    }
}