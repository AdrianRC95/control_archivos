using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ctrlArchivos.Controlador;
using ctrlArchivos.Modelo;

namespace ctrlArchivos.vista
{
    public partial class m_documento : System.Web.UI.Page
    {
        ctrlDocumento documento = new ctrlDocumento();
        Imprimir imprimir = new Imprimir();
        protected void Page_Load(object sender, EventArgs e)
        {
            documento.enlistarDatos(datos);
        }

        protected void exportExcel_Click(object sender, ImageClickEventArgs e)
        {
            imprimir.exportToExcel(Response, datos, "Documentos");
        }

        protected void exportPdf_Click(object sender, ImageClickEventArgs e)
        {
            imprimir.exportToPdf(Response, datos, "Documentos");
        }
    }
}