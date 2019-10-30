using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Context.Custom;
using SharedLibrary.Entities.Custom;
using System.Collections.Generic;
using static SharedLibrary.Entities.Custom.ExtrasDaEscola;

namespace API.Mongo.Controllers
{
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

		[HttpGet("id:{a:1,b:2}", Name = "GetExtra")]
		public ActionResult<ExtrasDaEscola> Get(Indexer id)
		{
			var extra = _extrasContext.Get(id);

			if (extra == null)
				return NotFound();

			return extra;
		}

		[HttpPost]
		public ActionResult<ExtrasDaEscola> Create(ExtrasDaEscola extra)
		{
			_extrasContext.Upsert(extra);

			return CreatedAtRoute("GetExtra", new { id = extra.ID, extra });
		}

		[HttpPut]
		public IActionResult Update(ExtrasDaEscola extra)
		{
			var ex = _extrasContext.Get(extra.ID);

			if (ex == null)
			{
				return NotFound();
			}

			_extrasContext.Upsert(extra.ID, extra);

			return NoContent();
		}

		[HttpDelete]
		public IActionResult Delete(Indexer id)
		{
			var extra = _extrasContext.Get(id);

			if (extra == null)
				return NotFound();

			_extrasContext.Remove(extra.ID);

			return NoContent();
		}
	}
}
