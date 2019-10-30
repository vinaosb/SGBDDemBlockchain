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
	public class EnderecosController : ControllerBase
	{
		private readonly postgresContext _context;

		public EnderecosController(postgresContext context)
		{
			_context = context;
		}

		// GET: api/Enderecoes
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Endereco>>> GetEndereco()
		{
			return await _context.Endereco.ToListAsync();
		}

		// GET: api/Enderecoes/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Endereco>> GetEndereco(long id)
		{
			var endereco = await _context.Endereco.FindAsync(id);

			if (endereco == null)
			{
				return NotFound();
			}

			return endereco;
		}

		// PUT: api/Enderecoes/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEndereco(long id, Endereco endereco)
		{
			if (id != endereco.CodEndereco)
			{
				return BadRequest();
			}

			_context.Entry(endereco).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!EnderecoExists(id))
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

		// POST: api/Enderecoes
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
		{
			_context.Endereco.Add(endereco);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (EnderecoExists(endereco.CodEndereco))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return CreatedAtAction("GetEndereco", new { id = endereco.CodEndereco }, endereco);
		}

		// DELETE: api/Enderecoes/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Endereco>> DeleteEndereco(long id)
		{
			var endereco = await _context.Endereco.FindAsync(id);
			if (endereco == null)
			{
				return NotFound();
			}

			_context.Endereco.Remove(endereco);
			await _context.SaveChangesAsync();

			return endereco;
		}

		private bool EnderecoExists(long id)
		{
			return _context.Endereco.Any(e => e.CodEndereco == id);
		}
	}
}
