using BackTestNotissimus.Data;
using BackTestNotissimus.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackTestNotissimus.Controllers
{
    [Route("api/mouse")]
    public class MouseC : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MouseC(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostMouseData([FromBody] List<long[]> coordinates)
        {
            if (coordinates == null || !coordinates.Any())
            {
                return BadRequest("Координаты не могут быть пустыми.");
            }

            var mouseData = new Mouse
            {
                Coordinates = JsonConvert.SerializeObject(coordinates)
            };

            _context.Mouses.Add(mouseData);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMouseData), new { id = mouseData.Id }, mouseData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mouse>> GetMouseData(int id)
        {
            var mouseData = await _context.Mouses.FindAsync(id);
            if (mouseData == null)
            {
                return NotFound();
            }

            return mouseData;
        }
    }
}
