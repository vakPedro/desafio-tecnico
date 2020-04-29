using LV.Dados.EntityCfg;
using LV.Dominio.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LV.Dados.Contexto
{
    public class LocadoraVeiculoContexto : DbContext
    {
        public LocadoraVeiculoContexto() : base("strConexao")
        {
        }

        public DbSet<Veiculo> Veiculo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.Name == "Id").Configure(p => p.IsKey());
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(50));

            modelBuilder.Configurations.Add(new VeiculoCfg());

            base.OnModelCreating(modelBuilder);
        }
    }
}
