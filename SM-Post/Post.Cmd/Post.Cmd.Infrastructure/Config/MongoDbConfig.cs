namespace Post.Cmd.Infrastructure.Config
{
    public class MongoDbConfig
    {
        public MongoDbConfig(string connectionString, string database, string collection)
        {
            ConnectionString = connectionString;
            Database = database;
            Collection = collection;
        }

        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
    }
}