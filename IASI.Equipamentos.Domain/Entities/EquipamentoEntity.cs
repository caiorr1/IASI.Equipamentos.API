using IASI.Equipamentos.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IASI.Equipamentos.Domain.Entities
{
    [Table("tb_iasi_equipamentos_equipamento")]
    public class Equipamento : CommonEntity
    {
        [Key]
        [Column("id_equipamento")]
        public override int Id { get; set; }

        [Column("nome_equipamento")]
        public string NomeEquipamento { get; set; } = string.Empty;

        [Column("tipo_equipamento")]
        public string TipoEquipamento { get; set; } = string.Empty;

        [Column("localizacao_equipamento")]
        public string LocalizacaoEquipamento { get; set; } = string.Empty;

        [Column("data_instalacao_equipamento")]
        public DateTime? DataInstalacaoEquipamento { get; set; }

        [Column("estado_equipamento")]
        public string EstadoEquipamento { get; set; } = string.Empty;

        public ICollection<Previsao>? Previsoes { get; set; }
        public ICollection<Consumo>? Consumos { get; set; }
        public ICollection<Manutencao>? Manutencoes { get; set; }
        public ICollection<Residuo>? Residuos { get; set; }
    }
}
