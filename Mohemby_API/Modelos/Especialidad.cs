using System.ComponentModel.DataAnnotations;
namespace Mohemby_API.Modelos;

public class Especialidad
{
    [Key]
    public int id { get; set; }

    public string? nombre { get; set; }

    public string? tipo { get; set; }

    public bool? baja { get; set; }
    public bool? esEspecialidad {get; set; }
    public bool? esGuardia {get; set; }
}