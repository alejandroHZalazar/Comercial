using System.ComponentModel.DataAnnotations;
namespace Mohemby_API.Modelos;

public class pol_Costo
{
    [Key]
    public int id { get; set; }
    public string obraSocial { get; set; }
    public decimal coef { get; set; }
    public bool baja { get; set; }
    public int fk_tipo_obraSocial { get; set; }
    public bool esOS { get; set; }
}