using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ctrlArchivos.Controlador;

namespace ctrlArchivos.vista
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        ctrlUsuario usuario = new ctrlUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario.enlistarDatos(datos);
        }
    }
}