using Capa_Entidad;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginCapas3
{
    public partial class FrmLogin : Form
    {
        E_Users objeuser = new E_Users();
        N_Users objnuser = new N_Users();
        FrmPrincipal frm1 = new FrmPrincipal();

        public static string usuario_nombre;
        public static string area;

        public FrmLogin()
        {
            InitializeComponent();
        }
        void Logueo()
        {
            DataTable dt = new DataTable();
            objeuser.usuario = txtusuario.Text;
            objeuser.clave = txtcontrasena.Text;

            dt = objnuser.N_user(objeuser);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bienvenido al sistema" + dt.Rows[0][1].ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                usuario_nombre = dt.Rows[0][1].ToString();
                area = dt.Rows[0][0].ToString();

                frm1.ShowDialog();

                FrmLogin login = new FrmLogin();
                //login.ShowDialog();

                if (login.DialogResult == DialogResult.OK)
                    Application.Run(new FrmPrincipal());

                txtusuario.Clear();
                txtcontrasena.Clear();

            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrecta" + dt.Rows[0][1].ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

        private void btnIniciar_Click_1(object sender, EventArgs e)
        {
            Logueo();
        }


        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       
    }
}