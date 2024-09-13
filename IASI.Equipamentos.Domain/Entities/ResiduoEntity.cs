using IASI.Equipamentos.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IASI.Equipamentos.Domain.Entities
{
    public class ResiduoEntity : CommonEntity
    {
        public int IdEquipamento { get; set; }
        public string TipoResiduo { get; set; }
        public float QuantidadeResiduo { get; set; }
        public DateTime DataGeracaoResiduo { get; set; }
        public string DestinoFinalResiduo { get; set; }

        public Equipamento? Equipamento { get; set; }
    }
}
