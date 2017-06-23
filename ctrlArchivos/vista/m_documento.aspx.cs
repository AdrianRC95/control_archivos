using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ctrlArchivos.Controlador;

namespace ctrlArchivos.vista
{
    public partial class m_documento : System.Web.UI.Page
    {
        ctrlDocumento documento = new ctrlDocumento();
        protected void Page_Load(object sender, EventArgs e)
        {
            documento.enlistarDatos(datos);
        }
    }
}