using Mohemby_API.Modelos;
using System.Linq;

namespace Mohemby_API.Services;

public class UserApiService : IUserApiService
{
    Contexto _contexto;

    public UserApiService (Contexto contexto)
    {
        _contexto = contexto;        
    }

     public bool CorrectCredential(string _user, string _pass) =>
         _contexto.UserApis.Where(u=>u.user == _user && u.password == _pass).Count() > 0;

}

public interface IUserApiService
{
   bool CorrectCredential(string _user, string _pass);
           
}