using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync_up.Models
{
    class Especialidad
    {
        public int? id { get; set; }

        public string? nombre { get; set; }

        public string? tipo { get; set; }

        public bool? baja { get; set; }
        public bool? esEspecialidad { get; set; }
        public bool? esGuardia { get; set; }
    }
}
