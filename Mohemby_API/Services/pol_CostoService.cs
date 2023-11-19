using Mohemby_API.Modelos;

namespace Mohemby_API.Services;

public class pol_CostoService: Ipol_CostoService
{
    Contexto _context;

     public pol_CostoService (Contexto contexto)
    {
        _context = contexto;
    }

    public IEnumerable<pol_Costo> Get()
    {
        return _context.pol_Costos;
    }

     public pol_Costo GetPol_Costo(int id)
    {
        var pol_Costo = _context.pol_Costos.Find(id);
        return pol_Costo;
    }

     public void Save (pol_Costo pol_costo)
    {
        _context.Add(pol_costo);
        _context.SaveChanges();
    }

     public void Update (int id, pol_Costo pol_costo)
    {
        var Pol_CostoAct = _context.pol_Costos.Find(id);

        if (Pol_CostoAct != null)
        {
            Pol_CostoAct.obraSocial = pol_costo.obraSocial;
            Pol_CostoAct.coef = pol_costo.coef;
            Pol_CostoAct.baja = pol_costo.baja;
            Pol_CostoAct.fk_tipo_obraSocial = pol_costo.fk_tipo_obraSocial;
            Pol_CostoAct.esOS = pol_costo.esOS;
        }
    }

      public void Delete (int id)
    {
        var Pol_CostoAct = _context.pol_Costos.Find(id);

        if (Pol_CostoAct != null)
        {
            _context.Remove(Pol_CostoAct);
            _context.SaveChanges();
        }
    }
}

public interface Ipol_CostoService
{
    IEnumerable<pol_Costo> Get();
    pol_Costo GetPol_Costo(int id);
    void Save(pol_Costo pol_costo);
    void Update(int id, pol_Costo pol_costo);
    void Delete (int id);
}