using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Entities;
using WebApplication9.Helpers;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly DataContext _context;

        public ClassesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Classes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClassInfo()
        {
            return await _context.ClassInfo.Include(s => s.SchoolYear).ToListAsync();
        }

        // GET: api/Classes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClass(int id)
        {
            var @class = await _context.ClassInfo.FindAsync(id);

            if (@class == null)
            {
                return NotFound();
            }

            return @class;
        }

        // PUT: api/Classes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass(int id, Class @class)
        {
            if (id != @class.CId)
            {
                return BadRequest();
            }

            _context.Entry(@class).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(id))
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

        // POST: api/Classes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Class>> PostClass(Classpost classpost)
        {
            _context.ClassInfo.Add(new Class()
            {
                ClassName = classpost.classname,
                YearId = classpost.yearId
            });
            await _context.SaveChangesAsync();
            var classid = await _context.ClassInfo.Where(s => s.ClassName == classpost.classname)
                           .FirstOrDefaultAsync();
            foreach (int TId in classpost.TId)
            {
                _context.TeacherClasses.Add(new TeacherClass()
                {
                    TId = TId,
                    CId = classid.CId

                });
                await _context.SaveChangesAsync();
            }
            return Ok(new
            {
                CId = classpost.classname,
                Yearid= classpost.yearId

            });
            
        }

        // DELETE: api/Classes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Class>> DeleteClass(int id)
        {
            var @class = await _context.ClassInfo.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }

            _context.ClassInfo.Remove(@class);
            await _context.SaveChangesAsync();

            return @class;
        }

        private bool ClassExists(int id)
        {
            return _context.ClassInfo.Any(e => e.CId == id);
        }
    }
}
