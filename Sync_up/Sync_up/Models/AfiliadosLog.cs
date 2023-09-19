using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync_up.Models
{
    class AfiliadosLog
    {
        public int idLog { get; set; }
        public long id { get; set; }
        public long fk_grupo { get; set; }
        public long nro { get; set; }
        public string nombre { get; set; }
        public DateTime fechaNac { get; set; }
        public long nroDocumento { get; set; }

        public DateTime fechaAlta { get; set; }
        public DateTime? fechaBaja { get; set; }
        public bool baja { get; set; }
        public string calle { get; set; }
        public string telCelular { get; set; }
        public string email { get; set; }
        public bool abusador { get; set; }
        public DateTime modifiedDate { get; set; }
        public string editType { get; set; }

        public bool procesado { get; set; }
    }
}
