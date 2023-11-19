using System.ComponentModel.DataAnnotations;
namespace Mohemby_API.Modelos;
using System.ComponentModel;

public class Horario
{
    [Key]
    public int id { get; set; }
    public string? dia { get; set; }
    public DateTime horario { get; set; }
    public int? fk_medico { get; set; }
    public bool? cancelado { get; set; }
    [DefaultValue("")] 
    public string? consultorio { get; set; } = "";
    public bool? baja { get; set; }
    public bool? sobreTurno { get; set; }
}