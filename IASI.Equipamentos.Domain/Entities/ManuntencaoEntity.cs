using IASI.Equipamentos.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IASI.Equipamentos.Domain.Entities
{
    public class ManuntencaoEntity : CommonEntity
    {
        public int IdEquipamento { get; set; }
        public string TipoManutencao { get; set; }
        public DateTime DataManutencao { get; set; }
        public string DescricaoManutencao { get; set; }

        public Equipamento? Equipamento { get; set; }
    }
}
