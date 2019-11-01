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
	public class TelefonesController : ControllerBase
	{
		private readonly postgresContext _context;

		public TelefonesController(postgresContext context)
		{
			_context = context;
		}

		// GET: api/Telefones
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Telefone>>> GetTelefone()
		{
			return await _context.Telefone.ToListAsync();
		}

		// GET: api/Telefones/2018/101010
		[HttpGet("{ano}/{id}")]
		public async Task<ActionResult<IEnumerable<Telefone>>> GetTelefone(short ano, long id)
		{
			return await _context.Telefone.Where(ce => ce.Ano == ano && ce.CodEntidade == id).ToListAsync();
		}

		// GET: api/Telefones/33333333/2018/101010
		[HttpGet("{num}/{ano}/{id}")]
		public async Task<ActionResult<Telefone>> GetTelefone(long num, short ano, long id)
		{
			var telefone = await _context.Telefone.Where(ce => ce.Numero == num && ce.Ano == ano && ce.CodEntidade == id).FirstAsync();

			if (telefone == null)
			{
				return NotFound();
			}

			return telefone;
		}

		// PUT: api/Telefones/33333333/2018/101010
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{num}/{ano}/{id}")]
		public async Task<IActionResult> PutTelefone(long num, short ano, long id, Telefone telefone)
		{
			if (id != telefone.CodEntidade || ano != telefone.Ano || num != telefone.Numero)
			{
				return BadRequest();
			}

			_context.Entry(telefone).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!TelefoneExists(num, ano, id))
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

		// POST: api/Telefones
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Telefone>> PostTelefone(Telefone telefone)
		{
			_context.Telefone.Add(telefone);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (TelefoneExists(telefone.Numero, telefone.Ano, telefone.CodEntidade))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return CreatedAtAction("GetTelefone", new { num = telefone.Numero, ano = telefone.Ano, id = telefone.CodEntidade }, telefone);
		}

		// DELETE: api/Telefones/33333333/2018/101010
		[HttpDelete("{num}/{ano}/{id}")]
		public async Task<ActionResult<Telefone>> DeleteTelefone(long num, short ano, long id)
		{
			var telefone = await _context.Telefone.Where(ce => ce.Numero == num && ce.Ano == ano && ce.CodEntidade == id).FirstAsync();
			if (telefone == null)
			{
				return NotFound();
			}

			_context.Telefone.Remove(telefone);
			await _context.SaveChangesAsync();

			return telefone;
		}

		private bool TelefoneExists(long num, short ano, long id)
		{
			return _context.Telefone.Any(e => e.Numero == num && e.Ano == ano && e.CodEntidade == id);
		}
	}
}
