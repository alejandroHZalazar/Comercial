using Mohemby_API.Modelos;

namespace Mohemby_API.Services;

public class Pol_Costos_OsService: IPol_Costos_OsService
{
     Contexto _context;

     public Pol_Costos_OsService (Contexto contexto)
    {
        _context = contexto;
    }

     public IEnumerable<Pol_Costos_OS> Get()
    {
        return _context.pol_Costos_Oss;
    }

      public Pol_Costos_OS GetPol_Costos_Os(int id)
    {
        var pol_Costo_Os = _context.pol_Costos_Oss.Find(id);
        return pol_Costo_Os;
    }

        public void Save (Pol_Costos_OS pol_Costos_OS)
    {
        _context.Add(pol_Costos_OS);
        _context.SaveChanges();
    }

     public void Update (int id, Pol_Costos_OS pol_Costos_OS)
    {
        var Pol_Costo_OsAct = _context.pol_Costos_Oss.Find(id);

        if (Pol_Costo_OsAct != null)
        {
            Pol_Costo_OsAct.fk_obraSocial = pol_Costos_OS.fk_obraSocial;
            Pol_Costo_OsAct.descripcion = pol_Costos_OS.descripcion;
            Pol_Costo_OsAct.importe = pol_Costos_OS.importe;
            Pol_Costo_OsAct.importeEME = pol_Costos_OS.importeEME;
            Pol_Costo_OsAct.codigoOS = pol_Costos_OS.codigoOS;
            Pol_Costo_OsAct.tipo = pol_Costos_OS.tipo;
            Pol_Costo_OsAct.baja = pol_Costos_OS.baja;
            Pol_Costo_OsAct.coseguro = pol_Costos_OS.coseguro;
        }
    }

     public void Delete (int id)
    {
        var Pol_Costo_OsAct = _context.pol_Costos_Oss.Find(id);

        if (Pol_Costo_OsAct != null)
        {
            _context.Remove(Pol_Costo_OsAct);
            _context.SaveChanges();
        }
    }
}

public interface IPol_Costos_OsService
{
    IEnumerable<Pol_Costos_OS> Get();
    Pol_Costos_OS GetPol_Costos_Os(int id);
    void Save(Pol_Costos_OS pol_Costos_OS);
    void Update(int id, Pol_Costos_OS pol_Costos_OS);
    void Delete (int id);
}