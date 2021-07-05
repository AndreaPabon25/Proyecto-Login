using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginCapas3
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //admin

            if (FrmLogin.area.Trim() == "A001")
            {
                btnalmacen.Enabled = true;
                btncompras.Enabled = true;
                btnventas.Enabled = true;

                lblcargo.Text = "Administrador";

            }
            //ventas
            else if (FrmLogin.area.Trim() == "A002")
            {
                btnalmacen.Enabled = false;
                btncompras.Enabled = false;
                btnventas.Enabled = true;

                lblcargo.Text = "Ventas";

            }
            //compras
            else if (FrmLogin.area.Trim() == "A003")
            {
                btnalmacen.Enabled = false;
                btncompras.Enabled = true;
                btnventas.Enabled = false;

                lblcargo.Text = "Compras";

            }

            lblnombre.Text = FrmLogin.usuario_nombre;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblfecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

       

       

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }
        private void AbrirFormEnPanel(object formhija)
        {
            if (this.Panelcontenedor.Controls.Count > 0)
                this.Panelcontenedor.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Panelcontenedor.Controls.Add(fh);
            this.Panelcontenedor.Tag = fh;
            fh.Show();

        }

        private void btncerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit ();
        }
    }
}
