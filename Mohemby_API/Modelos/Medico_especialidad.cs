using System.ComponentModel.DataAnnotations;
namespace Mohemby_API.Modelos;

public class Medico_especialidad
{
     [Key]
    public int id { get; set; }
    public long fk_medico { get; set; }
    public long fk_especialidad { get; set; }
}