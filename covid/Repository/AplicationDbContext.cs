using Microsoft.EntityFrameworkCore;
using Model;
using Model.MasterModel;
using Model.People;
using Persistence.Configuration;
using Repository.Configuration;
using System;

namespace Repository
{
    public class AplicationDbContext: DbContext
    {
        //Inicializa la cadena conexión mediante el constructor
        public AplicationDbContext(
            DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }


        //DBSET
        public DbSet<Person> People { get; set; }
        public DbSet<Dna> Dna { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<DnaPeople> DnaPeople { get; set; }


        //Inyectamos las configuraciones
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);//Crea su compotamiento por defecto

            //            builder.HasDefaultSchema("dbo"); //Esquema de la base de datos, ej. dbo.Tabla
            ModelConfig(builder);
           
        }

        private void ModelConfig(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new PeopleConfiguration());
            builder.ApplyConfiguration(new DnaConfiguration());
            builder.ApplyConfiguration(new CountriesConfiguration());
            builder.ApplyConfiguration(new ResultsConfigurations());

            new DnaPeopleConfiguration(builder.Entity<DnaPeople>());


        }

    }
}
