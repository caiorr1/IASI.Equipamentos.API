using IASI.Equipamentos.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IASI.Equipamentos.Domain.Entities
{
    public class EquipamentoEntity : CommonEntity
    {
        public string NomeEquipamento { get; set; }
        public string TipoEquipamento { get; set; }
        public string LocalizacaoEquipamento { get; set; }
        public DateTime DataInstalacaoEquipamento { get; set; }
        public string EstadoEquipamento { get; set; }

        public ICollection<Previsao>? Previsoes { get; set; }
        public ICollection<Consumo>? Consumos { get; set; }
        public ICollection<Manutencao>? Manutencoes { get; set; }
        public ICollection<Residuo>? Residuos { get; set; }
    }
}
