using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataInspector.API.Entities;
using Microsoft.AspNetCore.SignalR;

namespace DataInspector.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamplesController : ControllerBase
    {
        private readonly DataInspectorDbContext _context;
        private readonly IHubContext<BroadcastHub> _broadcastHub;

        public SamplesController(DataInspectorDbContext context, IHubContext<BroadcastHub> hub)
        {
            _context = context;
            _broadcastHub = hub;
        }

        // GET: api/Samples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sample>>> GetSamples()
        {
            return await _context.Samples.ToListAsync();
        }

        // GET: api/Samples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sample>> GetSample(int id)
        {
            var sample = await _context.Samples.FindAsync(id);

            if (sample == null)
            {
                return NotFound();
            }

            return sample;
        }

        // PUT: api/Samples/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSample(int id, Sample sample)
        {
            if (id != sample.Id)
            {
                return BadRequest();
            }

            _context.Entry(sample).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                await _broadcastHub.Clients.All.SendAsync("Samples", "put", sample);
            } catch (DbUpdateConcurrencyException)
            {
                if (!SampleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Samples
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Sample>> PostSample(Sample sample)
        {
            _context.Samples.Add(sample);
            await _context.SaveChangesAsync();
            await _broadcastHub.Clients.All.SendAsync("Samples", "post", sample);

            return CreatedAtAction("GetSample", new { id = sample.Id }, sample);
        }

        // DELETE: api/Samples/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sample>> DeleteSample(int id)
        {
            var sample = await _context.Samples.FindAsync(id);
            if (sample == null)
            {
                return NotFound();
            }

            _context.Samples.Remove(sample);
            await _context.SaveChangesAsync();
            await _broadcastHub.Clients.All.SendAsync("Samples", "delete", sample);

            return sample;
        }

        private bool SampleExists(int id)
        {
            return _context.Samples.Any(e => e.Id == id);
        }
    }
}
