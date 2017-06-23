<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Menu.Master" AutoEventWireup="true" CodeBehind="m_documento.aspx.cs" Inherits="ctrlArchivos.vista.m_documento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenido">
        <h1>Documento </h1>
        <div class="mysection">
            <h2>Generales del documento</h2>
            <div class="table-responsive">
                <asp:Table id="datos" class="table table-hover" runat="server">
                </asp:Table>
            </div>
        </div>    
    </div>
</asp:Content>
