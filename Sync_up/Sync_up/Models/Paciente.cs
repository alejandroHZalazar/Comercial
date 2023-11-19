using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync_up.Models
{
    class Paciente
    {
        public long? id { get; set; }
        public string? nombre { get; set; }
        public DateTime? fechaNac { get; set; }
        public int? fk_tipoDoc { get; set; }
        public long? nroDocumento { get; set; }
        public long? cuil { get; set; }
        public DateTime? fechaAlta { get; set; }
        public DateTime? fechaBaja { get; set; }
        public string? calle { get; set; }
        public string? numeroCalle { get; set; }
        public string? entreCalle { get; set; }
        public string? ycalle { get; set; }
        public string? piso { get; set; }
        public string? dpto { get; set; }
        public string? casa { get; set; }
        public string? lote { get; set; }
        public string? mz { get; set; }
        public string? pc { get; set; }
        public string? block { get; set; }
        public string? qta { get; set; }
        public string? uf { get; set; }
        public string? etapa { get; set; }
        public string? torre { get; set; }
        public string? tira { get; set; }
        public string? chacra { get; set; }
        public int? fk_barrio { get; set; }
        public int? radioGeografico { get; set; }
        public string? telFijo { get; set; }
        public string? telCelular { get; set; }
        public string? email { get; set; }
        public bool? esSocio { get; set; }
        public bool? baja { get; set; }
        public int? fk_obraSocial { get; set; }
        public int? fk_condicionIVA { get; set; }
        public string? cuit { get; set; }
        public int? nroAfiliado { get; set; }
        public long? fk_grupo { get; set; }
        public int? fk_pais { get; set; }
        public int? fk_provincia { get; set; }
        public int? fk_localidad { get; set; }
        public string? nroAfiliadoOS { get; set; }
        public string? sexo { get; set; }
    }
}
