using Mohemby_API.Modelos;

namespace Mohemby_API.Services;

public class MedicoService: IMedicoService
{
    Contexto _context;

    public MedicoService (Contexto context)
    {
        _context = context;
    }

    public IEnumerable<Medico> Get()
    {
        return _context.Medicos;
    }

    public Medico GetMedico (int id)
    {
        var medico = _context.Medicos.Find(id);
        return medico;
    }

    public void save (Medico medico)
    {
        _context.Add(medico);
        _context.SaveChanges();
    }

    public void update (int id, Medico medico)
    {
        var medicoAct = _context.Medicos.Find(id);

        if (medicoAct != null)
        {
            medicoAct.nombre = medico.nombre;
            medicoAct.domicilio = medico.domicilio;
            medicoAct.telFijo = medico.telFijo;
            medicoAct.telCel = medico.telCel;
            medicoAct.baja = medico.baja;
            medicoAct.firma = medico.firma;
            medicoAct.esEspecialista = medico.esEspecialista;
            medicoAct.consultorio = medico.consultorio;
            medicoAct.matricula = medico.matricula;
            medicoAct.esGuardia = medico.esGuardia;

            _context.SaveChanges();
        }
    }

    public void Delete (int id)
    {
        var medicoAct = _context.Medicos.Find(id);

        if (medicoAct != null)
        {
            _context.Remove(medicoAct);
            _context.SaveChanges();
        }
    }
}

public interface IMedicoService
{
    IEnumerable<Medico> Get();
    Medico GetMedico(int id);
    void save (Medico medico);
    void update (int id, Medico medico);
    void Delete (int id);
}