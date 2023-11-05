namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empleado")]
    public partial class Empleado
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Debe ingresar un Nombre")]
        [StringLength(300)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Apellido")]
        [StringLength(300)]
        public string Apellido { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Formato de email inválido")]
        [StringLength(150)]
       public string Email { get; set; }

       
        public decimal Salario { get; set; }
    }
}
