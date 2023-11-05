using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Empleados
{
   public class EmpleadosAdmin
    {
        public void Save(Empleado modelo)
        {
            using (WebModel context = new WebModel())
            {
                context.Empleado.Add(modelo);
                context.SaveChanges();
            }
        }

        public List<Empleado> BuscarTodos()
        {
            using (WebModel context = new WebModel())
            {
                return context.Empleado.AsNoTracking().OrderBy(p => p.Apellido).ToList();
            }
        }

        public List<Empleado> BuscarCoincidencias(string unaCadena)
        {
            using (WebModel context = new WebModel())
            {
                return context.Empleado.AsNoTracking().Where(e => e.Apellido.Contains(unaCadena)).ToList();
            }
        }

        public Empleado BuscarEmpleadoPorId(int unId)
        {
            using (WebModel context = new WebModel())
            {
                return context.Empleado.Find(unId);
            }
        }

        public void EditarEmpleado(Empleado unEmpleado)
        {
            WebModel context = new WebModel();
            var EmpleadoDB = context.Empleado.FirstOrDefault(e => e.Id == unEmpleado.Id);
            EmpleadoDB.Nombre = unEmpleado.Nombre;
            EmpleadoDB.Apellido = unEmpleado.Apellido;
            EmpleadoDB.Email = unEmpleado.Email;
            EmpleadoDB.Salario = unEmpleado.Salario;

            context.SaveChanges();
        }

        public void EliminarEmpleado(int unId)
        {
            WebModel context = new WebModel();
            var EmpleadoDB = context.Empleado.FirstOrDefault(e => e.Id == unId);
            context.Empleado.Remove(EmpleadoDB);
            context.SaveChanges();
        }
    }
}
