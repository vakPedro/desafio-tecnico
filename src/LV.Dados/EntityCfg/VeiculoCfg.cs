using LV.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace LV.Dados.EntityCfg
{
    class VeiculoCfg : EntityTypeConfiguration<Veiculo>
    {

        public VeiculoCfg()
        {
            HasKey(v => v.Id);
            
            Property(v => v.Fabricante).IsRequired();
            Property(v => v.Modelo).IsRequired();
            Property(v => v.Categoria).IsRequired();
            Property(v => v.Valor).IsRequired();
            Property(v => v.ValorFds).IsRequired();
            Property(v => v.ValorFidelidade).IsRequired();
            Property(v => v.ValorFidelidadeFds).IsRequired();
        }

    }
}
