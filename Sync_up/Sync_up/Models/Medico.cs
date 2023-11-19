using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync_up.Models
{
    class Medico
    {
        public int? id { get; set; }
        public string? nombre { get; set; }
        public string? domicilio { get; set; }
        public string? telFijo { get; set; }
        public string? telCel { get; set; }
        public bool? baja { get; set; }
        public Byte[]? firma { get; set; }
        public bool? esEspecialista { get; set; }
        public string? consultorio { get; set; }
        public string? matricula { get; set; }
        public bool? esGuardia { get; set; }
    }
}
