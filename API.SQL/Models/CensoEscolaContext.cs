using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.SQL.Models
{
	public class CensoEscolaContext : DbContext
	{
		public CensoEscolaContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<CensoEscola> CensosEscolas { get; set; }

		public override EntityEntry<CensoEscola> Add<CensoEscola>(CensoEscola entity)
		{
			return base.Add(entity);
		}

		public override ValueTask<EntityEntry<CensoEscola>> AddAsync<CensoEscola>(CensoEscola entity, CancellationToken cancellationToken = default)
		{
			return base.AddAsync(entity, cancellationToken);
		}

		public override ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default)
		{
			return base.AddAsync(entity, cancellationToken);
		}

		public override void AddRange(params object[] entities)
		{
			base.AddRange(entities);
		}

		public override void AddRange(IEnumerable<object> entities)
		{
			base.AddRange(entities);
		}

		public override Task AddRangeAsync(params object[] entities)
		{
			return base.AddRangeAsync(entities);
		}

		public override Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default)
		{
			return base.AddRangeAsync(entities, cancellationToken);
		}

		public override void AttachRange(IEnumerable<object> entities)
		{
			base.AttachRange(entities);
		}

		public override object Find(Type entityType, params object[] keyValues)
		{
			return base.Find(entityType, keyValues);
		}

		public override CensoEscola Find<CensoEscola>(params object[] keyValues)
		{
			return base.Find<CensoEscola>(keyValues);
		}

		public override ValueTask<object> FindAsync(Type entityType, params object[] keyValues)
		{
			return base.FindAsync(entityType, keyValues);
		}

		public override ValueTask<object> FindAsync(Type entityType, object[] keyValues, CancellationToken cancellationToken)
		{
			return base.FindAsync(entityType, keyValues, cancellationToken);
		}

		public override ValueTask<CensoEscola> FindAsync<CensoEscola>(params object[] keyValues)
		{
			return base.FindAsync<CensoEscola>(keyValues);
		}

		public override ValueTask<CensoEscola> FindAsync<CensoEscola>(object[] keyValues, CancellationToken cancellationToken)
		{
			return base.FindAsync<CensoEscola>(keyValues, cancellationToken);
		}

		public override EntityEntry<CensoEscola> Remove<CensoEscola>(CensoEscola entity)
		{
			return base.Remove(entity);
		}

		public override EntityEntry Remove(object entity)
		{
			return base.Remove(entity);
		}

		public override void RemoveRange(params object[] entities)
		{
			base.RemoveRange(entities);
		}

		public override void RemoveRange(IEnumerable<object> entities)
		{
			base.RemoveRange(entities);
		}

		public override DbSet<CensoEscola> Set<CensoEscola>()
		{
			return base.Set<CensoEscola>();
		}

		public override EntityEntry<CensoEscola> Update<CensoEscola>(CensoEscola entity)
		{
			return base.Update(entity);
		}

		public override EntityEntry Update(object entity)
		{
			return base.Update(entity);
		}

		public override void UpdateRange(params object[] entities)
		{
			base.UpdateRange(entities);
		}

		public override void UpdateRange(IEnumerable<object> entities)
		{
			base.UpdateRange(entities);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CensoEscola>()
				.HasOne(c => new { c.Ano, c.CodEntidade }).WithMany().HasForeignKey();
		}

	}
}
