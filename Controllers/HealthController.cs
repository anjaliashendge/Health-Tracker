using Microsoft.AspNetCore.Mvc;
using HealthTracker.Data;
using HealthTracker.Models;
using System.Linq;

namespace HealthTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HealthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.HealthEntries.ToList());
        }

        [HttpPost]
        public IActionResult AddEntry(HealthEntry entry)
        {
            _context.HealthEntries.Add(entry);
            _context.SaveChanges();
            return Ok(entry);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entry = _context.HealthEntries.Find(id);
            if (entry == null) return NotFound();
            return Ok(entry);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, HealthEntry updated)
        {
            var entry = _context.HealthEntries.Find(id);
            if (entry == null) return NotFound();

            entry.SleepHours = updated.SleepHours;
            entry.WaterLiters = updated.WaterLiters;
            entry.ExerciseMinutes = updated.ExerciseMinutes;
            entry.Date = updated.Date;

            _context.SaveChanges();
            return Ok(entry);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entry = _context.HealthEntries.Find(id);
            if (entry == null) return NotFound();

            _context.HealthEntries.Remove(entry);
            _context.SaveChanges();
            return Ok();
        }
    }
}