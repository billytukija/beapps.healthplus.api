using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using beapps.healthplus.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace beapps.healthplus.api.Controllers
{
    [Route("api/[controller]")]
    public class RemedyController : Controller
    {
        private readonly healthplusContext _context;

        public RemedyController(healthplusContext context)
        {
            _context = context;

            if (_context.Remedies.Count() == 0)
            {
                _context.Remedies.Add(new Remedy { Description = "Desc1", IsActive = true });
                _context.Remedies.Add(new Remedy { Description = "Desc2", IsActive = false });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<IEnumerable<Remedy>> Get()
        {
            return await _context.Remedies.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Remedy>> GetById(long id)
        {

            var remedies = await _context.Remedies.FindAsync(id);

            if (remedies == null)
            {
                return NotFound();
            }
            else
            {
                return remedies;
            }
        }
    }
}
