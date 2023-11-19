using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync_up.Models
{
    class Medico_especialidad
    {
        public int? id { get; set; }
        public long? fk_medico { get; set; }
        public long? fk_especialidad { get; set; }
    }
}
