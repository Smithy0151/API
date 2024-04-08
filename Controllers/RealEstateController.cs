using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly DataContext _context;

        public RealEstateController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agent>> GetAgentById(int id)
        {
            var agent = await _context.Agents
                .Include(a => a.Commission)
                .Include(a => a.Properties)
                .Include(a => a.Areas)
                .FirstOrDefaultAsync(a => a.Id == id);

            return Ok(agent);
        }

        [HttpGet]
        public async Task<ActionResult<Agent>> GetAgents()
        {
            var agent = await _context.Agents
                .Include(a => a.Commission)
                .Include(a => a.Properties)
                .Include(a => a.Areas)
                .ToListAsync();

            return Ok(agent);
        }

        //Create Real Estate agent with commission details
        [HttpPost]
        public async Task<ActionResult<List<Agent>>> CreateAgent(AgentCreateDTO request)
        {
            var newAgent = new Agent
            {
                Name = request.Name,
            };

            //AgentName should just be called Agent because it's An Agent Object in the Commission Model not a string name
            var commission = new Commission { Description = request.Commission.Description, AgentName = newAgent };
            var properties = request.Properties.Select(p => new Property { Address = p.Address, Agent = newAgent }).ToList();
            var areas = request.Areas.Select(a => new Area { City = a.City, Country = a.Country, Agents = new List<Agent> { newAgent } }).ToList();

            newAgent.Commission = commission;
            newAgent.Properties = properties;
            newAgent.Areas = areas;

            _context.Agents.Add(newAgent);
            await _context.SaveChangesAsync();  

            return Ok(await _context.Agents.Include(c => c.Commission).Include(c => c.Properties).ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Agent>>> DeleteAgent(int id)
        {
            var dbagent = await _context.Agents.FindAsync(id);
            if (dbagent is null)
            {
                return NotFound("Agent Not Found");
            }

            _context.Agents.Remove(dbagent);

            await _context.SaveChangesAsync();

            return Ok(await _context.Agents.ToListAsync());
        }
    }
}
