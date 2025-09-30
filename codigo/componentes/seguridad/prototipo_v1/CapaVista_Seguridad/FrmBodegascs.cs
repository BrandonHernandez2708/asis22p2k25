using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador_Seguridad;

namespace CapaVista_Seguridad
{
    public partial class FrmBodegascs : Form
    {
        Controlador cn = new Controlador();
        private Cls_BodegaControlador controlador = new Cls_BodegaControlador();
        int bodegaActual = -1;
        public FrmBodegascs()
        {
            InitializeComponent();
        }
        private void fun_Configuracioninicial()
        {
            Btn_guardar.Enabled = false;
            Txt_idperfil.Enabled = false;
            Btn_Eliminar.Enabled = false;
            Btn_nuevo.Enabled = true;
            Btn_cancelar.Enabled = true;
            Btn_modificar.Enabled = false;
        }
        private void CargarComboBodegas()
        {
            DataTable bodegas = controlador.ObtenerBodegas();
            Cbo_perfiles.DataSource = bodegas;
            Cbo_perfiles.DisplayMember = "nombre_bodegas";
            Cbo_perfiles.ValueMember = "codigo_vodegas";
            Cbo_perfiles.SelectedIndex = -1;
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            if (Cbo_perfiles.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una bodega para buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int codigovodega = Convert.ToInt32(Cbo_perfiles.SelectedValue);
            DataRow datos = controlador.ConsultarBodegaPorId(codigovodega);

            if (datos != null)
            {
                Txt_puesto.Text = datos["nombre_completo"].ToString();

            }
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            if (bodegaActual == -1)
            {
                MessageBox.Show("Busque o seleccione un empleado primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            bool exito = controlador.ActualizarBodega(
                bodegaActual,
                Txt_puesto.Text,
                true
                );





            if (exito)
            {
                MessageBox.Show("Empleado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // REGISTRO EN BITÁCORA
                cn.RegistrarAccion(1, 1, "Modificiar Bodega", true);
            }
            else
            {
                MessageBox.Show("Error al actualizar empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
    }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt_puesto.Text))


            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool estado = Rdb_Habilitado.Checked;



            bool exito = controlador.InsertarBodega(Txt_puesto.Text);

            if (exito)
            {
                MessageBox.Show("Bodega Guardada correctamente");


                cn.RegistrarAccion(1, 1, "Guardar Bodega", true);

            }
            else
            {
                MessageBox.Show("Error al guardar perfil");
            }
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (bodegaActual == -1)
            {
                MessageBox.Show("Busque o seleccione un empleado primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro que desea eliminar este empleado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                bool exito = controlador.EliminarBodega(bodegaActual);
                if (exito)
                {
                    MessageBox.Show("Empleado eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // REGISTRO EN BITÁCORA
                    cn.RegistrarAccion(1, 1, "Eliminar Bodega", true);

                    CargarComboBodegas();

                }
                else
                {
                    MessageBox.Show("Error al eliminar empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            
            fun_Configuracioninicial();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {

        }
    }
}
