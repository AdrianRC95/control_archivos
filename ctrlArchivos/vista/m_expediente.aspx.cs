using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ctrlArchivos.Modelo;

namespace ctrlArchivos.vista
{
    public partial class m_expediente : System.Web.UI.Page
    {
        Expediente expediente = new Expediente();
        protected void Page_Load(object sender, EventArgs e)
        {
            expediente.enlistarDatos(datos);
        }
    }
}