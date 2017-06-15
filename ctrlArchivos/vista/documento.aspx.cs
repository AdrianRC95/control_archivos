using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ctrlArchivos.Controlador;

namespace ctrlArchivos.vista
{
    public partial class documento : System.Web.UI.Page
    {
        ctrlDocumento doc = new ctrlDocumento();
        string mensaje = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Validate initially to force asterisks
                // to appear before the first roundtrip.
                Validate();
                doc.cargarExpediente(ddlIdClasifExp);
                doc.cargarTipoDocumento(ddlTipo);
                doc.cargarEstatus(ddlStatus);
                doc.cargarPrioridad(ddlPrioridad);
                doc.cargarRemitente(ddlIdRemitente, ddlRemitente);
                doc.cargarDirigido(ddlIdDestinatario, ddlDestinatario);
                doc.cargarDelegado(ddlIdDelegado, ddlDelegado);
                doc.cargarEstatusTurno(ddlEstatusDelegado);
                ddlIdRemitente.Enabled = false;
                ddlIdDestinatario.Enabled = false;
                ddlIdDelegado.Enabled = false;
                btnActualizarDoc.Visible = false;
                btnEliminarDoc.Visible = false;
            }
        }

        protected void btnBuscarDoc_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscarDocumento_Click(object sender, EventArgs e)
        {
            bool resp = doc.buscarDocumento(buscarFolioDocumento.Text, ref mensaje);
            if (resp)
            {
                doc.cargarDatosDocumento(ddlIdClasifExp, 
                                         txtFolio, 
                                         ddlTipo,
                                         ddlStatus,
                                         ddlPrioridad,
                                         txtNumero,
                                         txtFecha, 
                                         ddlIdRemitente, 
                                         ddlRemitente,
                                         ddlIdDestinatario, 
                                         ddlDestinatario,
                                         txtFechaRecepcion,
                                         txtHoraRecepcion,
                                         txtAsunto,
                                         txtObservaciones,
                                         txtDescAnexos,
                                         txtNumFojas,
                                         ddlIdDelegado,
                                         ddlDelegado,
                                         ddlEstatusDelegado,
                                         txtFechaDelegacion);
                btnAgregarDoc.Visible = false;
                btnActualizarDoc.Visible = true;
                btnEliminarDoc.Visible = true;
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "mostar", "msgError('" + mensaje + "');", true);
            }
        }

        protected void btnAgregarDoc_Click(object sender, EventArgs e)
        {
            int res = doc.GuardarDocumento(ddlIdClasifExp, 
                                           txtFolio,
                                           ddlTipo,
                                           ddlStatus,
                                           ddlPrioridad, 
                                           txtNumero, 
                                           txtFecha,
                                           ddlIdRemitente, 
                                           ddlIdDestinatario,
                                           txtFechaRecepcion, 
                                           txtHoraRecepcion, 
                                           txtAsunto,
                                           txtObservaciones, 
                                           txtDescAnexos, 
                                           txtNumFojas, 
                                           ddlIdDelegado,
                                           ddlEstatusDelegado, 
                                           txtFechaDelegacion, 
                                           ref mensaje);
            if (res == 1)
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "msgCorrecto('" + mensaje + "','/vista/Documento.aspx');", true);
            else
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "msgError('" + mensaje + "');", true);
        }

        protected void btnActualizarDoc_Click(object sender, EventArgs e)
        {
            int res = doc.ActualizarDocumento(ddlIdClasifExp, 
                                              txtFolio,
                                              ddlTipo,
                                              ddlStatus,
                                              ddlPrioridad,
                                              txtNumero,
                                              txtFecha,
                                              ddlIdRemitente,
                                              ddlIdDestinatario,
                                              txtFechaRecepcion,
                                              txtHoraRecepcion, 
                                              txtAsunto,
                                              txtObservaciones,
                                              txtDescAnexos,
                                              txtNumFojas, 
                                              ddlIdDelegado,
                                              ddlEstatusDelegado,
                                              txtFechaDelegacion,
                                              ref mensaje);
            ClientScript.RegisterStartupScript(GetType(), "mostrar", "msgError('" + mensaje + "');", true);
        }

        protected void btnEliminarDoc_Click(object sender, EventArgs e)
        {
            int res = doc.Eliminar(txtFolio.Text, ref mensaje);
            if (res == 1)
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "msgCorrecto('" + mensaje + "','/vista/documento.aspx');", true);
            else
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "msgError('" + mensaje + "');", true);
        }

        protected void ddlRemitente_SelectedIndexChanged(object sender, EventArgs e)
        {
            doc.buscarIdCorrespondiente(ddlRemitente, ddlIdRemitente);
        }

        protected void ddlDestinatario_SelectedIndexChanged(object sender, EventArgs e)
        {
            doc.buscarIdCorrespondiente(ddlDestinatario, ddlIdDestinatario);
        }

        protected void ddlDelegado_SelectedIndexChanged(object sender, EventArgs e)
        {
            doc.buscarIdCorrespondiente(ddlDelegado, ddlIdDelegado);
        }
    }
}