using IASI.Equipamentos.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IASI.Equipamentos.Domain.Entities
{
    public class ConsumoEntity : CommonEntity
    {
        public int IdEquipamento { get; set; }
        public DateTime DataConsumo { get; set; }
        public float QuantidadeConsumo { get; set; }
        public string TipoEnergiaConsumo { get; set; }
        public float EmissaoGasConsumo { get; set; }

        public Equipamento? Equipamento { get; set; }
    }
}
