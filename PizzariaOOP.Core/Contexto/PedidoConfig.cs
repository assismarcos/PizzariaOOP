using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzariaOOP.Core.Dominio;

namespace PizzariaOOP.Core.Contexto
{
    public class PedidoConfig : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
            builder.Property(x => x.Tamanho).IsRequired().HasColumnName("Tamanho");
            builder.Property(x => x.Sabor).IsRequired().HasColumnName("Sabor");
            builder.Property(x => x.Personalizacoes).HasColumnName("Personalizacoes");
            builder.Property(x => x.ValorTotal).IsRequired().HasColumnName("ValorTotal");
            builder.Property(x => x.TempoPreparo).IsRequired().HasColumnName("TempoPreparo");
        }
    }
}
