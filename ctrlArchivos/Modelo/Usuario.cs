using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ctrlArchivos.Modelo
{
    public class Usuario
    {
        public string id_usuario { set; get; }
        public string nombre { set; get; }
        public string nombre_com { set; get; }
        public string email { set; get; }
        public string confirmar_email { set; get; }
        public string contrasenia { set; get; }
        public string confirmar_contrasenia { set; get; }
        public string tipo_usuario { set; get; }
        public string telefono { set; get; }
        public string nombre_cargo { set; get; }
        public string id_unid_admva_pertenece  { set; get; }

        Usuario2 obj = new Usuario2();

        public Usuario()
        {
            //Contructor por default;
        }

        //Constructor principal
        public Usuario(string id_usuario, string nombre, string nombre_com, string email,
                         string confirmar_email, string contraseña, string confirmar_contraseña, 
                         string tipo_usuario, string telefono, string nombre_cargo, string id_unidad_administrativa)
        {
            this.id_usuario = id_usuario;
            this.nombre = nombre;
            this.nombre_com = nombre_com;
            this.email = email;
            this.confirmar_email = confirmar_email;
            this.contrasenia = contraseña;
            this.confirmar_contrasenia = confirmar_contraseña;
            this.tipo_usuario = tipo_usuario;
            this.telefono = telefono;
            this.nombre_cargo = nombre_cargo;
            this.id_unid_admva_pertenece = id_unidad_administrativa;
        }

        public int Guardar()
        {
            string consulta = "INSERT INTO usuario VALUES('" + this.id_usuario + "'," +
                "'" + this.nombre + "','" + this.nombre_com + "','" + this.email + "'," +
                "'" + this.confirmar_email + "','" + this.contrasenia + "','" + this.confirmar_contrasenia + "'," +
                "'" + this.tipo_usuario + "','" + this.telefono + "'," +
                "'" + this.nombre_cargo + "','" + this.id_unid_admva_pertenece + "')";
            int res = obj.Guardar(consulta);
            return res;
        }

        public bool Buscar(string id_usuario)
        {
            string consulta = "SELECT * FROM usuario WHERE id_usr='" + id_usuario + "'";
            string[] datos = obj.Buscar(consulta);
            if (datos != null)
            {
                this.id_usuario = datos[0];
                this.nombre = datos[1];
                this.nombre_com = datos[2];
                this.email = datos[3];
                this.confirmar_email = datos[4];
                this.contrasenia = datos[5];
                this.confirmar_contrasenia = datos[6];
                this.tipo_usuario = datos[7];
                this.telefono = datos[8];
                this.nombre_cargo = datos[9];
                this.id_unid_admva_pertenece = datos[10];
                return true;
            }
            else
                return false;
        }

        public int Actualizar()
        {
            string consulta = "UPDATE usuario SET " +
                "nombre_usr='" + this.nombre + "', " +
                "nom_com_usr='" + this.nombre_com + "', " +
                "email_usr='" + this.email + "', " +
                "confirmaemail_usr='" + this.confirmar_email + "', " +
                "contra_usr='" + this.contrasenia + "', " +
                "confirmacontra_usr='" + this.confirmar_contrasenia + "', " +
                "tipo_usr='" + this.tipo_usuario + "', " +
                "telefono_contacto='" + this.telefono + "', " +
                "nom_cargo_usr='" + this.nombre_cargo + "', " +
                "id_unid_admva_pertenece='" + this.id_unid_admva_pertenece + "' " +
                "WHERE id_usr='" + id_usuario + "'";
            int res = obj.Guardar(consulta);
            return res;
        }

        public int Eliminar(string id_usuario)
        {
            String consulta = "DELETE FROM usuario WHERE id_usr='" + id_usuario+ "';";
            int res = obj.Guardar(consulta);
            return res;
        }
    }
}