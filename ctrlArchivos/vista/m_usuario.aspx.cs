using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ctrlArchivos.Controlador;
using System.Text;
using System.IO;
using ctrlArchivos.Modelo;

namespace ctrlArchivos.vista
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        ctrlUsuario usuario = new ctrlUsuario();
        Imprimir imprimir = new Imprimir();
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario.enlistarDatos(datos);
        }

        protected void exportExcel_Click(object sender, ImageClickEventArgs e)
        {
            imprimir.exportToExcel(Response,datos,"Usuarios");
        }

        protected void exportPdf_Click(object sender, ImageClickEventArgs e)
        {
            imprimir.exportToPdf(Response, datos, "Usuarios");
        }

        protected void print_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}