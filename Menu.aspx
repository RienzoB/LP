<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="TP_03._2.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="CrearCuentas.aspx" BackColor="Lime">Cuentas</asp:HyperLink>&nbsp;
              <asp:HyperLink ID="HyperLink5"  runat="server" NavigateUrl="CrearRegCon.aspx" BackColor="Lime">Registros Contables</asp:HyperLink>&nbsp;
        </div>
    </form>
</body>
</html>
