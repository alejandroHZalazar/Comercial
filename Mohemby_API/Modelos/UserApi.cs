using System.ComponentModel.DataAnnotations;

namespace Mohemby_API.Modelos;

public class UserApi
{
     [Key]
        public long id {get;set;}
        public string?  user {get;set;}
        public string? password {get;set;} 
}

