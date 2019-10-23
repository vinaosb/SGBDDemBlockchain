using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharedLibrary;

namespace API.SQL.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SQLController : ControllerBase
	{
		class ContextoSQL : DbContext
		{
			public DbSet<CensoEscola> TabelaCensoEscola { get; set; }
			protected override void OnModelCreating(ModelBuilder modelBuilder)
			{
				modelBuilder.Entity<CensoEscola>()
					.HasKey(c => new { c.Ano, c.CodEntidade });
			}
		}

		private readonly ILogger<SQLController> _logger;

		public SQLController(ILogger<SQLController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
