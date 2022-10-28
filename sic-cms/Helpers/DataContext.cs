using Microsoft.EntityFrameworkCore;
using sic_cms.Entities;

namespace sic_cms.Helpers {
    // herdo de dbContext que é um pacote
    public class DataContext : DbContext {
        
        // configuração basica do dataContext com o DbContextOptions
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Menu> Menu { get; set; }

        public DbSet<Recurso> Recurso { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Recurso>(entity => {
                entity.HasKey(e => e.Codigo)
                  .HasName("PK_Recurso_1");
            });


        }







    }
}