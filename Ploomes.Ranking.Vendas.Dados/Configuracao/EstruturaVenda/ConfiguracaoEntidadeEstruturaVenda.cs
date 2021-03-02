
using Microsoft.EntityFrameworkCore;
using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaVenda;

namespace Ploomes.Ranking.Vendas.Dados.Configuracao.EstruturaVenda
{
    public class ConfiguracaoEntidadeEstruturaVenda 
    {
        public ModelBuilder RetornaModelagemAtualizada(ModelBuilder construtorModelo)
        {
            construtorModelo = ConfiguraVendedorHistorico(
                construtorModelo);

            construtorModelo = ConfiguraErrosVendedorHistorico(
                construtorModelo);

            return construtorModelo;
        }


        private ModelBuilder ConfiguraVendedorHistorico(ModelBuilder construtorModelo)
        {
            construtorModelo.Entity<VendedorHistorico>(etd =>
            {
                etd.Property(c => c.Id).ValueGeneratedOnAdd()
                   .IsRequired();

                etd.Property(c => c.Nome).HasMaxLength(50);
                etd.Property(c => c.Codigo).HasMaxLength(50);
                etd.Property(c => c.CodigoCliente).HasMaxLength(50);
                etd.Property(c => c.NomeCliente).HasMaxLength(100);
                etd.Property(c => c.CodigoVendedor).HasMaxLength(50);
                etd.Property(c => c.NomeVendedor).HasMaxLength(100);
                etd.Property(c => c.CodigoSku).HasMaxLength(50);
                etd.Property(c => c.NomeSku).HasMaxLength(100);

                etd.HasOne(p => p.Usuario)
                .WithMany(c => c.ListaVendedorHistorico)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired();
            });

            return construtorModelo;
        }

        private ModelBuilder ConfiguraErrosVendedorHistorico(ModelBuilder construtorModelo)
        {
            construtorModelo.Entity<ErrosVendedorHistorico>(etd =>
            {
                etd.Property(c => c.Id).ValueGeneratedOnAdd()
                   .IsRequired();

                etd.Property(c => c.Nome).HasMaxLength(50);
                etd.Property(c => c.Codigo).HasMaxLength(50);
                etd.Property(c => c.Mensagem).HasMaxLength(500);

                etd.HasOne(p => p.Usuario)
                .WithMany(c => c.ListaErrosVendedorHistorico)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired();
            });

            return construtorModelo;
        }
    }
}
