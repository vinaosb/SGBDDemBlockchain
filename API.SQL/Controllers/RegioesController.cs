using API.SQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.SQL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegioesController : ControllerBase
	{
		private readonly postgresContext _context;

		public RegioesController(postgresContext context)
		{
			_context = context;
		}

		// GET: api/Regioes
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Regiao>>> GetRegiao()
		{
			return await _context.Regiao.ToListAsync();
		}

		// GET: api/Regioes/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Regiao>> GetRegiao(long id)
		{
			var regiao = await _context.Regiao.FindAsync(id);

			if (regiao == null)
			{
				return NotFound();
			}

			return regiao;
		}

		// PUT: api/Regioes/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutRegiao(long id, Regiao regiao)
		{
			if (id != regiao.CodRegiao)
			{
				return BadRequest();
			}

			_context.Entry(regiao).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!RegiaoExists(id))
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

		// POST: api/Regioes
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Regiao>> PostRegiao(Regiao regiao)
		{
			_context.Regiao.Add(regiao);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (RegiaoExists(regiao.CodRegiao))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return CreatedAtAction("GetRegiao", new { id = regiao.CodRegiao }, regiao);
		}

		// DELETE: api/Regioes/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Regiao>> DeleteRegiao(long id)
		{
			var regiao = await _context.Regiao.FindAsync(id);
			if (regiao == null)
			{
				return NotFound();
			}

			_context.Regiao.Remove(regiao);
			await _context.SaveChangesAsync();

			return regiao;
		}

		private bool RegiaoExists(long id)
		{
			return _context.Regiao.Any(e => e.CodRegiao == id);
		}
	}
}
