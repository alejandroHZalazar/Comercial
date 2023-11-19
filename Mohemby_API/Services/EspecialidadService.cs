using Mohemby_API.Modelos;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Mohemby_API.Services;

public class EspecialidadService : IEspecialidadService 
{
    Contexto _context;

    public EspecialidadService (Contexto context)
    {
        _context = context;
    }

    public IEnumerable<Especialidad> Get()
    {
        return _context.Especialidades;
    }

    public Especialidad GetEspecialidad (int id)
    {
        var especialidad = _context.Especialidades.Find(id);
        return especialidad;
    }

    public void Save (Especialidad especialidad)
    {
        _context.Add(especialidad);
        _context.SaveChanges();
    }

    public void Update (int id, Especialidad especialidad)
    {
        var especialidadAct = _context.Especialidades.Find(id);

        if (especialidadAct != null)
        {
            especialidadAct.nombre = especialidad.nombre;
            especialidadAct.tipo = especialidad.tipo;
            especialidadAct.baja = especialidad.baja;
            especialidadAct.esEspecialidad = especialidad.esEspecialidad;
            especialidadAct.esGuardia = especialidad.esGuardia;

            _context.SaveChanges();
        }
    }

    public void Delete (int id)
    {
        var especialidadAct = _context.Especialidades.Find(id);

        if (especialidadAct != null)
        {
            _context.Remove(especialidadAct);
            _context.SaveChanges();
        }
    }
}

public interface IEspecialidadService
{
    IEnumerable<Especialidad> Get();
    Especialidad GetEspecialidad (int id);
    void Save (Especialidad especialidad);
    void Update (int id, Especialidad especialidad);
    void Delete (int id);
}