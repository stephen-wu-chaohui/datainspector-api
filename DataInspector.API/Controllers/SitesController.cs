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
    public class SitesController : ControllerBase
    {
        private readonly DataInspectorDbContext _context;
        private readonly IHubContext<BroadcastHub> _broadcastHub;

        public SitesController(DataInspectorDbContext context, IHubContext<BroadcastHub> hub)
        {
            _context = context;
            _broadcastHub = hub;
        }

        // GET: api/Sites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Site>>> GetSites()
        {
            return await _context.Sites.ToListAsync();
        }

        // GET: api/Sites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Site>> GetSite(int id)
        {
            var site = await _context.Sites.FindAsync(id);

            if (site == null)
            {
                return NotFound();
            }

            return site;
        }

        // PUT: api/Sites/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSite(int id, Site site)
        {
            if (id != site.Id)
            {
                return BadRequest();
            }

            _context.Entry(site).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                await _broadcastHub.Clients.All.SendAsync("Sites", "put", site);
            } catch (DbUpdateConcurrencyException)
            {
                if (!SiteExists(id))
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

        // POST: api/Sites
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Site>> PostSite(Site site)
        {
            _context.Sites.Add(site);
            await _context.SaveChangesAsync();
            await _broadcastHub.Clients.All.SendAsync("Sites", "post", site);

            return CreatedAtAction("GetSite", new { id = site.Id }, site);
        }

        // DELETE: api/Sites/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Site>> DeleteSite(int id)
        {
            var site = await _context.Sites.FindAsync(id);
            if (site == null)
            {
                return NotFound();
            }

            _context.Sites.Remove(site);
            await _context.SaveChangesAsync();
            await _broadcastHub.Clients.All.SendAsync("Sites", "delete", site);

            return site;
        }

        private bool SiteExists(int id)
        {
            return _context.Sites.Any(e => e.Id == id);
        }
    }
}
