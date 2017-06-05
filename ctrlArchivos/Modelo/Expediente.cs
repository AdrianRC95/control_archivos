using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ctrlArchivos.Modelo;
using ctrlArchivos.vista;



namespace ctrlArchivos.Modelo
{
    public class Expediente
    {
        public string Clasificación { set; get; }
        public string idFondo { set; get; }
        public string idseccion { set; get; }
        public string idserie { set; get; }
        public int no_exp { set; get; }
        public int año { set; get; }
        public string id_unid_admva_resp { set; get; }
        public string id_area_prod { set; get; }
        public string id_resp_exp { set; get; }
        public string resumen_exp { set; get; }
        public string asunto_exp { set; get; }
        public string funcion_exp { set; get; }
        public string acceso_exp { set; get; }
        public string val_prim_exp { set; get; }
        public DateTime fec_ext_ini_exp { set; get; }
        public DateTime fec_ext_fin_exp { set; get; }
        public int no_legajo_exp { set; get; }
        public int no_fojas_exp { set; get; }
        public string vinc_otro_exp { set; get; }
        public string id_exp_vincd { set; get; }
        public string formato_Soporte { set; get; }
        public int plazo_conservacion_exp { set; get; }
        public string tipo_exp { set; get; }
        public string destino_final_exp { set; get; }
        public string valores_secundarios_exp { set; get; }
        public string id_ubic_topog { set; get; }
        public string IdEdificio { set; get; }
        public string IdPisoEd { set; get; }
        public string IdPasillo { set; get; }
        public string IdEstante { set; get; }
        public string IdCharola { set; get; }
        public string IdUnidInsCaja { set; get; }
        public DateTime fecha_alta_exp { set; get; }
        public string id_capturista_exp { set; get; }
        public string id_autorizador_exp { set; get; }

        Usuario2 obj1 = new Usuario2(); //from metodo
        
        public void cargarDatosIniciales(
            DropDownList ddlfondo,
            DropDownList ddlidfondo,
            DropDownList ddlseccion,
            DropDownList ddlidseccion,
            DropDownList ddlserie,
            DropDownList ddlidserie,
            DropDownList ddlaño,
            DropDownList ddluadmva,
            DropDownList ddlIduadmva,    
            DropDownList DdlFuncion,   
            DropDownList DdlAcceso,
            DropDownList DdlValPrim,
            DropDownList DdlTipExp,
            DropDownList DdlDestFin,
            DropDownList DdlValSec,
            DropDownList DdlPlazoConser,
            DropDownList DdlRespCaptura,
            DropDownList DdlIdRespCaptura
            )
        {
            string consulta = "";
            
            consulta = "select nombre_fondo from fondo";
            obj1.cargar_DropDownListString(ddlfondo, consulta);

            consulta = "select id_fondo from fondo";
            obj1.cargar_DropDownListString(ddlidfondo, consulta);

            consulta = "select nombre_sec from seccion";
            obj1.cargar_DropDownListString(ddlseccion, consulta);

            consulta = "select id_seccion from seccion";
            obj1.cargar_DropDownListString(ddlidseccion, consulta);

            GenerarAños(ddlaño);

            //carga todas las unidades administrativas existentes
            consulta = "select nombre_unid_admva from unidad_admva";
            obj1.cargar_DropDownListString(ddluadmva, consulta);

            consulta = "select id_unid_admva from unidad_admva";
            obj1.cargar_DropDownListString(ddlIduadmva, consulta);

            CargarGenerarFunciones(DdlFuncion);

            CargarGenerarAcceso(DdlAcceso);

            CargarGenerarValPrim(DdlValPrim);

            CargarGenerarTipoExp(DdlTipExp);

            CargarGenerarDestFin(DdlDestFin);

            CargarGenerarValSec(DdlValSec);

            //carga responsable de la captura del exp
            consulta = "select nombre_usr from usuario";

            CargarPeriodoConservacion(DdlPlazoConser);


        }
        public void Genera_expediente(DropDownList DdlNoExp)
        {
            string consulta = "SELECT COUNT(no_exp) AS totalExp FROM expediente WHERE clasificacion_exp like '"+
                idFondo+"%'";
            
            //obj1.cargar_TextBoxInt(txtNoExp, consulta);
            

            int res = obj1.cargar_DropDownListInt(DdlNoExp, consulta);

            //if (res <= 0)//si regreso 0, significa que seria el primer exp de su tipo
            //{
            //    txtNoExp.Text = "1";
            //}
            //else
            //{
            //    txtNoExp.Text = (res + 1).ToString();
            //}
        }
        public void GenerarAños(DropDownList ddlaño)
        {

            ddlaño.Items.Clear();
            ddlaño.Items.Add("Selecciona");
            for (int i= DateTime.Now.Year; i >= 1980; i--)
            {
                ddlaño.Items.Add(i.ToString());
            }
        }
        public void CargarGenerarFunciones(DropDownList DdlDatos)
        {
            DdlDatos.Items.Clear();
            DdlDatos.Items.Add("Selecciona");
            DdlDatos.Items.Add("Sustantiva");
            DdlDatos.Items.Add("Común");
        }
        public void CargarGenerarAcceso(DropDownList DdlDatos)
        {
            DdlDatos.Items.Clear();
            DdlDatos.Items.Add("Selecciona");
            DdlDatos.Items.Add("Público");
            DdlDatos.Items.Add("Reservado");
            DdlDatos.Items.Add("Confidencial");
        }
        public void CargarGenerarValPrim(DropDownList DdlDatos)
        {
            DdlDatos.Items.Clear();
            DdlDatos.Items.Add("Selecciona");
            DdlDatos.Items.Add("Administrativo");
            DdlDatos.Items.Add("Legal");
            DdlDatos.Items.Add("Fiscal");
        }
        public void CargarGenerarTipoExp(DropDownList DdlDatos)
        {
            DdlDatos.Items.Clear();
            DdlDatos.Items.Add("Selecciona");
            DdlDatos.Items.Add("Trámite");
            DdlDatos.Items.Add("Concentración");
        }
        public void CargarGenerarDestFin(DropDownList DdlDatos)
        {
            DdlDatos.Items.Clear();
            DdlDatos.Items.Add("Selecciona");
            DdlDatos.Items.Add("Baja documental");
            DdlDatos.Items.Add("Archivo histórico");
        }
        public void CargarGenerarValSec(DropDownList DdlDatos)
        {
            DdlDatos.Items.Clear();
            DdlDatos.Items.Add("Selecciona");
            DdlDatos.Items.Add("Evidencial");
            DdlDatos.Items.Add("Testimonial");
            DdlDatos.Items.Add("Informativo");
        }
        public void CargarSeccion(
            DropDownList ddlserie,
            DropDownList ddlidseccion,
            DropDownList ddlidserie)
        {
            //inicializa y carga las series correspondientes a la seccion elegida
            //en los dropdownlost correspondientes
            ddlserie.Items.Clear();
            string consulta = "select descripcion_serie from serie " +
                "where id_seccion= '" + ddlidseccion.Text +
                "'";
            obj1.cargar_DropDownListString(ddlserie, consulta);

            ddlidserie.Items.Clear();
            consulta = "select id_serie from serie " +
                "where id_seccion= '" + ddlidseccion.Text +
                "'";
            obj1.cargar_DropDownListString(ddlidserie, consulta);
        }
        public void CargarUadmva(
            DropDownList ddlIduadmva, 
            DropDownList ddluadmva,
            DropDownList ddlsubuadmva,
            DropDownList ddlidsubuadmva,
            DropDownList DdlAutorizadorExp,
            DropDownList DdlIdAutorizadorExp
            )
        {
            //busca la clave de la admva seleccionado
            buscarIdCorrespondiente(ddluadmva, ddlIduadmva);

            //inicializa y carga los sub elementos correspondientes a la 
            //categoria superior elegida
            //en el dropdownlist correspondiente
            ddlsubuadmva.Items.Clear();
            string consulta = "select nombre_unid_admva from unidad_admva " +
                "where id_unid_admva_pertenencia= '" + ddlIduadmva.Text +
                "'";
            obj1.cargar_DropDownListString(ddlsubuadmva, consulta);

            //carga los datos
            ddlidsubuadmva.Items.Clear();
            consulta = "select id_unid_admva from unidad_admva " +
                "where Id_unid_admva_pertenencia= '" + ddlIduadmva.Text +
                "'";
            obj1.cargar_DropDownListString(ddlidsubuadmva, consulta);

            //Carga el nombre de los posibles autorizadores en la parte final del expediente
            DdlAutorizadorExp.Items.Clear();
            consulta = "select usuario.nom_com_usr "+
                "from usuario, unidad_admva "+
                "where usuario.id_unid_admva_pertenece = unidad_admva.id_unid_admva "+
                "and unidad_admva.id_unid_admva = '"+ ddlIduadmva.Text + "'";

            obj1.cargar_DropDownListString(DdlAutorizadorExp, consulta);

            ddlidsubuadmva.Focus();
        }
        public void CargarSubUadmva(
            DropDownList ddlIduadmva,
            DropDownList ddlidsubuadmva,
            DropDownList ddlsubuadmva,
            DropDownList ddlcargoresp,
            DropDownList ddlidcargoresp,
            DropDownList DdlAutorizadorExp, 
            DropDownList DdlIdAutorizadorExp,
            DropDownList DdlRespCaptura,
            DropDownList DdlIdRespCaptura
            )
        {
            //busca el id en el dropdownlist que le corresponde al nombre seleccionado
            buscarIdCorrespondiente(ddlsubuadmva, ddlidsubuadmva);

            /*busca a todos los usuarios que pertenecen a la area actual y superior */
            string consulta = "select usuario.nom_com_usr " +
            "from usuario, unidad_admva where " +
            "usuario.id_unid_admva_pertenece = unidad_admva.id_unid_admva " +
            "and (unidad_admva.id_unid_admva = '" + ddlidsubuadmva.Text + "' "+
            "or unidad_admva.id_unid_admva = '" + ddlIduadmva.Text + "' " +
            "or unidad_admva.Id_unid_admva_pertenencia = " +
            "(select unidad_admva.id_unid_admva_pertenencia from unidad_admva "+
            "where unidad_admva.Id_unid_admva = '"+ ddlIduadmva.Text + "'))";

            //carga los nombres de los posibles usuarios responsable;
            obj1.cargar_DropDownListString(ddlcargoresp, consulta);
            //carga los nombres de los posibles autorizadores
            obj1.cargar_DropDownListString(DdlAutorizadorExp, consulta);
            //carga los nombres de los posibles capturistas
            obj1.cargar_DropDownListString(DdlRespCaptura, consulta);

            /*busca a todos los id de los usuarios que pertenecen a cierta area*/
            consulta = "select usuario.id_usr " +
               "from usuario, unidad_admva where " +
               "usuario.id_unid_admva_pertenece = unidad_admva.id_unid_admva " +
               "and (unidad_admva.id_unid_admva = '" + ddlidsubuadmva.Text + "' " +
               "or unidad_admva.id_unid_admva = '" + ddlIduadmva.Text + "' " +
               "or unidad_admva.Id_unid_admva_pertenencia = " +
               "(select unidad_admva.id_unid_admva_pertenencia from unidad_admva " +
               "where unidad_admva.Id_unid_admva = '" + ddlIduadmva.Text + "'))";

            //carga los id de los usuarios responsable;
            obj1.cargar_DropDownListString(ddlidcargoresp, consulta);
            //carga los nombres de los posibles autorizadores
            obj1.cargar_DropDownListString(DdlIdAutorizadorExp, consulta);
            //carga los nombres de los posibles captturistas
            obj1.cargar_DropDownListString(DdlIdRespCaptura, consulta);

            ddlsubuadmva.Focus();
        }

        public void CargarResp(DropDownList ddlcargoresp, DropDownList ddlidcargoresp)
        {
            buscarIdCorrespondiente(ddlcargoresp, ddlidcargoresp);
        }
        public void CargarDatosResp(
            DropDownList ddlsubuadmva,
            DropDownList ddlidcargoresp,
            System.Web.UI.WebControls.TextBox TxtNomRespExp,
            System.Web.UI.WebControls.TextBox TxtCargoRespExp,
            System.Web.UI.WebControls.TextBox TxtTelRespExp,
            System.Web.UI.WebControls.TextBox TxtEmailRespExp,
            System.Web.UI.WebControls.TextBox TxtUnidAdmvaACargo)
        {   
            /*busca los datos del usuario resp de area del exp*/
            string consulta = "select usuario.nom_com_usr, "+
                "usuario.nom_cargo_usr, "+
                "usuario.telefono_contacto, "+
                "usuario.email_usr, "+
                "usuario.id_unid_admva_pertenece "+
                "from usuario where usuario.id_usr = '"+ ddlidcargoresp.Text + "'"; 

            obj1.CargarObjetosString(
                TxtNomRespExp,
                TxtCargoRespExp,
                TxtTelRespExp,
                TxtEmailRespExp,
                consulta);

            TxtUnidAdmvaACargo.Text = ddlsubuadmva.Text;
            //obj1.cargar_DropDownListString(ddlcargoresp, consulta);

        }

        public void inicioOcultar(
            DropDownList DdlVincOtros
            
                    )
        {
            DdlVincOtros.Visible = false;
            
        }
        public void inicioDeshabilitar(
            System.Web.UI.WebControls.TextBox TxtFrmtoSoporte)
        {
            TxtFrmtoSoporte.Enabled = false;
        }
        public void CargarVincOtros(
            System.Web.UI.WebControls.RadioButton RdbSiVinculado,
            System.Web.UI.WebControls.RadioButton RdbNoVinculado,
            DropDownList DdlVincOtros)
        {
            try
            {
                
                if (RdbNoVinculado.Checked == true)
                {   
                    DdlVincOtros.Items.Add("NINGUNO");
                    DdlVincOtros.SelectedIndex = 0;

                }
                else {
                    if (RdbSiVinculado.Checked == true)
                    {
                        string consulta = "select clasificacion_exp from expediente";
                        obj1.cargar_DropDownListString(DdlVincOtros, consulta);

                    }
                }
                
            }
            catch(Exception e)
            {
                MessageBox.Show("Se genero el siguiente error\nen tiempo de ejecución:\n" + e.Message);
            }
            
        }
        public void CargarAutorizadorExp(DropDownList ddlAutorizadorExp, DropDownList ddlIdAutorizadorExp)
        {
            buscarIdCorrespondiente(ddlAutorizadorExp, ddlIdAutorizadorExp);
        }
        public void CargarPeriodoConservacion(DropDownList DdlPlazoConser)
        {
            //se generan periodos en años del 1 al 15
            DdlPlazoConser.Items.Clear();
            DdlPlazoConser.Items.Add("Selecciona");
            for (int i = 1; i < 16; i++)
            {
                DdlPlazoConser.Items.Add(i.ToString());
            }
        }
        public void buscarIdCorrespondiente(DropDownList ddlnombre, DropDownList ddlid)
        {
            //busca la clave del DropDownList Nombre seleccionado
            ddlid.SelectedIndex =
                ddlnombre.Items.IndexOf(ddlnombre.Items.FindByValue(ddlnombre.Text));
        }
        public void CargarUbicTopog(
            DropDownList ddlidfondo,
            DropDownList DdlNoEd, 
            DropDownList DdlIdNoEd)
        {
            string consulta = "select DescripcionEd, IdEdificio from edificio " +
                "where IdFondo= '" + ddlidfondo.Text + "'";
            obj1.cargar_DropDownListString(DdlNoEd, DdlIdNoEd, consulta);

            
            
        }
        public void CargarPisos(
            DropDownList DdlIdNoEd,
            DropDownList DdlNoPiso,
            DropDownList DdlIdNoPiso,
            DropDownList ddlidfondo,
            System.Web.UI.WebControls.TextBox TxtNomFondo,
            System.Web.UI.WebControls.TextBox TxtDirFondo,
            System.Web.UI.WebControls.TextBox TxtObsFondo)
        {   

            string consulta = "select DescripcionPiso, IdPisoEd from Piso " +
                "where IdEdificio= '" + DdlIdNoEd.Text + "'";
            obj1.cargar_DropDownListString(DdlNoPiso, DdlIdNoPiso, consulta);

            consulta = "select nombre_fondo, direccion_fondo, Observaciones from  fondo " +
                "where id_fondo = '" + ddlidfondo.Text + "'";
            obj1.CargarObjetosString(TxtNomFondo, TxtDirFondo, TxtObsFondo, consulta);
        }
        public void CargarPasillos(
            DropDownList DdlIdNoPiso,
            DropDownList DdlNoPasillo,
            DropDownList DdlIdNoPasillo)
        {
            string consulta = "select DescripcionPasillo, IdPasillo from Pasillo " +
            "where IdPisoEd= '" + DdlIdNoPiso.Text + "'";
            obj1.cargar_DropDownListString(DdlNoPasillo, DdlIdNoPasillo, consulta);
        }
        public void CargarEstantes(
            DropDownList DdlIdNoPasillo,
            DropDownList DdlNoEst,
            DropDownList DdlIdNoEst)
        {
            string consulta = "select DescripcionEst, IdEstante from Estante " +
            "where IdPasillo= '" + DdlIdNoPasillo.Text + "'";
            obj1.cargar_DropDownListString(DdlNoEst, DdlIdNoEst, consulta);
        }
        public void CargarCharolas(
            DropDownList DdlIdNoEst,
            DropDownList DdlNoChar,
            DropDownList DdlIdNoChar)
        {
            string consulta = "select DescripcionChar, IdCharola from Charola " +
            "where IdEstante= '" + DdlIdNoEst.Text + "'";
            obj1.cargar_DropDownListString(DdlNoChar, DdlIdNoChar, consulta);
        }
        public void CargarUnidCajas(
            DropDownList DdlIdNoChar,
            DropDownList DdlNoCaja,
            DropDownList DdlIdNoCaja)
        {
            string consulta = "select DescUnidIsnCaja, IdUnidInsCaja from UnidadInstOcaja " +
         "where IdCharola= '" + DdlIdNoChar.Text + "'";
            obj1.cargar_DropDownListString(DdlNoCaja, DdlIdNoCaja, consulta);
        }
        public int Guardar()
        {
            string consulta = "insert into expediente values('"
                + Clasificación + "', '"+ idFondo + "', '"+ idseccion + "', '"+ idserie+ "',"+
                no_exp +","+ año +", " +
                "'"+ id_unid_admva_resp + "', '"+ id_area_prod + "', '"+ id_resp_exp + "', '"+ resumen_exp + "', '"+ asunto_exp + "','"+ funcion_exp + "', '"+ acceso_exp + "', '"+ val_prim_exp + "', " +
                "'"+ fec_ext_ini_exp + "', '" + fec_ext_fin_exp + "', "+
                no_legajo_exp + ", " + no_fojas_exp + ", " +
                "'no', 'NINGUNO', '"+ formato_Soporte +"', "+
                plazo_conservacion_exp +", " +
                "'"+ tipo_exp + "', '"+ destino_final_exp + "', '"+ valores_secundarios_exp + "', '"+ id_ubic_topog + "', "+
                "'"+ IdEdificio + "', '"+ IdPisoEd + "', '"+ IdPasillo + "', '"+ IdEstante + "', '"+ IdCharola + "', '"+ IdUnidInsCaja + "', "+
                "'"+ fecha_alta_exp + "', "+
                "'"+ id_capturista_exp + "', '"+ id_autorizador_exp + "')";

            int res = obj1.Guardar(consulta);

            return res;
        }

        public Expediente Buscar(string valor)
        {
            string consulta = "select * from expediente where "+
                "clasificacion_exp = '"+ valor + "'";

            Expediente MiExpBuscado = obj1.Buscar(consulta, this);

            //hasta aca vamos, 
            //obj1.cargarBusqueda(MiExpBuscado);

            if (MiExpBuscado != null)
            {
                return MiExpBuscado;
            }
            else
            {
                return null;
            }
                
        }

        public void cargarExpEncontrado(
            Expediente miExp,
            DropDownList ddluadmva,
            DropDownList ddlIduadmva,
            DropDownList ddlsubuadmva,
            DropDownList ddlidsubuadmva
            )
        {
            //ddluadmva.Text = miExp.Clasificación;
            ddlIduadmva.Text = miExp.id_unid_admva_resp;
            //ddlsubuadmva.Text = miExp.
            ddlidsubuadmva.Text = miExp.id_area_prod;
        }


    }

//    Public Class clsTools
//    Shared Sub MostrarMensaje(ByVal Mensaje As String, ByVal Pagina As System.Web.UI.Page)
//        Mensaje = Mensaje.Replace("\", "\\")
//        Mensaje = Mensaje.Replace(vbCrLf, "\n")
//        Mensaje = Mensaje.Replace(vbTab, "\t")
//        Mensaje = Mensaje.Replace("""", "''")

//        Dim scriptStr As String = "alert(""" & Mensaje & """);"
//        ScriptManager.RegisterStartupScript(Pagina, Pagina.GetType, "msgBox", scriptStr, True)
//    End Sub
//End Class
//Ejemplo de uso:

//clsTools.MostrarMensaje("Mensaje", Me)
}