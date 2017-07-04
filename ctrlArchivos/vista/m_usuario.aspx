<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Menu.Master" AutoEventWireup="true" CodeBehind="m_usuario.aspx.cs" Inherits="ctrlArchivos.vista.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenido">
        <h1>Usuario </h1>
        <div class="mysection">
            <h2>Generales del usuario</h2>
            <p>
                <label>Exportar: </label>
                <asp:ImageButton id="exportExcel" OnClick="exportExcel_Click" runat="server" ImageUrl="~/Images/excel.png" />
                <asp:ImageButton id="exportPdf" OnClick="exportPdf_Click" runat="server" ImageUrl="~/Images/pdf.png" />
                <img src="../Images/printer.png" id="print" onclick="window.print()" />
            </p>
            <div class="table-responsive">
                <asp:Table id="datos" class="table table-hover" runat="server">
                </asp:Table>
            </div>
        </div>    
    </div>
</asp:Content>
