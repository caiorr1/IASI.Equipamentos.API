using IASI.Equipamentos.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IASI.Equipamentos.Domain.Entities
{
    [Table("tb_iasi_equipamentos_manutencao")]
    public class Manutencao : CommonEntity
    {
        [Key]
        [Column("id_manutencao")]
        public override int Id { get; set; }

        [Column("id_equipamento")]
        public int IdEquipamento { get; set; }

        [Column("tipo_manutencao")]
        public string TipoManutencao { get; set; } = string.Empty;

        [Column("data_manutencao")]
        public DateTime? DataManutencao { get; set; }

        [Column("descricao_manutencao")]
        public string DescricaoManutencao { get; set; } = string.Empty;

        [ForeignKey("IdEquipamento")]
        public Equipamento? Equipamento { get; set; }
    }
}
