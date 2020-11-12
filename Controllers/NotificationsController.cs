using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Entities;
using WebApplication9.Helpers;

namespace WebApplication9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly DataContext _context;

        public NotificationsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Notifications/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotifications(int id )
        {
            return await _context.Notifications.Where(s => s.NUserId == id).ToListAsync();
        }

        

        // PUT: api/Notifications/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotification(int id, Notification notification)
        {
            if (id != notification.NUserId)
            {
                return BadRequest();
            }

            // Retrieve entity by id
            // Answer for question #1
            var catalog = await _context.Notifications.Where(x => x.NUserId == id).ToListAsync();

            //next we attach range here to let EF track the list
            _context.AttachRange(catalog);

            //perform your update as usual, this will be flagged as modified if changed
            catalog.ForEach(c => { c.Readstatus = "yes"; });

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationExists(id))
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

        // POST: api/Notifications
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Notification>> PostNotification(Notification notification)
        {
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotification", new { id = notification.NId }, notification);
        }

        // DELETE: api/Notifications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notification>> DeleteNotification(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }

            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();

            return notification;
        }

        private bool NotificationExists(int id)
        {
            return _context.Notifications.Any(e => e.NId == id);
        }
    }
}
