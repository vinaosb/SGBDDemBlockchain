namespace SharedLibrary.Context.Custom
{
	public class MongoDBSettings : IMongoDBSettings
	{
		public string ExtrasCollectionName { get; set; }
		public string CollectionString { get; set; }
		public string DatabaseName { get; set; }
	}
	public interface IMongoDBSettings
	{
		public string ExtrasCollectionName { get; set; }
		public string CollectionString { get; set; }
		public string DatabaseName { get; set; }
	}
}
