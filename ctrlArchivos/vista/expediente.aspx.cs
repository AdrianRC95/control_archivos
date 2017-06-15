using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ctrlArchivos.Modelo;

namespace ctrlArchivos.vista
{
    public partial class archivo : System.Web.UI.Page
    {

        

        Expediente miExp = new Expediente(); //from ctrlArchivos.Modelo;

        Usuario2 obj1 = new Usuario2(); //from metodo

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Validate initially to force asterisks
                // to appear before the first roundtrip.
                Validate();
                miExp.cargarDatosIniciales(
                    ddlfondo,
                    ddlidfondo,
                    ddlseccion,
                    ddlidseccion,
                    ddlserie,
                    ddlidserie,
                    ddlaño,
                    ddluadmva,
                    ddlIduadmva,
                    DdlFuncion,
                    DdlAcceso,
                    DdlValPrim,
                    DdlTipExp,
                    DdlDestFin,
                    DdlValSec,
                    DdlPlazoConser,
                    DdlRespCaptura,
                    DdlIdRespCaptura
                );
                miExp.inicioOcultar(
                    DdlVincOtros
                    
                    );
                miExp.inicioDeshabilitar(
                    TxtFrmtoSoporte
                    );
                btnActualizar.Visible = false;
                btnEliminar.Visible = false;
            }
            

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
          

            miExp.Clasificación = lblclasexp.Text;
            miExp.idFondo = ddlidfondo.Text;
            miExp.idseccion = ddlidseccion.Text;
            miExp.idserie = ddlidserie.Text;
            miExp.no_exp = int.Parse(DdlNoExp.Text);
            miExp.año = int.Parse(ddlaño.Text);
            miExp.id_unid_admva_resp = ddlIduadmva.Text;
            miExp.id_area_prod = ddlidsubuadmva.Text;
            miExp.id_resp_exp = ddlidcargoresp.Text;
            miExp.resumen_exp = TxtResumen.Text;
            miExp.asunto_exp = TxtAsuntoExp.Text;
            miExp.funcion_exp = DdlFuncion.Text;
            miExp.acceso_exp = DdlAcceso.Text;
            miExp.val_prim_exp = DdlValPrim.Text;
            miExp.fec_ext_ini_exp = DateTime.Parse(TxtFecExtIni.Text);
            miExp.fec_ext_fin_exp = DateTime.Parse(TxtFecExtFin.Text);
            miExp.no_legajo_exp = int.Parse(TxtNoLegajo.Text);
            miExp.no_fojas_exp = int.Parse(TxtNoFojas.Text);
            miExp.vinc_otro_exp = "Cambiar por DDL";
            miExp.id_exp_vincd = DdlVincOtros.Text;
            miExp.formato_Soporte = TxtFrmtoSoporte.Text;//validar que se seleccione al menos 1 o no este vacio
            miExp.plazo_conservacion_exp = int.Parse(DdlPlazoConser.Text);
            miExp.tipo_exp = DdlTipExp.Text;
            miExp.destino_final_exp = DdlDestFin.Text;
            miExp.valores_secundarios_exp = DdlValSec.Text;
            miExp.id_ubic_topog = LblIdUbicTopog.Text;
            miExp.IdEdificio = DdlIdNoEd.Text;
            miExp.IdPisoEd = DdlIdNoPiso.Text;
            miExp.IdPasillo = DdlIdNoPasillo.Text;
            miExp.IdEstante = DdlIdNoEst.Text;
            miExp.IdCharola = DdlIdNoChar.Text;
            miExp.IdUnidInsCaja = DdlIdNoCaja.Text;
            miExp.fecha_alta_exp = DateTime.Parse(TxtFechaCaptura.Text);
            miExp.id_capturista_exp = DdlIdRespCaptura.Text;
            miExp.id_autorizador_exp = DdlIdAutorizadorExp.Text;

            int r = miExp.Guardar();
            
            if (r == 1)
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "msgCorrecto('Datos ingresados correctamente :)', '/vista/expediente.aspx');", true);
            else if (r == 0)
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "ErAgregar();", true);
            else
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "ErAgregar();", true);
            
        }

        protected void ddlfondo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblclasexp.Text = ""; //siempre que se elija el fondo se inicia la clasificacion

            //busca la clave del fondo seleccionado
            miExp.buscarIdCorrespondiente(ddlfondo, ddlidfondo);
            miExp.CargarUbicTopog(ddlidfondo, DdlNoEd, DdlIdNoEd);

            //recupera el fondo y genera el numero del ultimo expediente y otro mas
            miExp.idFondo = ddlidfondo.Text;
            miExp.Genera_expediente(DdlNoExp);
            ddlfondo.Focus();

            //inicia la generacion de la clave de clasificacion y ubicacion topografica del expediente
            //LblIdUbicTopog.Text = ddlidfondo.Text + "-";
            lblclasexp.Text = miExp.generaClasificacion(ddlidfondo.Text, ddlidseccion.Text, ddlidserie.Text, DdlNoExp.Text, ddlaño.Text);
            LblIdUbicTopog.Text = miExp.generaUbicacionTopog(ddlidfondo.Text, DdlIdNoEd.Text, DdlIdNoPiso.Text, DdlIdNoPasillo.Text, DdlIdNoEst.Text, DdlIdNoChar.Text, DdlIdNoCaja.Text);
        }

        protected void ddlseccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //busca la clave del fondo seleccionado
            miExp.buscarIdCorrespondiente(ddlseccion, ddlidseccion);
           
            //lblclasexp.Text += "-" + ddlidseccion.Text;

            miExp.CargarSeccion(ddlserie, ddlidseccion, ddlidserie);

            ddlseccion.Focus();

            lblclasexp.Text = miExp.generaClasificacion(ddlidfondo.Text, ddlidseccion.Text, ddlidserie.Text, DdlNoExp.Text, ddlaño.Text);
        }

        protected void ddlserie_SelectedIndexChanged(object sender, EventArgs e)
        {
            //busca la clave de la serie seleccionada
            miExp.buscarIdCorrespondiente(ddlserie, ddlidserie);
            
            //lblclasexp.Text += "-" + ddlidserie.Text;
            ddlserie.Focus();

            lblclasexp.Text = miExp.generaClasificacion(ddlidfondo.Text, ddlidseccion.Text, ddlidserie.Text, DdlNoExp.Text, ddlaño.Text);
        }

        protected void DdlNoExp_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlNoExp.Focus();
            lblclasexp.Text = miExp.generaClasificacion(ddlidfondo.Text, ddlidseccion.Text, ddlidserie.Text, DdlNoExp.Text, ddlaño.Text);
        }

        protected void ddlaño_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblclasexp.Text += "-" +DdlNoExp.Text + "-" + ddlaño.Text;
            ddlaño.Focus();
            lblclasexp.Text = miExp.generaClasificacion(ddlidfondo.Text, ddlidseccion.Text, ddlidserie.Text, DdlNoExp.Text, ddlaño.Text);
        }

        protected void ddluadmva_SelectedIndexChanged(object sender, EventArgs e)
        {
            miExp.CargarUadmva(ddlIduadmva, ddluadmva, 
                ddlsubuadmva, ddlidsubuadmva,
                DdlAutorizadorExp, DdlIdAutorizadorExp);
            ddlsubuadmva.Focus();
        }

        protected void ddlsubuadmva_SelectedIndexChanged(object sender, EventArgs e)
        {
            miExp.CargarSubUadmva(ddlIduadmva, ddlidsubuadmva, 
                ddlsubuadmva, ddlcargoresp, ddlidcargoresp,
                DdlAutorizadorExp, DdlIdAutorizadorExp, DdlRespCaptura, DdlIdRespCaptura);
            ddlcargoresp.Focus();
        }

        protected void ddlcargoresp_SelectedIndexChanged(object sender, EventArgs e)
        {
            miExp.CargarResp(ddlcargoresp, ddlidcargoresp);
            miExp.CargarDatosResp(ddlsubuadmva, ddlidcargoresp, 
                TxtNomRespExp, TxtCargoRespExp, 
                TxtTelRespExp, TxtEmailRespExp, TxtUnidAdmvaACargo);
            ddlcargoresp.Focus();
        }

        protected void DdlFuncion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlFuncion.Focus();
        }

        protected void DdlAcceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlAcceso.Focus();
        }

        protected void DdlValPrim_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlValPrim.Focus();
        }

        protected void DdlDestFin_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDestFin.Focus();
        }

        protected void DdlTipExp_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlTipExp.Focus();
        }

        protected void DdlValSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlValSec.Focus();
        }

        protected void DdlAutorizadorExp_SelectedIndexChanged(object sender, EventArgs e)
        {
            miExp.CargarAutorizadorExp(DdlAutorizadorExp, DdlIdAutorizadorExp);
            DdlAutorizadorExp.Focus();
        }

        protected void RdbSiVinculado_CheckedChanged(object sender, EventArgs e)
        {
            DdlVincOtros.Visible = true;
            
            
            miExp.CargarVincOtros(RdbSiVinculado, RdbNoVinculado, DdlVincOtros);
            //miExp.buscarIdCorrespondiente()

            DdlVincOtros.Focus();
        }

        protected void RdbNoVinculado_CheckedChanged(object sender, EventArgs e)
        {
            DdlVincOtros.Visible = true;
            miExp.CargarVincOtros(RdbSiVinculado, RdbNoVinculado, DdlVincOtros);
            DdlVincOtros.Focus();
        }

        protected void ChkPapel_CheckedChanged(object sender, EventArgs e)
        {
            TxtFrmtoSoporte.Text += ChkPapel.Text + " ";
            TxtFrmtoSoporte.Visible = true;
            ChkPapel.Enabled = false;
            ChkFoto.Focus();

        }

        protected void ChkFoto_CheckedChanged(object sender, EventArgs e)
        {
            TxtFrmtoSoporte.Text += ChkFoto.Text + " ";
            TxtFrmtoSoporte.Visible = true;
            ChkFoto.Enabled = false;
            ChkUsb.Focus();
        }

        protected void ChkUsb_CheckedChanged(object sender, EventArgs e)
        {
            TxtFrmtoSoporte.Text += ChkUsb.Text + " ";
            TxtFrmtoSoporte.Visible = true;
            ChkUsb.Enabled = false;
            ChkDisco.Focus();
        }

        protected void ChkDisco_CheckedChanged(object sender, EventArgs e)
        {
            TxtFrmtoSoporte.Text += ChkDisco.Text + " ";
            TxtFrmtoSoporte.Visible = true;
            ChkDisco.Enabled = false;
            ChkOtros.Focus();
        }

        protected void ChkOtros_CheckedChanged(object sender, EventArgs e)
        {
            TxtFrmtoSoporte.Visible = true;
            TxtFrmtoSoporte.Enabled = true;
            ChkOtros.Enabled = false;
            TxtFrmtoSoporte.Focus();
        }

        protected void DdlPlazoConser_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlPlazoConser.Focus();
        }

        protected void DdlRespCaptura_SelectedIndexChanged(object sender, EventArgs e)
        {
            miExp.buscarIdCorrespondiente(DdlRespCaptura, DdlIdRespCaptura);
            DdlRespCaptura.Focus();
        }

        protected void DdlVincOtros_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlVincOtros.Focus();
        }

        protected void TxtFechaCaptura_TextChanged(object sender, EventArgs e)
        {
            TxtFechaCaptura.Focus();
        }

        protected void DdlNoEd_SelectedIndexChanged(object sender, EventArgs e)
        {
            miExp.buscarIdCorrespondiente(DdlNoEd, DdlIdNoEd);
            miExp.CargarPisos(DdlIdNoEd, DdlNoPiso, DdlIdNoPiso, ddlidfondo,
                TxtNomFondo, TxtDirFondo, TxtObsFondo);
            //LblIdUbicTopog.Text += DdlIdNoEd.Text + "-";
            DdlNoEd.Focus();
            LblIdUbicTopog.Text = miExp.generaUbicacionTopog(ddlidfondo.Text, DdlIdNoEd.Text, DdlIdNoPiso.Text, DdlIdNoPasillo.Text, DdlIdNoEst.Text, DdlIdNoChar.Text, DdlIdNoCaja.Text);
        }

        protected void DdlNoPiso_SelectedIndexChanged(object sender, EventArgs e)
        {
            miExp.buscarIdCorrespondiente(DdlNoPiso, DdlIdNoPiso);
            miExp.CargarPasillos(DdlIdNoPiso, DdlNoPasillo, DdlIdNoPasillo);
            //LblIdUbicTopog.Text += DdlIdNoPiso.Text + "-";
            DdlNoPiso.Focus();
            LblIdUbicTopog.Text = miExp.generaUbicacionTopog(ddlidfondo.Text, DdlIdNoEd.Text, DdlIdNoPiso.Text, DdlIdNoPasillo.Text, DdlIdNoEst.Text, DdlIdNoChar.Text, DdlIdNoCaja.Text);
        }

        protected void DdlNoPasillo_SelectedIndexChanged(object sender, EventArgs e)
        {
            miExp.buscarIdCorrespondiente(DdlNoPasillo, DdlIdNoPasillo);
            miExp.CargarEstantes(DdlIdNoPasillo, DdlNoEst, DdlIdNoEst);
            //LblIdUbicTopog.Text += DdlIdNoPasillo.Text + "-";
            DdlIdNoPasillo.Focus();
            LblIdUbicTopog.Text = miExp.generaUbicacionTopog(ddlidfondo.Text, DdlIdNoEd.Text, DdlIdNoPiso.Text, DdlIdNoPasillo.Text, DdlIdNoEst.Text, DdlIdNoChar.Text, DdlIdNoCaja.Text);
        }

        protected void DdlNoEst_SelectedIndexChanged(object sender, EventArgs e)
        {
            miExp.buscarIdCorrespondiente(DdlNoEst, DdlIdNoEst);
            miExp.CargarCharolas(DdlIdNoEst, DdlNoChar, DdlIdNoChar);
            //LblIdUbicTopog.Text += DdlIdNoEst.Text + "-";
            DdlIdNoEst.Focus();
            LblIdUbicTopog.Text = miExp.generaUbicacionTopog(ddlidfondo.Text, DdlIdNoEd.Text, DdlIdNoPiso.Text, DdlIdNoPasillo.Text, DdlIdNoEst.Text, DdlIdNoChar.Text, DdlIdNoCaja.Text);
        }

        protected void DdlNoChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            miExp.buscarIdCorrespondiente(DdlNoChar, DdlIdNoChar);
            miExp.CargarUnidCajas(DdlIdNoChar, DdlNoCaja, DdlIdNoCaja);
            //LblIdUbicTopog.Text += DdlIdNoChar.Text + "-";
            DdlNoChar.Focus();
            LblIdUbicTopog.Text = miExp.generaUbicacionTopog(ddlidfondo.Text, DdlIdNoEd.Text, DdlIdNoPiso.Text, DdlIdNoPasillo.Text, DdlIdNoEst.Text, DdlIdNoChar.Text, DdlIdNoCaja.Text);
        }

        protected void DdlNoCaja_SelectedIndexChanged(object sender, EventArgs e)
        {
            miExp.buscarIdCorrespondiente(DdlNoCaja, DdlIdNoCaja);
            //LblIdUbicTopog.Text += DdlIdNoCaja.Text;
            DdlNoChar.Focus();
            LblIdUbicTopog.Text = miExp.generaUbicacionTopog(ddlidfondo.Text, DdlIdNoEd.Text, DdlIdNoPiso.Text, DdlIdNoPasillo.Text, DdlIdNoEst.Text, DdlIdNoChar.Text, DdlIdNoCaja.Text);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //hasta aca vamos =)
            String clasificacion = lblclasexp.Text;

            miExp = miExp.Buscar(clasificacion);

            if (miExp != null)
            {
                miExp.cargarExpEncontrado(
                    miExp,
                    ddluadmva,
                    ddlIduadmva,
                    ddlsubuadmva,
                    ddlidsubuadmva,
                    DdlAutorizadorExp,
                    DdlIdAutorizadorExp,
                    ddlcargoresp,
                    ddlidcargoresp,
                    DdlRespCaptura,
                    DdlIdRespCaptura,
                    TxtNomRespExp,
                    TxtCargoRespExp,
                    TxtTelRespExp,
                    TxtEmailRespExp,
                    TxtUnidAdmvaACargo,
                    TxtResumen,
                    TxtAsuntoExp,
                    DdlFuncion,
                    DdlAcceso,
                    DdlValPrim,
                    TxtFecExtIni,
                    TxtFecExtFin,
                    TxtNoLegajo,
                    TxtNoFojas,
                    RdbSiVinculado,
                    RdbNoVinculado,
                    DdlVincOtros,
                    ChkPapel,
                    ChkFoto,
                    ChkUsb,
                    ChkDisco,
                    TxtFrmtoSoporte,
                    DdlPlazoConser,
                    DdlTipExp,
                    DdlDestFin,
                    DdlValSec,
                    LblIdUbicTopog,
                    DdlNoEd,
                    DdlIdNoEd,
                    TxtNomFondo,
                    DdlNoPiso,
                    DdlIdNoPiso,
                    DdlNoPasillo,
                    DdlIdNoPasillo,
                    DdlNoEst,
                    DdlIdNoEst,
                    DdlNoChar,
                    DdlIdNoChar,
                    DdlNoCaja,
                    DdlIdNoCaja,
                    TxtDirFondo,
                    TxtObsFondo,
                    ddlidfondo,
                    TxtFechaCaptura
                );
                btnAgregar.Visible = false;
                btnActualizar.Visible = true;
                btnEliminar.Visible = true;
            }
            else
            {

                ClientScript.RegisterStartupScript(GetType(), "mostrar", "noEncontrado();", true);
                //expediente no encontrado
            }

        }

        protected void btnAgregar1_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(GetType(), "mostrar", "mostrarFormularios('datos')", true);
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            miExp.Clasificación = lblclasexp.Text;
            miExp.idFondo = ddlidfondo.Text;
            miExp.idseccion = ddlidseccion.Text;
            miExp.idserie = ddlidserie.Text;
            miExp.no_exp = int.Parse(DdlNoExp.Text);
            miExp.año = int.Parse(ddlaño.Text);
            miExp.id_unid_admva_resp = ddlIduadmva.Text;
            miExp.id_area_prod = ddlidsubuadmva.Text;
            miExp.id_resp_exp = ddlidcargoresp.Text;
            miExp.resumen_exp = TxtResumen.Text;
            miExp.asunto_exp = TxtAsuntoExp.Text;
            miExp.funcion_exp = DdlFuncion.Text;
            miExp.acceso_exp = DdlAcceso.Text;
            miExp.val_prim_exp = DdlValPrim.Text;
            miExp.fec_ext_ini_exp = DateTime.Parse(TxtFecExtIni.Text);
            miExp.fec_ext_fin_exp = DateTime.Parse(TxtFecExtFin.Text);
            miExp.no_legajo_exp = int.Parse(TxtNoLegajo.Text);
            miExp.no_fojas_exp = int.Parse(TxtNoFojas.Text);
            miExp.vinc_otro_exp = "Cambiar por DDL";
            miExp.id_exp_vincd = DdlVincOtros.Text;
            miExp.formato_Soporte = TxtFrmtoSoporte.Text;//validar que se seleccione al menos 1 o no este vacio
            miExp.plazo_conservacion_exp = int.Parse(DdlPlazoConser.Text);
            miExp.tipo_exp = DdlTipExp.Text;
            miExp.destino_final_exp = DdlDestFin.Text;
            miExp.valores_secundarios_exp = DdlValSec.Text;
            miExp.id_ubic_topog = LblIdUbicTopog.Text;
            miExp.IdEdificio = DdlIdNoEd.Text;
            miExp.IdPisoEd = DdlIdNoPiso.Text;
            miExp.IdPasillo = DdlIdNoPasillo.Text;
            miExp.IdEstante = DdlIdNoEst.Text;
            miExp.IdCharola = DdlIdNoChar.Text;
            miExp.IdUnidInsCaja = DdlIdNoCaja.Text;
            miExp.fecha_alta_exp = DateTime.Parse(TxtFechaCaptura.Text);
            miExp.id_capturista_exp = DdlIdRespCaptura.Text;
            miExp.id_autorizador_exp = DdlIdAutorizadorExp.Text;

            int r = miExp.Actualizar();
            

            if (r == 1)
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "GuardarDatos();", true);
            else if (r == 0)
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "ErActualizar();", true);
            else
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "ErActualizar();", true);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            miExp = miExp.Buscar(lblclasexp.Text);
            if (miExp != null)
            {
                int resp = miExp.Eliminar(lblclasexp.Text);
                if (resp == 1)
                    ClientScript.RegisterStartupScript(GetType(), "mostrar", "datoEliminado();", true);
                else
                    ClientScript.RegisterStartupScript(GetType(), "mostrar", "ErEliminar();", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "noEncontrado();", true);
            }            
        }
    }
}