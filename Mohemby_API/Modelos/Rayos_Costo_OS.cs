using System.ComponentModel.DataAnnotations;
namespace Mohemby_API.Modelos;

public class Rayos_Costo_OS
{
    [Key]
    public int id { get; set; }
    public int fk_obraSocial { get; set; }
    public string descripcion { get; set; }
    public decimal importe { get; set; }
    public decimal importeEME { get; set; }
    public string codigoOS { get; set; }
    public string tipo { get; set; }
    public bool baja { get; set; }
    public decimal coseguro { get; set; }
}