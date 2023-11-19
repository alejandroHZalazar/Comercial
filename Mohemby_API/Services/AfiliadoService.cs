using Mohemby_API.Modelos;

namespace Mohemby_API.Services;

public class AfiliadoService : IAfiliadoService
{
    Contexto _context;

    public AfiliadoService(Contexto contexto)
    {
        _context = contexto;
    }

    public IEnumerable<Afiliado> Get()
    {
        return _context.Afiliados;
    }

    public Afiliado GetAfiliado(int id)
    {
        var afiliado = _context.Afiliados.Find(id);
        return afiliado;
    }

    public void Save(Afiliado afiliado)
    {
        _context.Add(afiliado);
        _context.SaveChanges();
    }

    public void Update (int id, Afiliado afiliado)
    {
        var afiliadoAct = _context.Afiliados.Find(id);
         if (afiliadoAct != null)
         {
            afiliadoAct.fk_grupo= afiliado.fk_grupo;
            afiliadoAct.nro= afiliado.nro;
            afiliadoAct.nombre=afiliado.nombre;
            afiliadoAct.fechaNac=afiliado.fechaNac;
            afiliadoAct.nroDocumento=afiliado.nroDocumento;
            afiliadoAct.fechaAlta=afiliado.fechaAlta;
            afiliadoAct.fechaBaja=afiliado.fechaBaja;
            afiliadoAct.baja= afiliado.baja;
            afiliadoAct.calle=afiliado.calle;
            afiliadoAct.telCelular=afiliado.telCelular;
            afiliadoAct.email=afiliado.email;
            afiliadoAct.abusador=afiliado.abusador;

            _context.SaveChanges();
         }
    }

    public void Delete (int id)
    {
        var afiliadoAct = _context.Afiliados.Find(id);

        if (afiliadoAct != null)
        {
            _context.Remove(afiliadoAct);
            _context.SaveChanges();
        }
    }
}

public interface IAfiliadoService
{
    IEnumerable<Afiliado> Get();
    Afiliado GetAfiliado(int id);
    void Save(Afiliado afiliado);
    void Update (int id, Afiliado afiliado);
    void Delete (int id);
}