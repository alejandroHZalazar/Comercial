using Mohemby_API.Modelos;

namespace Mohemby_API.Services;

public class Rayos_Costo_OsService: IRayos_Costo_OsService
{
     Contexto _context;

      public Rayos_Costo_OsService (Contexto contexto)
    {
        _context = contexto;
    }

     public IEnumerable<Rayos_Costo_OS> Get()
    {
        return _context.rayos_Costo_Oss;
    }

     public Rayos_Costo_OS GetRayos_Costo_OS(int id)
    {
        var rayos_Costos_OS = _context.rayos_Costo_Oss.Find(id);
        return rayos_Costos_OS;
    }

     public void Save (Rayos_Costo_OS rayos_Costo_OS)
    {
        _context.Add(rayos_Costo_OS);
        _context.SaveChanges();
    }

      public void Update (int id, Rayos_Costo_OS rayos_Costo_OS)
    {
        var Rayos_Costo_OSAct = _context.rayos_Costo_Oss.Find(id);

        if (Rayos_Costo_OSAct != null)
        {
            Rayos_Costo_OSAct.fk_obraSocial = rayos_Costo_OS.fk_obraSocial;
            Rayos_Costo_OSAct.descripcion = rayos_Costo_OS.descripcion;
            Rayos_Costo_OSAct.importe = rayos_Costo_OS.importe;
            Rayos_Costo_OSAct.importeEME = rayos_Costo_OS.importeEME;
            Rayos_Costo_OSAct.codigoOS = rayos_Costo_OS.codigoOS;
            Rayos_Costo_OSAct.tipo = rayos_Costo_OS.tipo;
            Rayos_Costo_OSAct.baja = rayos_Costo_OS.baja;
            Rayos_Costo_OSAct.coseguro = rayos_Costo_OS.coseguro;
           
        }
    }

      public void Delete (int id)
    {
        var Rayos_Costo_OSAct = _context.rayos_Costo_Oss.Find(id);

        if (Rayos_Costo_OSAct != null)
        {
            _context.Remove(Rayos_Costo_OSAct);
            _context.SaveChanges();
        }
    }
}

public interface IRayos_Costo_OsService
{
    IEnumerable<Rayos_Costo_OS> Get();
    Rayos_Costo_OS GetRayos_Costo_OS(int id);
    void Save(Rayos_Costo_OS pol_costo);
    void Update(int id, Rayos_Costo_OS rayos_Costo_OS);
    void Delete (int id);
}