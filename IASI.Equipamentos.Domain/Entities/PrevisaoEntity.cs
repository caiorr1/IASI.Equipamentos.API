using IASI.Equipamentos.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IASI.Equipamentos.Domain.Entities
{
    public class PrevisaoEntity : CommonEntity
    {
        public int IdEquipamento { get; set; }
        public DateTime DataPrevisao { get; set; }
        public string TipoPrevisao { get; set; }
        public string DescricaoPrevisao { get; set; }
        public float ProbabilidadePrevisao { get; set; }

        public Equipamento? Equipamento { get; set; }
    }
}
