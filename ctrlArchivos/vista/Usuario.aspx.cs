using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ctrlArchivos.Controlador;

namespace ctrlArchivos.vista
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        ctrlUsuario usuario = new ctrlUsuario();
        string mensaje = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Validate initially to force asterisks
                // to appear before the first roundtrip.
                Validate();
                usuario.cargarTipoUsuario(ddlTipoUsuario);
                usuario.cargarUnidadAdmin(ddlIdUnidadAdm, ddlUnidadAdm);
                ddlIdUnidadAdm.Enabled = false;
                btnActualizar.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        protected void ddlUnidadAdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            usuario.buscarIdCorrespondiente(ddlUnidadAdm, ddlIdUnidadAdm);
            ddlUnidadAdm.Focus();
        }

        protected void btnAgregarDoc_Click(object sender, EventArgs e)
        {
            int res = usuario.GuardarUsuario(txtIdUsuario, 
                                   txtNombre,
                                   txtNombreCom, 
                                   txtEmail, 
                                   txtConfirmaEmail, 
                                   txtContrasenia, 
                                   txtConfirmaContrasenia, 
                                   ddlTipoUsuario, 
                                   txtTelefono, 
                                   txtCargo, 
                                   ddlIdUnidadAdm,
                                   ref mensaje);
            if (res == 1)
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "msgCorrecto('" + mensaje + "','/vista/Usuario.aspx');", true);
            else
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "msgError('" + mensaje + "');", true);
        }

        protected void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            bool resp = usuario.buscarUsuario(buscarIdUsuario.Text, ref mensaje);
            if (resp)
            {
                usuario.cargarDatosUsuario(txtIdUsuario,
                                           txtNombre,
                                           txtNombreCom,
                                           txtEmail,
                                           txtConfirmaEmail,
                                           txtContrasenia,
                                           txtConfirmaContrasenia,
                                           ddlTipoUsuario,
                                           txtTelefono,
                                           txtCargo,
                                           ddlIdUnidadAdm,
                                           ddlUnidadAdm);
                btnAgregar.Visible = false;
                btnActualizar.Visible = true;
                btnEliminar.Visible = true;
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "mostar", "msgError('" + mensaje + "');", true);
            }

        }

        protected void btnActualizarDoc_Click(object sender, EventArgs e)
        {
            int res = usuario.ActualizarUsuario(txtIdUsuario,
                                   txtNombre,
                                   txtNombreCom,
                                   txtEmail,
                                   txtConfirmaEmail,
                                   txtContrasenia,
                                   txtConfirmaContrasenia,
                                   ddlTipoUsuario,
                                   txtTelefono,
                                   txtCargo,
                                   ddlIdUnidadAdm,
                                   ref mensaje);
            ClientScript.RegisterStartupScript(GetType(), "mostrar", "msgError('" + mensaje + "');", true);
        }

        protected void btnEliminarDoc_Click(object sender, EventArgs e)
        {
            int res = usuario.Eliminar(txtIdUsuario.Text, ref mensaje);
            if (res == 1)
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "msgCorrecto('" + mensaje + "','/vista/Usuario.aspx');", true);
            else
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "msgError('" + mensaje + "');", true);

        }
    }
}