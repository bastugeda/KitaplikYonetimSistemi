using Kitaplik.Domain.Entities;
using Kitaplik.Domain.Entities;
using Kitaplik.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneYonetimSistemi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Tüm işlemler için JWT token zorunlu
    public class KitapController : ControllerBase
    {
        private readonly KitaplikDbContext _context;

        public KitapController(KitaplikDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var kitaplar = await _context.Kitaplar.ToListAsync();
            return Ok(kitaplar);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap == null)
                return NotFound();
            return Ok(kitap);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Kitap kitap)
        {
            await _context.Kitaplar.AddAsync(kitap);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = kitap.Id }, kitap);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Kitap kitap)
        {
            if (id != kitap.Id)
                return BadRequest();

            _context.Entry(kitap).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap == null)
                return NotFound();

            _context.Kitaplar.Remove(kitap);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
