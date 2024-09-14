using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IASI.Equipamentos.Domain.Common
{
    public abstract class CommonEntity
    {
        [Key]
        [Column("id")]
        public virtual int Id { get; set; } // A propriedade Id pode ser sobrescrita pelas entidades derivadas.

        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow; // Data de criação padrão para a data e hora atual UTC.

        [Column("data_atualizacao")]
        public DateTime? DataAtualizacao { get; set; } // Propriedade nullable para a data de atualização.
    }
}
