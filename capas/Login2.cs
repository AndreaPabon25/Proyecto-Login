using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Capa_Entidad;
using Capa_Negocio;
using LoginBB;

namespace LoginCapas
{
    public partial class Login2 : Form
    {
        E_Users objeuser = new E_Users();
        N_Users objnuser = new N_Users();
        Principal frm1 = new Principal();

        public static string usuario_nombre;
        public static string area;

      
    }


}


