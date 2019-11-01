using MongoDB.Driver;
using SharedLibrary.Entities.Custom;
using System.Collections.Generic;
using static SharedLibrary.Entities.Custom.ExtrasDaEscola;

namespace SharedLibrary.Context.Custom
{
	public class ExtrasDaEscolaContext
	{
		private readonly IMongoCollection<ExtrasDaEscola> _extras;

		public ExtrasDaEscolaContext(IMongoDBSettings settings)
		{
			var client = new MongoClient(settings.CollectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_extras = database.GetCollection<ExtrasDaEscola>(settings.ExtrasCollectionName);
		}

		public List<ExtrasDaEscola> Get() =>
			_extras.Find(extra => true).ToList();
		public ExtrasDaEscola Get(Indexer id) =>
			_extras.Find<ExtrasDaEscola>(extra => extra.ID == id).FirstOrDefault();
		public void Upsert(Indexer iD, ExtrasDaEscola extraNovo) =>
			_extras.ReplaceOne(extra => extra.ID == extraNovo.ID, extraNovo, new UpdateOptions { IsUpsert = true });
		public void Remove(ExtrasDaEscola extraIn) =>
			_extras.DeleteOne(extra => extra.ID == extraIn.ID);
		public void Remove(Indexer extraId) =>
			_extras.DeleteOne(extra => extra.ID == extraId);
	}
}
