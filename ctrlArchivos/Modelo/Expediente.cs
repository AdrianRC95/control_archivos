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
            /*string consulta = "SELECT COUNT(no_exp) AS totalExp FROM expediente WHERE clasificacion_exp like '"+
                idFondo+"%'";*/


            //Con esta consulta se pretende obtener el consecutivo del No. de expediente para generar uno nuevo
            string consulta = "SELECT TOP 1 (no_exp + 1) AS no_exp_nuevo FROM expediente WHERE clasificacion_exp like '" +
                idFondo + "%' ORDER BY no_exp DESC;";

            //obj1.cargar_TextBoxInt(txtNoExp, consulta);


            int res = obj1.cargar_DropDownListInt(DdlNoExp, consulta);

            if (DdlNoExp.Items.Count > 1) //Si hay elemento en la lista lo tomamos y generamos los numeros descendientes
            {
                int nuevo_expediente = Convert.ToInt32(DdlNoExp.Items[1].ToString()); //Tomamos el primer elemento
                for (int i = nuevo_expediente-1; i > 0; i--)
                {
                    DdlNoExp.Items.Add(i.ToString());
                }
            }
            else //No hay datos por lo tanto será el primer expediente
            {
                DdlNoExp.Items.Add("1");
            }

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
                DdlVincOtros.Items.Clear();
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

        //Proceso inverso de acuerdo al ID seleccionado muestra el nombre o texto correspondiente
        public void buscarNombreCorrespondiente(DropDownList ddlnombre, DropDownList ddlid)
        {
            //busca la clave del DropDownList Nombre seleccionado
            ddlnombre.SelectedIndex =
                ddlid.Items.IndexOf(ddlid.Items.FindByValue(ddlid.Text));
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
                + Clasificación + "', '" + idFondo + "', '" + idseccion + "', '" + idserie + "'," +
                no_exp + "," + año + ", " +
                "'" + id_unid_admva_resp + "', '" + id_area_prod + "', '" + id_resp_exp + "', '" + resumen_exp + "', '" + asunto_exp + "','" + funcion_exp + "', '" + acceso_exp + "', '" + val_prim_exp + "', " +
                "'" + fec_ext_ini_exp.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "', '" + fec_ext_fin_exp.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "', "+
                no_legajo_exp + ", " + no_fojas_exp + ", " +
                "'no', 'NINGUNO', '"+ formato_Soporte +"', "+
                plazo_conservacion_exp +", " +
                "'"+ tipo_exp + "', '"+ destino_final_exp + "', '"+ valores_secundarios_exp + "', '"+ id_ubic_topog + "', "+
                "'"+ IdEdificio + "', '"+ IdPisoEd + "', '"+ IdPasillo + "', '"+ IdEstante + "', '"+ IdCharola + "', '"+ IdUnidInsCaja + "', "+
                "'"+ fecha_alta_exp.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "', "+
                "'"+ id_capturista_exp + "', '"+ id_autorizador_exp + "')";
            //MessageBox.Show(consulta);
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
            DropDownList ddlidsubuadmva,
            DropDownList DdlAutorizadorExp,
            DropDownList DdlIdAutorizadorExp,
            DropDownList ddlcargoresp,
            DropDownList ddlidcargoresp,
            DropDownList DdlRespCaptura,
            DropDownList DdlIdRespCaptura,
            System.Web.UI.WebControls.TextBox TxtNomRespExp,
            System.Web.UI.WebControls.TextBox TxtCargoRespExp,
            System.Web.UI.WebControls.TextBox TxtTelRespExp,
            System.Web.UI.WebControls.TextBox TxtEmailRespExp,
            System.Web.UI.WebControls.TextBox TxtUnidAdmvaACargo,
            System.Web.UI.WebControls.TextBox TxtResumen,
            System.Web.UI.WebControls.TextBox TxtAsuntoExp,
            DropDownList DdlFuncion,
            DropDownList DdlAcceso,
            DropDownList DdlValPrim,
            System.Web.UI.WebControls.TextBox TxtFecExtIni,
            System.Web.UI.WebControls.TextBox TxtFecExtFin,
            System.Web.UI.WebControls.TextBox TxtNoLegajo,
            System.Web.UI.WebControls.TextBox TxtNoFojas,
            System.Web.UI.WebControls.RadioButton RdbSiVinculado,
            System.Web.UI.WebControls.RadioButton RdbNoVinculado,
            DropDownList DdlVincOtros,
            System.Web.UI.WebControls.CheckBox ChkPapel,
            System.Web.UI.WebControls.CheckBox ChkFoto,
            System.Web.UI.WebControls.CheckBox ChkUsb,
            System.Web.UI.WebControls.CheckBox ChkDisco,
            System.Web.UI.WebControls.TextBox TxtFrmtoSoporte,
            DropDownList DdlPlazoConser,
            DropDownList DdlTipExp,
            DropDownList DdlDestFin,
            DropDownList DdlValSec,
            System.Web.UI.WebControls.Label LblIdUbicTopog,
            DropDownList DdlNoEd,
            DropDownList DdlIdNoEd,
            System.Web.UI.WebControls.TextBox TxtNomFondo,
            DropDownList DdlNoPiso,
            DropDownList DdlIdNoPiso,
            DropDownList DdlNoPasillo,
            DropDownList DdlIdNoPasillo,
            DropDownList DdlNoEst,
            DropDownList DdlIdNoEst,
            DropDownList DdlNoChar,
            DropDownList DdlIdNoChar,
            DropDownList DdlNoCaja,
            DropDownList DdlIdNoCaja,
            System.Web.UI.WebControls.TextBox TxtDirFondo,
            System.Web.UI.WebControls.TextBox TxtObsFondo,
            DropDownList ddlidfondo,
            System.Web.UI.WebControls.TextBox TxtFechaCaptura
            )
        {
            //Unidad Administrativa Responsable
            ddlIduadmva.Text = miExp.id_unid_admva_resp; //Seleccionr list de acuerdo a ID
            buscarNombreCorrespondiente(ddluadmva, ddlIduadmva); //Mostrar nombre correspondiente
            //Lennar List de datos siguiente (Area, depto...);
            CargarUadmva(ddlIduadmva, ddluadmva,
                ddlsubuadmva, ddlidsubuadmva,
                DdlAutorizadorExp, DdlIdAutorizadorExp);

            //Area, depto o Unidad Productora
            ddlidsubuadmva.Text = miExp.id_area_prod; //Seleccionar list de acuerdo a ID
            buscarNombreCorrespondiente(ddlsubuadmva, ddlidsubuadmva); //Mostrar nombre correspondiente
            //Lennar List de datos siguiente (Nombre del responsable);
            CargarSubUadmva(ddlIduadmva, ddlidsubuadmva,
                ddlsubuadmva, ddlcargoresp, ddlidcargoresp,
                DdlAutorizadorExp, DdlIdAutorizadorExp, DdlRespCaptura, DdlIdRespCaptura);

            //Nombre del responsable
            ddlidcargoresp.Text = miExp.id_resp_exp; //Seleccionar List
            buscarNombreCorrespondiente(ddlcargoresp, ddlidcargoresp);
            //LLenar datos del Jefe area, responsable del expediente
            CargarDatosResp(ddlsubuadmva, ddlidcargoresp,
                TxtNomRespExp, TxtCargoRespExp,
                TxtTelRespExp, TxtEmailRespExp, TxtUnidAdmvaACargo);

            TxtResumen.Text = miExp.resumen_exp;    //Resumen del contenido
            TxtAsuntoExp.Text = miExp.asunto_exp;   //Asunto
            DdlFuncion.Text = miExp.funcion_exp;    //Funcion
            DdlAcceso.Text = miExp.acceso_exp;      //Acceso
            DdlValPrim.Text = miExp.val_prim_exp;   //Valores primarios
            TxtFecExtIni.Text = miExp.fec_ext_ini_exp.ToString("yyyy-MM-dd");  //Fecha extrema inicial
            TxtFecExtFin.Text = miExp.fec_ext_fin_exp.ToString("yyyy-MM-dd");  //Fecha extrema final
            TxtNoLegajo.Text = miExp.no_legajo_exp.ToString();  //Numero de legado
            TxtNoFojas.Text = miExp.no_fojas_exp.ToString();    //Numero fojas

            //Vinculacion con otro expediente
            if (miExp.vinc_otro_exp == "si")
            {
                RdbSiVinculado.Checked = true;
            }
            else if (miExp.vinc_otro_exp == "no")
            {
                RdbNoVinculado.Checked = true;
            }
            CargarVincOtros(RdbSiVinculado, RdbNoVinculado, DdlVincOtros);
            DdlVincOtros.Text = miExp.id_exp_vincd;
            DdlVincOtros.Visible = true;

            //Formato de soporte
            if (miExp.formato_Soporte.Contains("Papel"))
            {
                ChkPapel.Checked = true;
                ChkPapel.Enabled = false;
            }
            if (miExp.formato_Soporte.Contains("Fotografía"))
            {
                ChkFoto.Checked = true;
                ChkFoto.Enabled = false;
            }
            if (miExp.formato_Soporte.Contains("USB"))
            {
                ChkUsb.Checked = true;
                ChkUsb.Enabled = false;
            }
            if (miExp.formato_Soporte.Contains("Disco"))
            {
                ChkDisco.Checked = true;
                ChkDisco.Enabled = false;
            }
            TxtFrmtoSoporte.Text = miExp.formato_Soporte;
            TxtFrmtoSoporte.Visible = true;

            DdlPlazoConser.Text = miExp.plazo_conservacion_exp.ToString();  //Plazo de conservacion
            DdlTipExp.Text = miExp.tipo_exp;                                //Tipo expediente    
            DdlDestFin.Text = miExp.destino_final_exp;                      //Destino final
            DdlValSec.Text = miExp.valores_secundarios_exp;                 //Valores secundarios

            //Ubicación topográfica
            LblIdUbicTopog.Text = miExp.id_ubic_topog;
            //Número de edificio
            DdlIdNoEd.Text = miExp.IdEdificio;
            buscarNombreCorrespondiente(DdlNoEd, DdlIdNoEd);
            //Cargar info piso
            CargarPisos(DdlIdNoEd, DdlNoPiso, DdlIdNoPiso, ddlidfondo,
                TxtNomFondo, TxtDirFondo, TxtObsFondo);
            //Numero de piso
            DdlIdNoPiso.Text = miExp.IdPisoEd;
            buscarNombreCorrespondiente(DdlNoPiso, DdlIdNoPiso);
            //Cargar pasillos
            CargarPasillos(DdlIdNoPiso, DdlNoPasillo, DdlIdNoPasillo);
            //Numero de pasillo
            DdlIdNoPasillo.Text = miExp.IdPasillo;
            buscarNombreCorrespondiente(DdlNoPasillo, DdlIdNoPasillo);
            //Cargar Estantes
            CargarEstantes(DdlIdNoPasillo, DdlNoEst, DdlIdNoEst);
            //Numero estante
            DdlIdNoEst.Text = miExp.IdEstante;
            buscarNombreCorrespondiente(DdlNoEst, DdlIdNoEst);
            //Cargar charolas
            CargarCharolas(DdlIdNoEst, DdlNoChar, DdlIdNoChar);
            //Numero charola
            DdlIdNoChar.Text = miExp.IdCharola;
            buscarNombreCorrespondiente(DdlNoChar, DdlIdNoChar);
            //Cargar unidad de instalacion
            CargarUnidCajas(DdlIdNoChar, DdlNoCaja, DdlIdNoCaja);
            //Unidad de instalacion o numero de la caja
            DdlIdNoCaja.Text = miExp.IdUnidInsCaja;
            buscarNombreCorrespondiente(DdlNoCaja, DdlIdNoCaja);

            //Lugar, fecha
            TxtFechaCaptura.Text = miExp.fecha_alta_exp.ToString("yyyy-MM-dd");
            //Capturado por
            DdlIdRespCaptura.Text = miExp.id_capturista_exp;
            buscarNombreCorrespondiente(DdlRespCaptura, DdlIdRespCaptura);
            //Autorizado por
            DdlIdAutorizadorExp.Text = miExp.id_autorizador_exp;
            buscarNombreCorrespondiente(DdlAutorizadorExp, DdlIdAutorizadorExp);
        }

        public int Actualizar()
        {
            string consulta = "update expediente set "
                + "id_unid_admva_resp='" + id_unid_admva_resp + "', "
                + "id_area_prod='" + id_area_prod + "', "
                + "id_resp_exp='" + id_resp_exp + "', "
                + "resumen_exp='" + resumen_exp + "', "
                + "asunto_exp='" + asunto_exp + "', "
                + "funcion_exp='" + funcion_exp + "', "
                + "acceso_exp='" + acceso_exp + "', "
                + "val_prim_exp='" + val_prim_exp + "', "
                + "fec_ext_ini_exp='" + fec_ext_ini_exp.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "', "
                + "fec_ext_fin_exp='" + fec_ext_fin_exp.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "', "
                + "no_legajo_exp=" + no_legajo_exp + ", "
                + "no_fojas_exp=" + no_fojas_exp + ", "
                + "vinc_otro_exp='no', id_exp_vincd='NINGUNO', "
                + "formato_soporte='" + formato_Soporte + "', "
                + "plazo_conservacion_exp=" + plazo_conservacion_exp + ", "
                + "tipo_exp='" + tipo_exp + "', "
                + "destino_final_exp='" + destino_final_exp + "', "
                + "valores_secundarios_exp='" + valores_secundarios_exp + "', "
                + "id_ubic_topog='" + id_ubic_topog + "', "
                + "IdEdificio='" + IdEdificio + "', "
                + "IdPisoEd='" + IdPisoEd + "', "
                + "IdPasillo='" + IdPasillo + "', "
                + "IdEstante='" + IdEstante + "', "
                + "IdCharola='" + IdCharola + "', "
                + "IdUnidInsCaja='" + IdUnidInsCaja + "', "
                + "fecha_alta_exp='" + fecha_alta_exp.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "', "
                + "id_capturista_exp='" + id_capturista_exp + "', "
                + "id_autorizador_exp='" + id_autorizador_exp + "' "
                + "where clasificacion_exp='" + Clasificación + "'";
            //MessageBox.Show(consulta);
            int res = obj1.Guardar(consulta);
            return res;
        }

        public int Eliminar(String id_expediente)
        {
            String consulta = "DELETE FROM expediente WHERE clasificacion_exp='" + id_expediente + "';";
            int res = obj1.Guardar(consulta);
            return res;
        }

        /**
         * Con este método se corrige la forma de generar la clasficacion y ubicacion topologica
         * Para utilizarlo adecuadamente se debe asignar el atributo que se modifica en el formulario
         * a esta entidad y posteriormente obtener la nueva clasificacion
         * */
        public string generaClasificacion(string fondo, string seccion, string serie, string numero, string anio)
        {
            string n_clasificacion = "";
            n_clasificacion += fondo + "-";
            n_clasificacion += seccion + "-";
            n_clasificacion += serie + "-";
            n_clasificacion += numero + "-";
            n_clasificacion += anio;
            return n_clasificacion;
        }

        public string generaUbicacionTopog(string fondo, string edificio, string piso, string pasillo, string estante, string charola, string caja)
        {
            string topologica = "";
            topologica += fondo + "-";
            topologica += edificio + "-";
            topologica += piso + "-";
            topologica += pasillo + "-";
            topologica += estante + "-";
            topologica += charola + "-";
            topologica += caja;
            return topologica;
        }

        /**
         * En este caso se coloca el método en este lugar debido a que se sigue la estructura 
         * con la que se trabajo anteriormente
         */ 
        public void enlistarDatos(Table datos)
        {
            TableHeaderRow headerRow;
            TableHeaderCell headerCell;
            TableRow row;
            TableCell celda;

            headerRow = new TableHeaderRow();
            headerCell = new TableHeaderCell();
            headerCell.Text = "Clasificación";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Fondo";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Seccion";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Serie";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Numero";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Año";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Unidad Administrativa";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Area Productiva";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Responsable";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Resumen";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Asunto";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Funcion";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Acceso";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Valor primario";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Fecha Inicio";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Fecha Fin";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "No. Legado";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "No. Fojas";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Vinculado";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Exp. Vinculado";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Formato Soporte";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Plazo conservación";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Tipo";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Destino";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Valores Secundarios";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Ubicación Topológica";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Edificio";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Piso";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Pasillo";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Estante";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Charola";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Caja";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Fecha Alta";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Capturista";
            headerRow.Cells.Add(headerCell);
            headerCell = new TableHeaderCell();
            headerCell.Text = "Autorizador";
            headerRow.Cells.Add(headerCell);
            datos.Rows.Add(headerRow);
            string consulta = "select * from expediente";
            List<string[]> valores = obj1.buscarVarios(consulta);
            if (valores != null)
            {
                for (int i = 0; i < valores.Count; i++)
                {
                    row = new TableRow();
                    string[] fila_val = valores[i];

                    for (int j = 0; j < fila_val.Length; j++)
                    {
                        celda = new TableCell();
                        celda.Text = fila_val[j];
                        row.Cells.Add(celda);
                    }
                    datos.Rows.Add(row);
                }
            }
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