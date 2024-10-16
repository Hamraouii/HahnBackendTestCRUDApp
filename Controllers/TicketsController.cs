using HahnBackendTestCRUD.Data;
using HahnBackendTestCRUD.DTOs.Ticket;
using HahnBackendTestCRUD.Helpers;
using HahnBackendTestCRUD.Interfaces;
using HahnBackendTestCRUD.Mappings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HahnBackendTestCRUD.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets([FromQuery] QueryObject query)
        {
            var result = await _ticketRepository.GetAllAsync(query);


            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTicketById([FromRoute] int id) 
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket.ToTicketDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketRequestDto CreateTicketDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ticket =  CreateTicketDto.ToTicketFromCreateDTO();
            await _ticketRepository.CreateAsync(ticket);

            return CreatedAtAction(nameof(GetTicketById), new { id = ticket.Id }, ticket.ToTicketDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateTicket([FromRoute] int id, [FromBody] UpdateTicketRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ticket = await _ticketRepository.UpdateAsync(id, updateDto);
            if (ticket == null)
            {
                return NotFound();
            }
           
            return Ok(ticket.ToTicketDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ticket = await _ticketRepository.DeleteAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
