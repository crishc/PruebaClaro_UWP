using Microsoft.EntityFrameworkCore;
using PruebaClaro_UWP.Model.Data.SQLite.Entities;

namespace PruebaClaro_UWP.Model.Data.SQLite
{
    public class DataContext : DbContext
    {
        public DbSet<Pelicula> Pelicula { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=ClaroVideo.db");
        }
    }
}