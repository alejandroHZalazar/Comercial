using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.Entity
{
    public  class WebModel : DbContext
    {
        public WebModel()
            : base("name=WebModel")
        {
        }

        public virtual DbSet<Empleado> Empleado { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
