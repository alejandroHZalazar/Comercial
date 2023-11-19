using System.ComponentModel.DataAnnotations;
namespace Mohemby_API.Modelos;

public class Inactivismo_medico
{
     [Key]
    public int id { get; set; }
    public int fk_medico { get; set; }
    public DateOnly fecha_inicio { get; set; }
    public DateOnly fecha_fin { get; set; }
    public bool terminado { get; set; }

}