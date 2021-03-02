using Microsoft.EntityFrameworkCore;
using Ploomes.Ranking.Vendas.Dominio.Entidades.EstruturaTabela;

namespace Ploomes.Ranking.Vendas.Dados.Configuracao.EstruturaTabela
{
    public class ConfiguracaoEntidadeEstruturaTabela
    {
        public ModelBuilder RetornaModelagemAtualizada(ModelBuilder construtorModelo)
        {
            construtorModelo = ConfiguraTabela(
                construtorModelo);

            construtorModelo = ConfiguraTabelaColuna(
                construtorModelo);

            return construtorModelo;
        }


        private ModelBuilder ConfiguraTabela(ModelBuilder construtorModelo)
        {
            construtorModelo.Entity<Tabela>(etd =>
            {
                etd.Property(c => c.Id).ValueGeneratedOnAdd()
                   .IsRequired();

                etd.Property(c => c.Nome).HasMaxLength(50);
                etd.Property(c => c.Codigo).HasMaxLength(50);
      
            });

            return construtorModelo;
        }

        private ModelBuilder ConfiguraTabelaColuna(ModelBuilder construtorModelo)
        {
            construtorModelo.Entity<TabelaColuna>(etd =>
            {
                etd.Property(c => c.Id).ValueGeneratedOnAdd()
                   .IsRequired();

                etd.Property(c => c.Nome).HasMaxLength(50);
                etd.Property(c => c.Codigo).HasMaxLength(50);
                etd.Property(c => c.TipoCampo).HasMaxLength(50);

                etd.HasOne(p => p.Tabela)
                .WithMany(c => c.ListaTabelaColuna)
                .HasForeignKey(d => d.TabelaId)
                .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired();
            });

            return construtorModelo;
        }
    }
}
