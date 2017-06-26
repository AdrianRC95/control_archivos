<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Menu.Master" AutoEventWireup="true" CodeBehind="documento.aspx.cs" Inherits="ctrlArchivos.vista.documento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/Forms.css" rel="stylesheet" type="text/css" />
    <script src="../JS/Alerts.js"></script>
    <script src="../JS/funciones.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="contenido">
    

        <h1>Documento</h1>
        <input type="checkbox" onclick="mostrar_ocultar('BuscarUsuario')"/><label>Mostrar Opciones</label>
        <div class="MyToolBar ocultar" id="BuscarUsuario">
            <div class="mysection">
                <h3>Ingresar Folio del documento:</h3>
                <asp:TextBox ID="buscarFolioDocumento" class="form-control" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnBuscarDocumento" class="btn btn-primary btn-lg btn-block" runat="server" OnClick="btnBuscarDocumento_Click" Text="Buscar" />
            </div>
        </div>
        <div class="mysection">
            <h2>Generales del documento</h2> 

            <div class="mycontrol">
                Clasificación del expediente:
                <br/>
                <asp:DropDownList ID="ddlIdClasifExp" class="form-control" runat="server">
                </asp:DropDownList>
            </div>

    
            <div class="mycontrol">
                Folio:
                <br/>
                <asp:TextBox ID="txtFolio" class="form-control" runat="server"></asp:TextBox>
            </div>

    
            <div class="mycontrol">
                Tipo:
                <br/>
                <asp:DropDownList ID="ddlTipo" class="form-control" runat="server">
                </asp:DropDownList>
            </div>

            <div class="mycontrol">
                Estatus del documento:
                <br/>
                <asp:DropDownList ID="ddlStatus" class="form-control" runat="server">
                </asp:DropDownList>
            </div>

            <div class="mycontrol">
                Prioridad del documento:
                <br/>
                <asp:DropDownList ID="ddlPrioridad" class="form-control" runat="server">
                </asp:DropDownList>
            </div>

            <div class="mycontrol">
                Número de documento
                <br/>
                <asp:TextBox ID="txtNumero" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
   
            </div>

            <div class="mycontrol">
                Fecha del documento
                <br/>
                <asp:TextBox ID="txtFecha" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
            </div>

            <div class="mycontrol">
                Quien remite
                <br/>
                <asp:DropDownList ID="ddlRemitente" class="form-control" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlRemitente_SelectedIndexChanged">
                </asp:DropDownList>  
                <asp:DropDownList ID="ddlIdRemitente" class="form-control" runat="server">
                </asp:DropDownList>        
            </div>
    
            <div class="mycontrol">
                A quien va dirigido
                <br/>
                <asp:DropDownList ID="ddlDestinatario" class="form-control" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlDestinatario_SelectedIndexChanged">
                </asp:DropDownList>   
                <asp:DropDownList ID="ddlIdDestinatario" class="form-control" runat="server">
                </asp:DropDownList>        
            </div>

            <div class="mycontrol">
                Fecha de recepcion del documento
                <br/>
                <asp:TextBox ID="txtFechaRecepcion" runat="server" class="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="mycontrol">
                Hora de recepcion del documento
                <br/>
                <asp:TextBox ID="txtHoraRecepcion" class="form-control" runat="server" TextMode="Time"></asp:TextBox>
            </div>

            <div class="mycontrol">
                Asunto del documento
                <br/>
                <asp:TextBox ID="txtAsunto" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>

            <div class="mycontrol">
                Observaciones del documento
                <br/>
                <asp:TextBox ID="txtObservaciones" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>

            <div class="mycontrol">
                Descripción de anexos
                <br/>
                <asp:TextBox ID="txtDescAnexos" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>

            <div class="mycontrol">
                Número de fojas del documento
                <br/>
                <asp:TextBox ID="txtNumFojas" runat="server" class="form-control" TextMode="Number"></asp:TextBox>
            </div>

        </div>
        
        <br />

        <div class="mysection">
            <h2>Delegación del documento</h2>
            <div class="mycontrol">
                A quien se turno
                <br/>
                <asp:DropDownList ID="ddlDelegado" class="form-control" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlDelegado_SelectedIndexChanged">
                </asp:DropDownList>  
                <asp:DropDownList ID="ddlIdDelegado" class="form-control" runat="server">
                </asp:DropDownList>        
            </div>

            <div class="mycontrol">
                Estatus del turno
                <br/>
                <asp:DropDownList ID="ddlEstatusDelegado" class="form-control" runat="server">
                </asp:DropDownList>        
            </div>

            <div class="mycontrol">
                Fecha en que se turno el documento
                <br/>
                <asp:TextBox ID="txtFechaDelegacion" runat="server" class="form-control" TextMode="Date"></asp:TextBox>
            </div>
            
            
            
        </div>

        <div class="MyToolBar">
            <asp:Button ID="btnAgregarDoc" class="btn btn-primary btn-lg btn-block" runat="server" Text="Agregar" OnClick="btnAgregarDoc_Click" />
            <asp:Button ID="btnActualizarDoc" class="btn btn-primary btn-lg btn-block" runat="server" Text="Actualizar" OnClick="btnActualizarDoc_Click" />
            <asp:Button ID="btnEliminarDoc" class="btn btn-primary btn-lg btn-block" runat="server" Text="Eliminar" OnClick="btnEliminarDoc_Click" />
        </div>

    </div>
</asp:Content>
