using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ctrlArchivos.Modelo;

namespace ctrlArchivos.Controlador
{
    public class ctrlUsuario
    {
        Usuario2 obj1 = new Usuario2();
        Usuario usuario = new Usuario();

        public void cargarTipoUsuario(DropDownList tipoUsuario)
        {
            tipoUsuario.Items.Clear();
            tipoUsuario.Items.Add("Selecciona");
            tipoUsuario.Items.Add("administrador");
            tipoUsuario.Items.Add("tipo 2");
            tipoUsuario.Items.Add("tipo 3");
            tipoUsuario.Items.Add("tipo 4");
        }

        public void cargarUnidadAdmin(DropDownList idunidad, DropDownList unidad)
        {
            string consulta = "";
            //Cargar id unidad administrativa
            consulta = "select id_unid_admva from unidad_admva";
            obj1.cargar_DropDownListString(idunidad, consulta);
            //Cargar nombre unidad administrativa
            consulta = "select nombre_unid_admva from unidad_admva";
            obj1.cargar_DropDownListString(unidad, consulta);
        }

        public void generaID()
        {
            string consulta = "select TOP 1 (id_usr) from usuario order by id_usr desc";


        }

        public void buscarIdCorrespondiente(DropDownList ddlnombre, DropDownList ddlid)
        {
            //busca la clave del DropDownList Nombre seleccionado
            ddlid.SelectedIndex =
                ddlnombre.Items.IndexOf(ddlnombre.Items.FindByValue(ddlnombre.Text));
        }

        public void buscarNombreCorrespondiente(DropDownList ddlnombre, DropDownList ddlid)
        {
            //busca el nombre del DropDownList Nombre seleccionado
            ddlnombre.SelectedIndex = ddlid.Items.IndexOf(ddlid.Items.FindByValue(ddlid.Text));
        }

        public int GuardarUsuario(System.Web.UI.WebControls.TextBox txtIdUsuario,
                                   System.Web.UI.WebControls.TextBox txtNombre,
                                   System.Web.UI.WebControls.TextBox txtNombreCom,
                                   System.Web.UI.WebControls.TextBox txtEmail,
                                   System.Web.UI.WebControls.TextBox txtConfirmaEmail,
                                   System.Web.UI.WebControls.TextBox txtContrasenia,
                                   System.Web.UI.WebControls.TextBox txtConfirmaContrasenia,
                                   DropDownList ddlTipoUsuario,
                                   System.Web.UI.WebControls.TextBox txtTelefono,
                                   System.Web.UI.WebControls.TextBox txtCargo,
                                   DropDownList ddlIdUnidadAdm,
                                   ref string mensaje)
        {
            if (txtIdUsuario.Text != "" && txtNombre.Text != "" && txtNombreCom.Text != "" && txtEmail.Text != "" && txtConfirmaEmail.Text != ""
                && txtContrasenia.Text != "" && txtConfirmaContrasenia.Text != "" && ddlTipoUsuario.SelectedIndex != 0
                && txtTelefono.Text != "" && txtCargo.Text != "" && ddlIdUnidadAdm.SelectedIndex != 0)
            {
                if(txtEmail.Text == txtConfirmaEmail.Text)
                {
                    if (txtContrasenia.Text == txtConfirmaContrasenia.Text)
                    {
                        usuario.id_usuario = txtIdUsuario.Text;
                        usuario.nombre = txtNombre.Text;
                        usuario.nombre_com = txtNombreCom.Text;
                        usuario.email = txtEmail.Text;
                        usuario.confirmar_email = txtConfirmaEmail.Text;
                        usuario.contrasenia = txtConfirmaContrasenia.Text;
                        usuario.confirmar_contrasenia = txtConfirmaContrasenia.Text;
                        usuario.tipo_usuario = ddlTipoUsuario.Text;
                        usuario.telefono = txtTelefono.Text;
                        usuario.nombre_cargo = txtCargo.Text;
                        usuario.id_unid_admva_pertenece = ddlIdUnidadAdm.Text;
                        int respuesta = usuario.Guardar();
                        if (respuesta == 1)
                            mensaje = "Usuario agregado correctamente";
                        else
                            mensaje = "Ocurrió un error intente nuevamente";
                        return respuesta;
                    }
                    else
                    {
                        mensaje = "La contraseña no coincide, favor de verificarla";
                        return 0;
                    }
                }
                else
                {
                    mensaje = "El email no coincide, favor de verificarlo";
                    return 0;
                }
            }
            else
            {
                mensaje = "Llenar todos los campos";
                return 0;
            }
        }

        public bool buscarUsuario(string idUsuario, ref string mensaje)
        {
            if(idUsuario != "")
            {
                bool resp = usuario.Buscar(idUsuario);
                if (resp)
                    mensaje = "Usuario encontrado";
                else
                    mensaje = "No se encontro información del usuario";
                return resp;
            }
            else
            {
                mensaje = "Ingresar el ID del usuario para buscar";
                return false;
            }
        }
        
        public void cargarDatosUsuario(System.Web.UI.WebControls.TextBox txtIdUsuario,
                                   System.Web.UI.WebControls.TextBox txtNombre,
                                   System.Web.UI.WebControls.TextBox txtNombreCom,
                                   System.Web.UI.WebControls.TextBox txtEmail,
                                   System.Web.UI.WebControls.TextBox txtConfirmaEmail,
                                   System.Web.UI.WebControls.TextBox txtContrasenia,
                                   System.Web.UI.WebControls.TextBox txtConfirmaContrasenia,
                                   DropDownList ddlTipoUsuario,
                                   System.Web.UI.WebControls.TextBox txtTelefono,
                                   System.Web.UI.WebControls.TextBox txtCargo,
                                   DropDownList ddlIdUnidadAdm,
                                   DropDownList ddlUnidadAdm)
        {
            txtIdUsuario.Text = usuario.id_usuario;
            txtNombre.Text = usuario.nombre;
            txtNombreCom.Text = usuario.nombre_com;
            txtEmail.Text = usuario.email;
            txtConfirmaEmail.Text = usuario.confirmar_email;
            txtContrasenia.Text = usuario.contrasenia;
            txtConfirmaContrasenia.Text = usuario.confirmar_contrasenia;
            ddlTipoUsuario.Text = usuario.tipo_usuario;
            txtTelefono.Text = usuario.telefono;
            txtCargo.Text = usuario.nombre_cargo;
            ddlIdUnidadAdm.Text = usuario.id_unid_admva_pertenece;
            buscarNombreCorrespondiente(ddlUnidadAdm, ddlIdUnidadAdm);
            
        }

        public int ActualizarUsuario(System.Web.UI.WebControls.TextBox txtIdUsuario,
                                     System.Web.UI.WebControls.TextBox txtNombre,
                                     System.Web.UI.WebControls.TextBox txtNombreCom,
                                     System.Web.UI.WebControls.TextBox txtEmail,
                                     System.Web.UI.WebControls.TextBox txtConfirmaEmail,
                                     System.Web.UI.WebControls.TextBox txtContrasenia,
                                     System.Web.UI.WebControls.TextBox txtConfirmaContrasenia,
                                     DropDownList ddlTipoUsuario,
                                     System.Web.UI.WebControls.TextBox txtTelefono,
                                     System.Web.UI.WebControls.TextBox txtCargo,
                                     DropDownList ddlIdUnidadAdm,
                                     ref string mensaje)
        {
            if (txtIdUsuario.Text != "" && txtNombre.Text != "" && txtNombreCom.Text != "" && txtEmail.Text != "" && txtConfirmaEmail.Text != ""
                && txtContrasenia.Text != "" && txtConfirmaContrasenia.Text != "" && ddlTipoUsuario.SelectedIndex != 0
                && txtTelefono.Text != "" && txtCargo.Text != "" && ddlIdUnidadAdm.SelectedIndex != 0)
            {
                if (txtEmail.Text == txtConfirmaEmail.Text)
                {
                    if (txtContrasenia.Text == txtConfirmaContrasenia.Text)
                    {
                        usuario.id_usuario = txtIdUsuario.Text;
                        usuario.nombre = txtNombre.Text;
                        usuario.nombre_com = txtNombreCom.Text;
                        usuario.email = txtEmail.Text;
                        usuario.confirmar_email = txtConfirmaEmail.Text;
                        usuario.contrasenia = txtConfirmaContrasenia.Text;
                        usuario.confirmar_contrasenia = txtConfirmaContrasenia.Text;
                        usuario.tipo_usuario = ddlTipoUsuario.Text;
                        usuario.telefono = txtTelefono.Text;
                        usuario.nombre_cargo = txtCargo.Text;
                        usuario.id_unid_admva_pertenece = ddlIdUnidadAdm.Text;
                        int respuesta = usuario.Actualizar();
                        if (respuesta == 1)
                            mensaje = "Usuario actualizado correctamente";
                        else
                            mensaje = "Ocurrió un error intente nuevamente";
                        return respuesta;
                    }
                    else
                    {
                        mensaje = "La contraseña no coincide, favor de verificarla";
                        return 0;
                    }
                }
                else
                {
                    mensaje = "El email no coincide, favor de verificarlo";
                    return 0;
                }
            }
            else
            {
                mensaje = "Llenar todos los campos";
                return 0;
            }
        }

        public int Eliminar(string idUsuario, ref string mensaje)
        {
            if (idUsuario != "")
            {
                int resp = usuario.Eliminar(idUsuario);
                if (resp == 1)
                    mensaje = "Usuario eliminado correctamente";
                else
                    mensaje = "Ocurrió un error, intentar nuevamente";
                return resp;
            }
            else
            {
                mensaje = "Ingresar ID de usuario";
                return 0;
            }
        }

    }
}