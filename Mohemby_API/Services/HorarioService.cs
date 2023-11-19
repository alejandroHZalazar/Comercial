using Mohemby_API.Modelos;

namespace Mohemby_API.Services;

public class HorarioService: IHorarioService
{
    Contexto _context;

    public HorarioService (Contexto context)
    {
        _context = context;
    }

        public IEnumerable<Horario> Get()
        {
            return _context.Horarios;
        }

        public Horario GetHorario(int id)
        {
            var horario = _context.Horarios.Find(id);
            return horario;
        }

        public void Save (Horario horario)
        {
            _context.Add(horario);
            _context.SaveChanges();
        }

        public void Update (int id, Horario horario)
        {
            var horarioAct = _context.Horarios.Find(id);

            if (horarioAct != null)
            {
                horarioAct.dia= horario.dia;
                horarioAct.horario = horario.horario;
                horarioAct.fk_medico = horario.fk_medico;
                horarioAct.cancelado = horario.cancelado;
                horarioAct.consultorio = horario.consultorio;
                horarioAct.baja = horario.baja;
                horarioAct.sobreTurno = horario.sobreTurno;

                _context.SaveChanges();
            }

        }

        public void Delete (int id)
        {
            var horarioAct = _context.Horarios.Find(id);

            if (horarioAct != null)
            {
                _context.Remove(horarioAct);
                _context.SaveChanges();
            }
        }
    
}

public interface IHorarioService
{
    IEnumerable<Horario> Get();
    Horario GetHorario(int id);
    void Save(Horario horario);
    void Update(int id, Horario horario);
    void Delete(int id);
}