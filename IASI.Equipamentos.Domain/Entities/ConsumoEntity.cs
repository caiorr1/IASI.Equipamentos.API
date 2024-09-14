using IASI.Equipamentos.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IASI.Equipamentos.Domain.Entities
{
    [Table("tb_iasi_equipamentos_consumo")]
    public class Consumo : CommonEntity
    {
        [Key]
        [Column("id_consumo")]
        public override int Id { get; set; }

        [Column("id_equipamento")]
        public int IdEquipamento { get; set; }

        [Column("data_consumo")]
        public DateTime? DataConsumo { get; set; }

        [Column("quantidade_consumo")]
        public float? QuantidadeConsumo { get; set; }

        [Column("tipo_energia_consumo")]
        public string TipoEnergiaConsumo { get; set; } = string.Empty;

        [Column("emissao_gas_consumo")]
        public float? EmissaoGasConsumo { get; set; }

        [ForeignKey("IdEquipamento")]
        public Equipamento? Equipamento { get; set; }
    }
}
