using System.Data.Entity;

namespace MovieCatalog
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("MovieDB")
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
