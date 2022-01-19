namespace Post.Query.Infrastructure.DataAccess
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly DatabaseContextFactory _contextFactory;

        public DatabaseInitializer(DatabaseContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void Seed()
        {
            using (DatabaseContext context = _contextFactory.CreateDbContext())
            {
                // First delete db if it already exists, and then create it again
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}