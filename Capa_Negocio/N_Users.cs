using Capa_Datos;
using Capa_Entidad;
using System;
using System.Data;

namespace Capa_Negocio
{
    public class N_Users
    {
        D_Users objd = new D_Users();

        public DataTable N_user(E_Users obje)
        {
            return objd.D_User(obje);
        }
    }
}
