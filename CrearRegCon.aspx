 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearRegCon.aspx.cs" Inherits="TP_03._2.CrearRegCon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Menu.aspx">Volver a Menu</asp:HyperLink>
        </div>
         <div>
             <asp:DropDownList runat="server" ID="DropDownList1" DataTextField="descripcion" DataValueField="id" DataSourceID="SqlDataSource1"></asp:DropDownList> 
             <asp:TextBox runat="server" ID="TextBox1" BorderStyle="Solid" ToolTip="Ingrese el Monto"></asp:TextBox>  
             <asp:TextBox runat="server" ID="TextBox2" placeholder="Tipo" ToolTip="Ingrese 1(Haber) o 2(Debe)" TextMode="Number" AutoPostBack="True"></asp:TextBox>&nbsp;   <asp:Button runat="server" Text="Alta" ID="Alta" OnClick="Alta_Click"></asp:Button><asp:Button ID="Modificar" runat="server" Text="Modificar" OnClick="Modificar_Click" /><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></div>
        <div>&nbsp;<asp:Table runat="server" ID="Table1" HorizontalAlign="Center"></asp:Table>
            <asp:DropDownList runat="server" ID="DropDownList2" DataTextField="id" DataValueField="id" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><asp:Button runat="server" Text="Eliminar" ID="Borrar" OnClick="Borrar_Click"></asp:Button><asp:Label runat="server" Text="Label" ID="Label2"></asp:Label>
        </div>
        <div>&nbsp;</div>
        <div>&nbsp;<asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:cadena %>" DeleteCommand="DELETE FROM [Registros_Contables] WHERE [id] = @id" InsertCommand="INSERT INTO [Registros_Contables] ([idCuenta], [monto], [tipo]) VALUES (@idCuenta, @monto, @tipo)" SelectCommand="SELECT * FROM [Registros_Contables]" UpdateCommand="UPDATE [Registros_Contables] SET [idCuenta] = @idCuenta, [monto] = @monto, [tipo] = @tipo WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32"></asp:Parameter>
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="idCuenta" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="monto" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="tipo" Type="Int32"></asp:Parameter>
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="idCuenta" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="monto" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="tipo" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="id" Type="Int32"></asp:Parameter>
            </UpdateParameters>
        </asp:SqlDataSource>
            <asp:SqlDataSource runat="server" ID="SqlDataSource4" ConnectionString="<%$ ConnectionStrings:cadena %>" SelectCommand="SELECT * FROM [Registros_Contables] WHERE ([id] = @id)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList2" PropertyName="SelectedValue" Name="id" Type="Int32"></asp:ControlParameter>
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:cadena %>" SelectCommand="SELECT * FROM [Cuentas]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:cadena %>" SelectCommand="SELECT Registros_Contables.id, Registros_Contables.idCuenta, Registros_Contables.monto, Registros_Contables.tipo, Cuentas.descripcion FROM Registros_Contables INNER JOIN Cuentas ON Registros_Contables.idCuenta = Cuentas.id" DeleteCommand="DELETE FROM [Registros_Contables] WHERE [id] = @id" InsertCommand="INSERT INTO [Registros_Contables] ([idCuenta], [monto], [tipo]) VALUES (@idCuenta, @monto, @tipo)" UpdateCommand="UPDATE [Registros_Contables] SET [idCuenta] = @idCuenta, [monto] = @monto, [tipo] = @tipo WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32"></asp:Parameter>
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="idCuenta" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="monto" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="tipo" Type="Int32"></asp:Parameter>
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="idCuenta" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="monto" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="tipo" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="id" Type="Int32"></asp:Parameter>
                </UpdateParameters>
            </asp:SqlDataSource>
            </div>
    </form>
</body>
</html>
