<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MPlastic.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/estilo_login.css" rel="stylesheet" type="text/css" />
    <title></title> 
    <script src="JS/validarboton.js"></script>
    <script src="JS/Alerts.js"></script>
    
</head>
<body>
    <form id="form1" runat="server" method="post">
        <div class="login">
            &nbsp;<h1>Archivo Digital</h1>
            <h2>Login</h2>
            <div id="id">
                <span class="fontawesome-user"></span>
                <asp:TextBox ID="TextBox1" runat="server" placeholder="ID" OnTextChanged="TextBox1_TextChanged" onkeypress ="Habilitar();"> </asp:TextBox>
               
            </div>

            <div id="contra">
                <span class="fontawesome-lock"></span>
                <asp:TextBox ID="TextBox2" runat="server" placeholder="Contraseña" type="password" OnTextChanged="TextBox2_TextChanged"  onkeypress ="Habilitar();"></asp:TextBox>
                
            </div>
            <asp:Button ID="Button1" runat="server" Text="Ingresar" OnClick="Button1_Click"/>
        </div>
    </form>
</body>
</html>
