
using System;

namespace Ploomes.Ranking.Vendas.Dominio.Entidades.Base
{
    public class Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public bool Ativo { get; set; }
    }
}
