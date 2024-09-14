using IASI.Equipamentos.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IASI.Equipamentos.Domain.Entities
{
    [Table("tb_iasi_equipamentos_previsao")]
    public class Previsao : CommonEntity
    {
        [Key]
        [Column("id_previsao")]
        public override int Id { get; set; }

        [Column("id_equipamento")]
        public int IdEquipamento { get; set; }

        [Column("data_previsao")]
        public DateTime? DataPrevisao { get; set; }

        [Column("tipo_previsao")]
        public string TipoPrevisao { get; set; } = string.Empty;

        [Column("descricao_previsao")]
        public string DescricaoPrevisao { get; set; } = string.Empty;

        [Column("probabilidade_previsao")]
        public float? ProbabilidadePrevisao { get; set; }

        [ForeignKey("IdEquipamento")]
        public Equipamento? Equipamento { get; set; }
    }
}
