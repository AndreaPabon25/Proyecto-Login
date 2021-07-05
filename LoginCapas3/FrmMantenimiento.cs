
using System;
using System.Data;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;

namespace LoginCapas3
{
    public partial class FrmMantenimiento : Form
    {
        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();
        public FrmMantenimiento()
        {
            InitializeComponent();
        }

        void Mantenimiento(string accion)
        {
            objent.identificacion = txtidentificacion.Text;
            objent.nombre = txtnombre.Text;
            objent.edad = Convert.ToInt32(txtedad.Text);
            objent.telefono = Convert.ToInt32(txttelefono.Text);
            objent.accion = accion;
            string men = objneg.N_mantenimiento_clientes(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

   

    void limpiar()
        {
            txtidentificacion.Text = "";
            txtnombre.Text = "";
            txtedad.Text = "";
            txttelefono.Text = "";
            txtnombrebus.Text = "";
            dataGridViewListar.DataSource = objneg.N_listar_clientes();
        }

        private void FrmMantenimiento_Load(object sender, EventArgs e)
        {
            dataGridViewListar.DataSource = objneg.N_listar_clientes();
        }


        private void NuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtidentificacion.Text == "")
            {
                if (MessageBox.Show("¿ Deseas registrar a " + txtnombre.Text + "?", "Mensaje",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento("1");
                    limpiar();

                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtidentificacion.Text != "")
            {
                if (MessageBox.Show("¿ Deseas modificar a " + txtnombre.Text + "?", "Mensaje",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento("2");
                    limpiar();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtidentificacion.Text != "")
            {
                if (MessageBox.Show("¿ Deseas eliminar a " + txtnombre.Text + "?", "Mensaje",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento("3");
                    limpiar();
                }
            }
        }

        private void txtnombrebus_TextChanged(object sender, EventArgs e)
        {
            if (txtnombrebus.Text != "")
            {
                objent.nombre = txtnombrebus.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_clientes(objent);
                dataGridViewListar.DataSource = dt;

            }
            else
            {
                dataGridViewListar.DataSource = objneg.N_listar_clientes();
            }

        }

        private void dataGridViewListar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridViewListar.CurrentCell.RowIndex;


            txtidentificacion.Text = dataGridViewListar[0, fila].Value.ToString();
            txtnombre.Text = dataGridViewListar[1, fila].Value.ToString();
            txtedad.Text = dataGridViewListar[2, fila].Value.ToString();
            txttelefono.Text = dataGridViewListar[3, fila].Value.ToString();
        }
    }
}




