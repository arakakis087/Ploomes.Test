

using Microsoft.EntityFrameworkCore;
using Ploomes.Ranking.Vendas.Dominio.Entidades.Login;

namespace Ploomes.Ranking.Vendas.Dados.Configuracao.Login
{
    public class ConfiguracaoEntidadeLogin
    {
        public ModelBuilder RetornaModelagemAtualizada(ModelBuilder construtorModelo)
        {
            construtorModelo = ConfiguraPerfil(
                construtorModelo);

            construtorModelo = ConfiguraUsuario(
                construtorModelo);

            construtorModelo = ConfiguraLogUsuario(
                construtorModelo);

            return construtorModelo;
        }

        private ModelBuilder ConfiguraPerfil(ModelBuilder construtorModelo)
        {
            construtorModelo.Entity<Perfil>(etd =>
            {
                etd.Property(c => c.Id).ValueGeneratedOnAdd()
                   .IsRequired();

                etd.Property(c => c.Nome).HasMaxLength(50);
                etd.Property(c => c.Codigo).HasMaxLength(50);
            });

            return construtorModelo;
        }

        private ModelBuilder ConfiguraUsuario(ModelBuilder construtorModelo)
        {
            construtorModelo.Entity<Usuario>(etd =>
            {
                etd.Property(c => c.Id).ValueGeneratedOnAdd()
                   .IsRequired();

                etd.Property(c => c.Nome).HasMaxLength(50);
                etd.Property(c => c.Codigo).HasMaxLength(50);
                etd.Property(c => c.Token).HasMaxLength(300);

                etd.HasOne(p => p.Perfil)
                .WithMany(c => c.ListaUsuario)
                .HasForeignKey(d => d.PerfilId)
                .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired();
            });

            return construtorModelo;
        }

        private ModelBuilder ConfiguraLogUsuario(ModelBuilder construtorModelo)
        {
            construtorModelo.Entity<LogUsuario>(etd =>
            {
                etd.Property(c => c.Id).ValueGeneratedOnAdd()
                   .IsRequired();

                etd.Property(c => c.Nome).HasMaxLength(50);
                etd.Property(c => c.Codigo).HasMaxLength(50);
                etd.Property(c => c.Mensagem).HasMaxLength(300);

                etd.HasOne(p => p.Usuario)
                .WithMany(c => c.ListaLogAutenticacao)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired();
            });

            return construtorModelo;
        }
    }
}
