using Mohemby_API.Modelos;

namespace Mohemby_API.Services;

public class Medico_especialidadService: IMedico_especialidadService
{
    Contexto _context;

    public Medico_especialidadService (Contexto contexto)
    {
        _context = contexto;
    }

    public IEnumerable<Medico_especialidad> Get()
    {
        return _context.Medico_Especialidades;
    }

    public Medico_especialidad GetMedico_Especialidad(int id)
    {
        var medico_especialidad = _context.Medico_Especialidades.Find(id);
        return medico_especialidad;
    }

    public void Save(Medico_especialidad medico_Especialidad)
    {
        _context.Add(medico_Especialidad);
        _context.SaveChanges();
    }

    public void Update(int id, Medico_especialidad medico_Especialidad)
    {
        var medico_EspecialidadAct = _context.Medico_Especialidades.Find(id);

        if (medico_EspecialidadAct != null)
        {
            medico_EspecialidadAct.fk_medico = medico_Especialidad.fk_medico;
            medico_EspecialidadAct.fk_especialidad = medico_Especialidad.fk_especialidad ;
            
            _context.SaveChanges();
        }
    }

     public void Delete (int id)
    {
        var medico_EspecialidadAct = _context.Medico_Especialidades.Find(id);

        if (medico_EspecialidadAct != null)
        {
            _context.Remove(medico_EspecialidadAct);
            _context.SaveChanges();
        }
    }
}

public interface IMedico_especialidadService
{
     IEnumerable<Medico_especialidad> Get();
    Medico_especialidad GetMedico_Especialidad(int id);
    void Save(Medico_especialidad medico_Especialidad);
    void Update(int id, Medico_especialidad medico_Especialidad);
    void Delete(int id);
}