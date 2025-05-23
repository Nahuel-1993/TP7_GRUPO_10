<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursalesSeleccionadas.aspx.cs" Inherits="TP7_Grupo10.ListadoSucursalesSeleccionadas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<style type="text/css">
    body {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        background-color: #f4f7f9;
        margin: 0;
        padding: 20px;
    }

    .auto-style1 {
        width: 100%;
        margin-bottom: 20px;
    }

    td {
        padding: 10px;
        vertical-align: top;
    }

    a, .auto-style4 a, .auto-style5 a {
        color: #0077cc;
        font-weight: bold;
        text-decoration: none;
        transition: color 0.3s ease;
    }

    a:hover {
        color: #005fa3;
    }

    .auto-style2 {
        width: 226px;
    }

    .auto-style4 {
        width: 176px;
    }

    .auto-style5 {
        width: 295px;
    }

    #lblTitulo {
        color: #333;
    }

    #lblMensaje {
        color: #d9534f;
        margin-top: 10px;
        display: block;
    }

    asp\:GridView, .gridview-container {
        background-color: white;
        border-radius: 8px;
        padding: 15px;
        box-shadow: 0 2px 8px rgba(0,0,0,0.1);
    }

    .gridview-container table {
        width: 100%;
        border-collapse: collapse;
    }

    .gridview-container th,
    .gridview-container td {
        padding: 10px;
        text-align: left;
        border-bottom: 1px solid #ccc;
    }

    asp\:Button, input[type="submit"] {
        background-color: #0077cc;
        color: white;
        border: none;
        padding: 8px 16px;
        border-radius: 5px;
        cursor: pointer;
        transition: background-color 0.3s ease;
    }

    asp\:Button:hover, input[type="submit"]:hover {
        background-color: #005fa3;
    }
    .auto-style6 {
        width: 114%;
    }
    .auto-style7 {
        width: 256px;
    }
    .auto-style8 {
        width: 144px;
    }
    .auto-style10 {
        margin-left: 71px;
    }
    .auto-style11 {
        width: 287px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server">
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style4">
                            <asp:HyperLink ID="hlListadoSucursales" runat="server" NavigateUrl="~/SeleccionarSucursales.aspx">Listado de sucursales</asp:HyperLink>
                        </td>
                        <td class="auto-style5">&nbsp;</td>
                        <td>
                            <asp:HyperLink ID="hlSucursalesSeleccionadas" runat="server" NavigateUrl="~/ListadoSucursalesSeleccionadas.aspx">Mostrar sucursales seleccionadas</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="25pt" Text="Mostrar sucursales seleccionadas"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <table class="auto-style6">
                        <tr>
                            <td class="auto-style7">
                    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Size="X-Large">No hay sucursales seleccionadas</asp:Label>
                            </td>
                            <td class="auto-style8">
                                <asp:Button ID="btnMostrarDireccion" runat="server" OnClick="btnMostrarDireccion_Click" Text="Mostrar Dirección" CssClass="auto-style10" Visible="False" />
                            </td>
                            <td class="auto-style11">
                                <asp:Button ID="btnEliminarTodo" runat="server" OnClick="btnEliminarTodo_Click" Text="Eliminar todo" CssClass="auto-style10" Visible="False" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:GridView ID="gvSucursalesSeleccionadas" runat="server" OnRowCommand="gvSucursalesSeleccionadas_RowCommand" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnEliminar" runat="server" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Eliminar" Text="Eliminar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID SUCURSAL">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_IdSucursal" runat="server" Text='<%# Eval("ID SUCURSAL") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NOMBRE">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_NombreSucursal" runat="server" Text='<%# Eval("NOMBRE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DESCRIPCIÓN">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_DescripcionSucursal" runat="server" Text='<%# Eval("DESCRIPCIÓN") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DIRECCIÓN">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_DireccionSucursal" runat="server" Text='<%# Eval("DIRECCIÓN") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
