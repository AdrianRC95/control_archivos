using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace ctrlArchivos.Modelo
{
    public class Imprimir
    {
        /**
         * Exportar a excel utilizando formato HTML
         * @param Response  --> Obtener el objeto asociado con el evento
         * @param datos     --> Tabla de datos para exportar
         * @param namefile  --> Nombre del archivo
         **/
        public void exportToExcel(HttpResponse Response, Table datos, String namefile)
        {
            Response.ContentType = "application/x-msexcel";
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition", "attachment;filename = "+ namefile + ".xls");
            Response.ContentEncoding = Encoding.UTF8;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            datos.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
        }

        /**
         * Exportar a pdf utilizando formato HTML
         * @param Response  --> Obtener el objeto asociado con el evento
         * @param datos     --> Tabla de datos para exportar
         * @param namefile  --> Nombre del archivo
         **/
        public void exportToPdf(HttpResponse Response, Table datos, String namefile)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition",
             "attachment;filename= " + namefile + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            datos.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.LETTER.Rotate(), 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(new Paragraph("Datos " + namefile)); 
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
    }
}