using Mohemby_API.Modelos;

namespace Mohemby_API.Services;
public class Inactivismo_medicoService: IInactivismo_medicoService
{
    Contexto _context;

    public Inactivismo_medicoService (Contexto contexto)
    {
        _context = contexto;
    }

    public IEnumerable<Inactivismo_medico> Get()
    {
        return _context.Inactivismo_Medicos;
    }

    public Inactivismo_medico GetInactivismo_Medico(int id)
    {
        var inactivismo = _context.Inactivismo_Medicos.Find(id);
        return inactivismo;
    }

    public void Save(Inactivismo_medico inactivismo_Medico)
    {
        _context.Add(inactivismo_Medico);
        _context.SaveChanges();
    }

    public void Update(int id, Inactivismo_medico inactivismo_Medico)
    {
        var inactivismo_medicoAct = _context.Inactivismo_Medicos.Find(id);

        if (inactivismo_medicoAct != null)
        {
            inactivismo_medicoAct.fk_medico = inactivismo_Medico.fk_medico;
            inactivismo_medicoAct.fecha_inicio = inactivismo_Medico.fecha_inicio ;
            inactivismo_medicoAct.fecha_fin = inactivismo_Medico.fecha_fin;
            inactivismo_medicoAct.terminado = inactivismo_Medico.terminado;

            _context.SaveChanges();
        }
    }

    public void Delete (int id)
    {
        var inactivismo_medicoAct = _context.Inactivismo_Medicos.Find(id);

        if (inactivismo_medicoAct != null)
        {
            _context.Remove(inactivismo_medicoAct);
            _context.SaveChanges();
        }
    }
}

public interface IInactivismo_medicoService
{
     IEnumerable<Inactivismo_medico> Get();
    Inactivismo_medico GetInactivismo_Medico(int id);
    void Save(Inactivismo_medico inactivismo_Medico);
    void Update(int id, Inactivismo_medico inactivismo_Medico);
    void Delete(int id);
}