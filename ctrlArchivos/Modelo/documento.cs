using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ctrlArchivos.Modelo
{
    public class Documento
    {
        public string id_class_expediente { set; get; }
        public string id_documento { set; get; }
        public string tipo { set; get; }
        public string estatus { set; get; }
        public string prioridad { set; get; }
        public string id_remitente { set; get; }
        public string numero_documento { set; get; }
        public DateTime fecha { set; get; }
        public string id_destinatario { set; get; }
        public DateTime fecha_recepcion { set; get; }
        public DateTime hora_recepcion { set; get; }
        public string asunto { set; get; }
        public string observaciones { set; get; }
        public string descripcion_anexos { set; get; }
        public int numero_fojas { set; get; }
        public string id_delegado { set; get; }
        public string estatus_delegado { set; get; }
        public DateTime fecha_delegado { set; get; }

        Usuario2 obj = new Usuario2();

        public Documento()
        {
            //Contructor por default;
        }
        
        //Constructor principal
        public Documento(string id_class_expediente, string id_documento, string tipo, string estatus,
                         string prioridad, string id_remitente, string numero_documento, DateTime fecha, string id_destinatario,
                         DateTime fecha_recepcion, DateTime hora_recepcion, string asunto, string observaciones,
                         string descripcion_anexos, int numero_fojas, string id_delegado, string estatus_delegado,
                         DateTime fecha_delegado)
        {
            this.id_class_expediente = id_class_expediente;
            this.id_documento = id_documento;
            this.tipo = tipo;
            this.estatus = estatus;
            this.prioridad = prioridad;
            this.id_remitente = id_remitente;
            this.numero_documento = numero_documento;
            this.fecha = fecha;
            this.id_destinatario = id_destinatario;
            this.fecha_recepcion = fecha_recepcion;
            this.hora_recepcion = hora_recepcion;
            this.asunto = asunto;
            this.observaciones = observaciones;
            this.descripcion_anexos = descripcion_anexos;
            this.numero_fojas = numero_fojas;
            this.id_delegado = id_delegado;
            this.estatus_delegado = estatus_delegado;
            this.fecha_delegado = fecha_delegado;
        }

        public int Guardar()
        {
            string consulta = "INSERT INTO documento VALUES('" + this.id_class_expediente + "'," +
                "'" + this.id_documento + "','" + this.tipo + "','" + this.estatus + "','" + this.prioridad + "'," +
                "'" + this.id_remitente + "','" + this.numero_documento + "','" + this.fecha.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "','" + this.id_destinatario + "'," +
                "'" + this.fecha_recepcion.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "','" + this.hora_recepcion.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "','" + this.asunto + "','" + this.observaciones + "'," +
                "'" + this.descripcion_anexos + "'," + this.numero_fojas + ",'" + this.id_delegado + "','" + this.estatus_delegado + "'," +
                "'" + this.fecha_delegado.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "')";
            int res = obj.Guardar(consulta);
            return res;
        }

        public bool Buscar(string id_documento)
        {
            string consulta = "SELECT * FROM documento WHERE id_doc='" + id_documento + "'";
            string[] datos = obj.Buscar(consulta);
            if (datos != null)
            {
                this.id_class_expediente = datos[0];
                this.id_documento = datos[1];
                this.tipo = datos[2];
                this.estatus = datos[3];
                this.prioridad = datos[4];
                this.id_remitente = datos[5];
                this.numero_documento = datos[6];
                this.fecha = Convert.ToDateTime(datos[7]);
                this.id_destinatario = datos[8];
                this.fecha_recepcion = Convert.ToDateTime(datos[9]);
                this.hora_recepcion = Convert.ToDateTime(datos[10]);
                this.asunto = datos[11];
                this.observaciones = datos[12];
                this.descripcion_anexos = datos[13];
                this.numero_fojas = Convert.ToInt32(datos[14]);
                this.id_delegado = datos[15];
                this.estatus_delegado = datos[16];
                this.fecha_delegado = Convert.ToDateTime(datos[17]);
                return true;
            }
            else
                return false;
        }

        public int Actualizar()
        {
            string consulta = "UPDATE documento SET " +
                "clasificacion_exp='" + this.id_class_expediente + "', " +
                "tipo_doc='" + this.tipo + "', " +
                "estatus_doc='" + this.estatus + "', " +
                "prioridad_doc='" + this.prioridad + "', " +
                "id_remitente_doc='" + this.id_remitente + "', " +
                "no_doc='" + this.numero_documento + "', " +
                "fecha_doc='" + this.fecha.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "', " +
                "id_destinatario='" + this.id_destinatario + "', " +
                "fecha_recep_doc='" + this.fecha_recepcion.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "', " +
                "hora_recep_doc='" + this.hora_recepcion.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "', " +
                "asunto='" + this.asunto + "', " +
                "obs_doc='" + this.observaciones + "', " +
                "desc_anexos_doc='" + this.descripcion_anexos + "', " +
                "no_fojas_doc=" + this.numero_fojas + ", " +
                "id_delegado_doc='" + this.id_delegado + "', " +
                "estatus_dele_doc='" + this.estatus_delegado + "', " +
                "fecha_dele_doc='" + this.fecha_delegado.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "' " +
                "WHERE id_doc='" + id_documento + "'";
            int res = obj.Guardar(consulta);
            return res;
        }

        public int Eliminar(String id_documento)
        {
            String consulta = "DELETE FROM documento WHERE id_doc='" + id_documento + "';";
            int res = obj.Guardar(consulta);
            return res;
        }
    }
}