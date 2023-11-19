using Mohemby_API.Modelos;

namespace Mohemby_API.Services;

public class PacienteService: IPacienteService
{
    Contexto _context;

    public PacienteService (Contexto contexto)
    {
        _context = contexto;
    }

    public IEnumerable<Paciente> Get()
    {
        return _context.Pacientes;
    }

    public Paciente GetPaciente(long id)
    {
        var paciente = _context.Pacientes.Find(id);
        return paciente;
    }

    public void Save (Paciente paciente)
    {
        _context.Add(paciente);
        _context.SaveChanges();
    }

    public void Update (long id, Paciente paciente)
    {
        var PacienteAct = _context.Pacientes.Find(id);

        if (PacienteAct != null)
        {
            PacienteAct.nombre = paciente.nombre;
            PacienteAct.fechaNac = paciente.fechaNac;
            PacienteAct.fk_tipoDoc = paciente.fk_tipoDoc;
            PacienteAct.nroDocumento = paciente.nroDocumento;
            PacienteAct.cuil = paciente.cuil;
            PacienteAct.fechaAlta = paciente.fechaAlta;
            PacienteAct.fechaBaja = paciente.fechaBaja;
            PacienteAct.calle = paciente.calle;
            PacienteAct.numeroCalle = paciente.numeroCalle;
            PacienteAct.entreCalle = paciente.entreCalle;
            PacienteAct.ycalle = paciente.ycalle;
            PacienteAct.piso = paciente.piso;
            PacienteAct.dpto = paciente.dpto;
            PacienteAct.casa = paciente.casa;
            PacienteAct.lote = paciente.lote;
            PacienteAct.mz = paciente.mz;
            PacienteAct.pc = paciente.pc;
            PacienteAct.block = paciente.block;
            PacienteAct.qta = paciente.qta;
            PacienteAct.uf = paciente.uf;
            PacienteAct.etapa = paciente.etapa;
            PacienteAct.torre = paciente.torre;
            PacienteAct.tira = paciente.tira;
            PacienteAct.chacra = paciente.chacra;
            PacienteAct.fk_barrio = paciente.fk_barrio;
            PacienteAct.radioGeografico = paciente.radioGeografico;
            PacienteAct.telFijo = paciente.telFijo;
            PacienteAct.telCelular = paciente.telCelular;
            PacienteAct.email = paciente.email;
            PacienteAct.esSocio = paciente.esSocio;
            PacienteAct.baja = paciente.baja;
            PacienteAct.fk_obraSocial = paciente.fk_obraSocial;
            PacienteAct.fk_condicionIVA = paciente.fk_condicionIVA;
            PacienteAct.cuit = paciente.cuit;
            PacienteAct.nroAfiliado = paciente.nroAfiliado;
            PacienteAct.fk_grupo = paciente.fk_grupo;
            PacienteAct.fk_pais = paciente.fk_pais;
            PacienteAct.fk_provincia = paciente.fk_provincia;
            PacienteAct.fk_localidad = paciente.fk_localidad;
            PacienteAct.nroAfiliadoOS = paciente.nroAfiliadoOS;
            PacienteAct.sexo = paciente.sexo;
        }
    }

    public void Delete (long id)
    {
        var PacienteAct = _context.Pacientes.Find(id);

        if (PacienteAct != null)
        {
            _context.Remove(PacienteAct);
            _context.SaveChanges();
        }
    }
}

public interface IPacienteService
{
    IEnumerable<Paciente> Get();
    Paciente GetPaciente(long id);
    void Save(Paciente paciente);
    void Update(long id, Paciente paciente);
    void Delete (long id);
}