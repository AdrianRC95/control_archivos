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
    public class ctrlDocumento
    {
        Usuario2 obj1 = new Usuario2();
        Documento documento = new Documento();

        public void cargarTipoDocumento(DropDownList tipoDocumento)
        {
            tipoDocumento.Items.Clear();
            tipoDocumento.Items.Add("Selecciona");
            tipoDocumento.Items.Add("tipo 1");
            tipoDocumento.Items.Add("tipo 2");
            tipoDocumento.Items.Add("tipo 3");
            tipoDocumento.Items.Add("tipo 4");
        }

        public void cargarEstatus(DropDownList estatus)
        {
            estatus.Items.Clear();
            estatus.Items.Add("Selecciona");
            estatus.Items.Add("estatus 1");
            estatus.Items.Add("estatus 2");
            estatus.Items.Add("estatus 3");
            estatus.Items.Add("estatus 4");
        }

        public void cargarPrioridad(DropDownList prioridad)
        {
            prioridad.Items.Clear();
            prioridad.Items.Add("Selecciona");
            prioridad.Items.Add("prioridad 1");
            prioridad.Items.Add("prioridad 2");
            prioridad.Items.Add("prioridad 3");
            prioridad.Items.Add("prioridad 4");
        }

        public void cargarEstatusTurno(DropDownList est_turno)
        {
            est_turno.Items.Clear();
            est_turno.Items.Add("Selecciona");
            est_turno.Items.Add("estatus 1");
            est_turno.Items.Add("estatus 2");
            est_turno.Items.Add("estatus 3");
            est_turno.Items.Add("estatus 4");
        }

        public void cargarExpediente(DropDownList idexpediente)
        {
            string consulta = "";
            //Cargar id expediente
            consulta = "select clasificacion_exp from expediente";
            obj1.cargar_DropDownListString(idexpediente, consulta);
        }

        public void cargarRemitente(DropDownList idremitente, DropDownList remitente)
        {
            string consulta = "";
            //Cargar id usuario
            consulta = "select id_usr from usuario";
            obj1.cargar_DropDownListString(idremitente, consulta);
            //Cargar nombre usuario
            consulta = "select nom_com_usr from usuario";
            obj1.cargar_DropDownListString(remitente, consulta);
        }

        public void cargarDirigido(DropDownList iddirigido, DropDownList dirigido)
        {
            string consulta = "";
            //Cargar id usuario
            consulta = "select id_usr from usuario";
            obj1.cargar_DropDownListString(iddirigido, consulta);
            //Cargar nombre usuario
            consulta = "select nom_com_usr from usuario";
            obj1.cargar_DropDownListString(dirigido, consulta);
        }
        public void cargarDelegado(DropDownList iddelegado, DropDownList delegado)
        {
            string consulta = "";
            //Cargar id usuario
            consulta = "select id_usr from usuario";
            obj1.cargar_DropDownListString(iddelegado, consulta);
            //Cargar nombre usuario
            consulta = "select nom_com_usr from usuario";
            obj1.cargar_DropDownListString(delegado, consulta);
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

        public int GuardarDocumento(DropDownList id_expediente,
                                    System.Web.UI.WebControls.TextBox folio,
                                    DropDownList tipo,
                                    DropDownList estatus_doc,
                                    DropDownList prioridad,
                                    System.Web.UI.WebControls.TextBox numero_doc,
                                    System.Web.UI.WebControls.TextBox fecha_doc,
                                    DropDownList id_remitente,
                                    DropDownList id_dirigido,
                                    System.Web.UI.WebControls.TextBox fecha_recep,
                                    System.Web.UI.WebControls.TextBox hora_recep,
                                    System.Web.UI.WebControls.TextBox asunto,
                                    System.Web.UI.WebControls.TextBox observaciones,
                                    System.Web.UI.WebControls.TextBox desc_anexos,
                                    System.Web.UI.WebControls.TextBox numero_fojas,
                                    DropDownList id_delegado,
                                    DropDownList estatus_turno,
                                    System.Web.UI.WebControls.TextBox fecha_turno,
                                    ref string mensaje)
        {
            if (id_expediente.SelectedIndex != 0 && folio.Text != "" && tipo.SelectedIndex != 0 && estatus_doc.SelectedIndex != 0
                && prioridad.SelectedIndex != 0 && numero_doc.Text != "" && fecha_doc.Text != "" && id_remitente.SelectedIndex != 0
                && id_dirigido.SelectedIndex != 0 && fecha_recep.Text != "" && hora_recep.Text != "" && asunto.Text != ""
                && observaciones.Text != "" && desc_anexos.Text != "" && numero_fojas.Text != "" && id_delegado.SelectedIndex != 0
                && estatus_turno.SelectedIndex != 0 && fecha_turno.Text != "")
            {
                documento.id_class_expediente = id_expediente.Text;
                documento.id_documento = folio.Text;
                documento.tipo = tipo.Text;
                documento.estatus = estatus_doc.Text;
                documento.prioridad = prioridad.Text;
                documento.numero_documento = numero_doc.Text;
                documento.fecha = DateTime.Parse(fecha_doc.Text);
                documento.id_remitente = id_remitente.Text;
                documento.id_destinatario = id_dirigido.Text;
                documento.fecha_recepcion = DateTime.Parse(fecha_recep.Text);
                documento.hora_recepcion = DateTime.Parse(hora_recep.Text);
                documento.asunto = asunto.Text;
                documento.observaciones = observaciones.Text;
                documento.descripcion_anexos = desc_anexos.Text;
                documento.numero_fojas = Convert.ToInt32(numero_fojas.Text);
                documento.id_delegado = id_delegado.Text;
                documento.estatus_delegado = estatus_turno.Text;
                documento.fecha_delegado = DateTime.Parse(fecha_turno.Text);

                int respuesta = documento.Guardar();
                if (respuesta == 1)
                    mensaje = "Documento agregado correctamente";
                else
                    mensaje = "Ocurrió un error intente nuevamente";
                return respuesta;
            }
            else
            {
                mensaje = "Llenar todos los campos";
                return 0;
            }
        }

        public bool buscarDocumento(string idDocumento, ref string mensaje)
        {
            if (idDocumento != "")
            {
                bool resp = documento.Buscar(idDocumento);
                if (resp)
                    mensaje = "Documento encontrado";
                else
                    mensaje = "No se encontro información del documento";
                return resp;
            }
            else
            {
                mensaje = "Ingresar el folio del documento para buscar";
                return false;
            }
        }

        public void cargarDatosDocumento(DropDownList id_expediente,
                                        System.Web.UI.WebControls.TextBox folio,
                                        DropDownList tipo,
                                        DropDownList estatus_doc,
                                        DropDownList prioridad,
                                        System.Web.UI.WebControls.TextBox numero_doc,
                                        System.Web.UI.WebControls.TextBox fecha_doc,
                                        DropDownList id_remitente,
                                        DropDownList nombre_remitente,
                                        DropDownList id_dirigido,
                                        DropDownList nombre_dirigido,
                                        System.Web.UI.WebControls.TextBox fecha_recep,
                                        System.Web.UI.WebControls.TextBox hora_recep,
                                        System.Web.UI.WebControls.TextBox asunto,
                                        System.Web.UI.WebControls.TextBox observaciones,
                                        System.Web.UI.WebControls.TextBox desc_anexos,
                                        System.Web.UI.WebControls.TextBox numero_fojas,
                                        DropDownList id_delegado,
                                        DropDownList nombre_delegado,
                                        DropDownList estatus_turno,
                                        System.Web.UI.WebControls.TextBox fecha_turno)
        {
            id_expediente.Text = documento.id_class_expediente;
            folio.Text = documento.id_documento;
            tipo.Text = documento.tipo;
            estatus_doc.Text = documento.estatus;
            prioridad.Text = documento.prioridad;
            numero_doc.Text = documento.numero_documento;
            fecha_doc.Text = documento.fecha.ToString("yyyy-MM-dd");
            id_remitente.Text = documento.id_remitente;
            buscarNombreCorrespondiente(nombre_remitente, id_remitente);
            id_dirigido.Text = documento.id_destinatario;
            buscarNombreCorrespondiente(nombre_dirigido, id_dirigido);
            fecha_recep.Text = documento.fecha_recepcion.ToString("yyyy-MM-dd");
            hora_recep.Text = documento.hora_recepcion.ToString("HH:mm:ss");
            asunto.Text = documento.asunto;
            observaciones.Text = documento.observaciones;
            desc_anexos.Text = documento.descripcion_anexos;
            numero_fojas.Text = documento.numero_fojas.ToString();
            id_delegado.Text = documento.id_delegado;
            buscarNombreCorrespondiente(nombre_delegado, id_delegado);
            estatus_turno.Text = documento.estatus_delegado;
            fecha_turno.Text = documento.fecha_delegado.ToString("yyyy-MM-dd");
        }

        public int ActualizarDocumento(DropDownList id_expediente,
                                        System.Web.UI.WebControls.TextBox folio,
                                        DropDownList tipo,
                                        DropDownList estatus_doc,
                                        DropDownList prioridad,
                                        System.Web.UI.WebControls.TextBox numero_doc,
                                        System.Web.UI.WebControls.TextBox fecha_doc,
                                        DropDownList id_remitente,
                                        DropDownList id_dirigido,
                                        System.Web.UI.WebControls.TextBox fecha_recep,
                                        System.Web.UI.WebControls.TextBox hora_recep,
                                        System.Web.UI.WebControls.TextBox asunto,
                                        System.Web.UI.WebControls.TextBox observaciones,
                                        System.Web.UI.WebControls.TextBox desc_anexos,
                                        System.Web.UI.WebControls.TextBox numero_fojas,
                                        DropDownList id_delegado,
                                        DropDownList estatus_turno,
                                        System.Web.UI.WebControls.TextBox fecha_turno,
                                        ref string mensaje)
        {
            if (id_expediente.SelectedIndex != 0 && folio.Text != "" && tipo.SelectedIndex != 0 && estatus_doc.SelectedIndex != 0
                && prioridad.SelectedIndex != 0 && numero_doc.Text != "" && fecha_doc.Text != "" && id_remitente.SelectedIndex != 0
                && id_dirigido.SelectedIndex != 0 && fecha_recep.Text != "" && hora_recep.Text != "" && asunto.Text != ""
                && observaciones.Text != "" && desc_anexos.Text != "" && numero_fojas.Text != "" && id_delegado.SelectedIndex != 0
                && estatus_turno.SelectedIndex != 0 && fecha_turno.Text != "")
            {
                documento.id_class_expediente = id_expediente.Text;
                documento.id_documento = folio.Text;
                documento.tipo = tipo.Text;
                documento.estatus = estatus_doc.Text;
                documento.prioridad = prioridad.Text;
                documento.numero_documento = numero_doc.Text;
                documento.fecha = DateTime.Parse(fecha_doc.Text);
                documento.id_remitente = id_remitente.Text;
                documento.id_destinatario = id_dirigido.Text;
                documento.fecha_recepcion = DateTime.Parse(fecha_recep.Text);
                documento.hora_recepcion = DateTime.Parse(hora_recep.Text);
                documento.asunto = asunto.Text;
                documento.observaciones = observaciones.Text;
                documento.descripcion_anexos = desc_anexos.Text;
                documento.numero_fojas = Convert.ToInt32(numero_fojas.Text);
                documento.id_delegado = id_delegado.Text;
                documento.estatus_delegado = estatus_turno.Text;
                documento.fecha_delegado = DateTime.Parse(fecha_turno.Text);
                int respuesta = documento.Actualizar();
                if (respuesta == 1)
                    mensaje = "Documento actualizado correctamente";
                else
                    mensaje = "Ocurrió un error intente nuevamente";
                return respuesta;
            }
            else
            {
                mensaje = "Llenar todos los campos";
                return 0;
            }
        }

        public int Eliminar(string idDocumento, ref string mensaje)
        {
            if (idDocumento != "")
            {
                int resp = documento.Eliminar(idDocumento);
                if (resp == 1)
                    mensaje = "Documento eliminado correctamente";
                else
                    mensaje = "Ocurrió un error, intentar nuevamente";
                return resp;
            }
            else
            {
                mensaje = "Ingresar folio de documento";
                return 0;
            }
        }
    }
}