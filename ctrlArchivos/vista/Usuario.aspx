<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Menu.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="ctrlArchivos.vista.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/Forms.css" rel="stylesheet" type="text/css" />
    <script src="../JS/Alerts.js"></script>
    <script src="../JS/funciones.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenido">
        <h1>Usuario</h1>
        <input type="checkbox" onclick="mostrar_ocultar('BuscarUsuario')"/><label>Mostrar Opciones</label>
        <div class="MyToolBar ocultar" id="BuscarUsuario">
            <div class="mysection">
                <h3>Ingresar Id de Usuario:</h3>
                <asp:TextBox ID="buscarIdUsuario" class="form-control" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnBuscarUsuario" class="btn btn-primary btn-lg btn-block" runat="server" OnClick="btnBuscarUsuario_Click" Text="Buscar" />
            </div>
        </div>

        <div class="mysection">
            <h2>Información Usuario</h2> 
            <div class="mycontrol">
                Id Usuario:
                <br/>
                <asp:TextBox ID="txtIdUsuario" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mycontrol">
                Área:
                <br/>
                <asp:TextBox ID="txtNombre" class="form-control" runat="server"></asp:TextBox>
            </div>
    
            <div class="mycontrol">
                Nombre:
                <br/>
                <asp:TextBox ID="txtNombreCom" class="form-control" runat="server"></asp:TextBox>
            </div>

    
            <div class="mycontrol">
                Email:
                <br/>
                <asp:TextBox ID="txtEmail" class="form-control" runat="server">
                </asp:TextBox>
            </div>

            <div class="mycontrol">
                Confirmar Email:
                <br/>
                <asp:TextBox ID="txtConfirmaEmail" class="form-control" runat="server">
                </asp:TextBox>
            </div>

            <div class="mycontrol">
                Contrseña:
                <br/>
                <asp:TextBox ID="txtContrasenia" class="form-control" runat="server">
                </asp:TextBox>
            </div>

            <div class="mycontrol">
                Confirmar Contraseña:
                <br/>
                <asp:TextBox ID="txtConfirmaContrasenia" class="form-control" runat="server"></asp:TextBox>
   
            </div>

            <div class="mycontrol">
                Tipo Usuario:
                <br/>
                <asp:DropDownList ID="ddlTipoUsuario" class="form-control" runat="server" TextMode="Date"></asp:DropDownList>
            </div>

            <div class="mycontrol">
                Teléfono:
                <br/>
                <asp:TextBox ID="txtTelefono" class="form-control" runat="server" TextMode="Phone">
                </asp:TextBox>        
            </div>
    
            <div class="mycontrol">
                Combre Cargo:
                <br/>
                <asp:TextBox ID="txtCargo" class="form-control" runat="server">
                </asp:TextBox>        
            </div>

            <div class="mycontrol">
                Unidad Administrativa
                <br/>
                <asp:DropDownList ID="ddlUnidadAdm" AutoPostBack="True" runat="server" class="form-control" OnSelectedIndexChanged="ddlUnidadAdm_SelectedIndexChanged" ></asp:DropDownList>
                <asp:DropDownList ID="ddlIdUnidadAdm" runat="server" class="form-control" ></asp:DropDownList>
            </div>                 
        </div>
        <div class="MyToolBar">
            <asp:Button ID="btnAgregar" class="btn btn-primary btn-lg btn-block" runat="server" Text="Agregar" OnClick="btnAgregarDoc_Click" />
            <asp:Button ID="btnActualizar" class="btn btn-primary btn-lg btn-block" runat="server" Text="Actualizar" OnClick="btnActualizarDoc_Click" />
            <asp:Button ID="btnEliminar" class="btn btn-primary btn-lg btn-block" runat="server" Text="Eliminar" OnClick="btnEliminarDoc_Click" />
        </div>
    </div>
</asp:Content>
