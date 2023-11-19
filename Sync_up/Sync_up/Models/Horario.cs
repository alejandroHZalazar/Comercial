using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync_up.Models
{
    class Horario
    {
        public int id { get; set; }
        public string? dia { get; set; }
        public DateTime horario { get; set; }
        public int? fk_medico { get; set; }
        public bool? cancelado { get; set; }
        public string? consultorio { get; set; }
        public bool? baja { get; set; }
        public bool? sobreTurno { get; set; }
    }
}
