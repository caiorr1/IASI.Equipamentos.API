using IASI.Equipamentos.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IASI.Equipamentos.Domain.Entities
{
    [Table("tb_iasi_equipamentos_residuo")]
    public class Residuo : CommonEntity
    {
        [Key]
        [Column("id_residuo")]
        public override int Id { get; set; }

        [Column("id_equipamento")]
        public int IdEquipamento { get; set; }

        [Column("tipo_residuo")]
        public string TipoResiduo { get; set; } = string.Empty;

        [Column("quantidade_residuo")]
        public float? QuantidadeResiduo { get; set; }

        [Column("data_geracao_residuo")]
        public DateTime? DataGeracaoResiduo { get; set; }

        [Column("destino_final_residuo")]
        public string DestinoFinalResiduo { get; set; } = string.Empty;

        [ForeignKey("IdEquipamento")]
        public Equipamento? Equipamento { get; set; }
    }
}
