using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Context.Custom;
using SharedLibrary.Entities.Custom;
using System.Collections.Generic;
using static SharedLibrary.Entities.Custom.ExtrasDaEscola;

namespace API.Mongo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MongoController : ControllerBase
	{
		public readonly ExtrasDaEscolaContext _extrasContext;

		public MongoController(ExtrasDaEscolaContext context)
		{
			_extrasContext = context;
		}

		[HttpGet]
		public ActionResult<List<ExtrasDaEscola>> Get() =>
			_extrasContext.Get();

		[HttpGet("{ano}/{cod}")]
		public ActionResult<ExtrasDaEscola> GetExtra(short ano, long id)
		{
			Indexer ind = new Indexer { Ano = ano, Cod_Entidade = id };
			var extra = _extrasContext.Get(ind);

			if (extra == null)
				return NotFound();

			return extra;
		}

		[HttpPost]
		public ActionResult<ExtrasDaEscola> PostExtra(ExtrasDaEscola extra)
		{
			_extrasContext.Upsert(extra.ID, extra);

			return CreatedAtRoute("GetExtra", new { id = extra.ID, extra });
		}

		[HttpPut]
		public IActionResult PutExtra(ExtrasDaEscola extra)
		{
			var ex = _extrasContext.Get(extra.ID);

			if (ex == null)
			{
				return NotFound();
			}

			_extrasContext.Upsert(extra.ID, extra);

			return NoContent();
		}

		[HttpDelete("{ano}/{cod}")]
		public IActionResult DeleteExtra(short ano, long id)
		{
			Indexer ind = new Indexer { Ano = ano, Cod_Entidade = id };
			var extra = _extrasContext.Get(ind);

			if (extra == null)
				return NotFound();

			_extrasContext.Remove(extra.ID);

			return NoContent();
		}
	}
}
