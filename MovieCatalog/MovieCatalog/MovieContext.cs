using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
