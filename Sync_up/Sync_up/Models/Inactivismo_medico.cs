using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync_up.Models
{
    class Inactivismo_medico
    {
        public int id { get; set; }
        public int? fk_medico { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public bool? terminado { get; set; }
    }
}
