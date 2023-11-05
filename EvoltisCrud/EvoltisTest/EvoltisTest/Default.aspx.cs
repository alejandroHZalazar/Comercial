using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Empleados;
using Models.Entity;
using System.Windows.Forms;

namespace EvoltisTest
{
    public partial class _Default : Page
    {
        EmpleadosAdmin eaEmpleado = new EmpleadosAdmin();
        private static string idEmpleado = "0";
        private static int cont = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (cont == 0)
                {
                    MostrarEmpleados();
                    cont++;
                    txtBuscar.Text = String.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error!! " + ex.ToString());
            }
        }

        private void MostrarEmpleados()
        {
            List<Empleado> listEmp = eaEmpleado.BuscarTodos();

            GVEmpleados.DataSource = listEmp;
            GVEmpleados.DataBind();
        }

        private void MostrarEmpleadosPorContenido(string unTexto)
        {
            List<Empleado> listEmp = eaEmpleado.BuscarCoincidencias(unTexto);

            GVEmpleados.DataSource = listEmp;
            GVEmpleados.DataBind();
        }

        protected void nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                txtNombre1.Text = string.Empty;
                txtApellido.Value = string.Empty;
                txtEmail.Value = string.Empty;
                txtSalario.Value = string.Empty;
                idEmpleado = "0";
                btnSave.Text = "Agregar";
                AjaxVtM.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error!! " + ex.ToString());
            }
        }

        private void guardar()
        {

            Empleado model = new Empleado()
            {
                Nombre = txtNombre1.Text.Trim(),
                Apellido = txtApellido.Value.Trim(),
                Email = txtEmail.Value.Trim(),
                Salario = decimal.Parse(txtSalario.Value.Trim())

            };

            if (idEmpleado == "0" && ModelState.IsValid)
            {
                eaEmpleado.Save(model);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Creado correctamente')", true);
            }
            else if (idEmpleado != "0" && ModelState.IsValid)
            {
                model.Id = int.Parse(idEmpleado);
                eaEmpleado.EditarEmpleado(model);

            }

            MostrarEmpleados();

        }

        protected void Editar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                idEmpleado = btn.CommandArgument;

                Empleado EmpleadoAct = eaEmpleado.BuscarEmpleadoPorId(int.Parse(idEmpleado));

                txtNombre1.Text = EmpleadoAct.Nombre;
                txtApellido.Value = EmpleadoAct.Apellido;
                txtEmail.Value = EmpleadoAct.Email;
                txtSalario.Value = EmpleadoAct.Salario.ToString();
                btnSave.Text = "Editar";
                AjaxVtM.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error!! " + ex.ToString());
            }
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                idEmpleado = btn.CommandArgument;

                eaEmpleado.EliminarEmpleado(int.Parse(idEmpleado));
                cont = 0;
                MostrarEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error!! " + ex.ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                guardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error!! " + ex.ToString());
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text.Trim() == "")
                {
                    MostrarEmpleados();
                }
                else
                {
                    MostrarEmpleadosPorContenido(txtBuscar.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error!! " + ex.ToString());
            }
        }
    }
}