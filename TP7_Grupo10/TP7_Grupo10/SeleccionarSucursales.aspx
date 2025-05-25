<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarSucursales.aspx.cs" Inherits="TP7_Grupo10.SeleccionarSucursales" %>

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
        padding: 0;
    }

    .auto-style1 {
        width: 100%;
        margin-bottom: 20px;
    }

    table {
        border-collapse: collapse;
    }

    td {
        padding: 10px;
    }

    asp\:HyperLink {
        text-decoration: none;
    }

    a, .auto-style14 a, .auto-style15 a {
        color: #0077cc;
        font-weight: bold;
        text-decoration: none;
        transition: color 0.3s ease;
    }

    a:hover {
        color: #005fa3;
    }

    .auto-style28 {
        font-weight: bold;
    }

    .auto-style27 input[type="text"] {
        padding: 5px 10px;
        border: 1px solid #ccc;
        border-radius: 4px;
    }

    input[type="submit"], .btn, asp\:Button {
        background-color: #0077cc;
        color: white;
        border: none;
        padding: 8px 16px;
        border-radius: 5px;
        cursor: pointer;
        transition: background-color 0.3s ease;
    }

    input[type="submit"]:hover, .btn:hover {
        background-color: #005fa3;
    }

    .auto-style30 {
        background-color: #ffffff;
        border-radius: 8px;
        padding: 15px;
        box-shadow: 0 2px 8px rgba(0,0,0,0.1);
    }

    .auto-style35 {
        border: 1px solid #ddd;
        border-radius: 10px;
        background-color: #e9f5ff;
        padding: 15px;
        margin: 10px;
        text-align: center;
    }

    .auto-style35 img {
        max-width: 100%;
        border-radius: 5px;
        margin-top: 10px;
    }

    .auto-style35 button {
        margin-top: 10px;
    }

    .auto-style35:hover {
        background-color: #d6ecfb;
        transition: background-color 0.3s ease;
    }

    .auto-style29 label {
        font-size: 28px;
        color: #333;
    }

    .auto-style26, .auto-style22 {
        height: 20px;
    }

    .auto-style5 {
        text-align: center;
    }

    .auto-style2, .auto-style7 {
        width: 18px;
    }

    .auto-style20 {
        margin: 0 auto;
        max-width: 800px;
        text-align: center;
    }

    .auto-style32 {
        background-color: white;
        border-radius: 8px;
        padding: 20px;
        box-shadow: 0 0 10px rgba(0,0,0,0.05);
    }

    .auto-style35 .aspNet-Label {
        display: block;
        margin-top: 5px;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style13"></td>
                    <td class="auto-style14">
                        <asp:HyperLink ID="hpListadoDeSucursales" runat="server" NavigateUrl="~/SeleccionarSucursales.aspx">Listado de sucursales</asp:HyperLink>
                    </td>
                    <td class="auto-style15">&nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hpMostrarSucursalesSeleccionadas" runat="server" NavigateUrl="~/ListadoSucursalesSeleccionadas.aspx">Mostrar sucursales seleccionadas</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style28">&nbsp;</td>
                    <td class="auto-style27">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style21"></td>
                    <td class="auto-style29">
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="25pt" Text="Listado de sucursales"></asp:Label>
                    </td>
                    <td class="auto-style26"></td>
                    <td class="auto-style22"></td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style28">&nbsp;</td>
                    <td class="auto-style27">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style28">Búsqueda por nombre de sucursal:</td>
                    <td class="auto-style27">
                        <asp:TextBox ID="txtNombreSucursal" runat="server" Width="293px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    </td>
                </tr>
            </table>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:SqlDataSource ID="SqDS_Provincias" runat="server" ConnectionString="<%$ ConnectionStrings:BDSucursales_Provincias %>" SelectCommand="SELECT [Id_Provincia], [DescripcionProvincia] FROM [Provincia]"></asp:SqlDataSource>
                        </td>
                    <td class="auto-style8"></td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style18">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style30">
                        <asp:DataList ID="dl_ProvinciasSucursales" runat="server" DataSourceID="SqDS_Provincias" ClientIDMode="Static">
                            <FooterTemplate>
                                <asp:Button ID="btnEliminarFiltro" runat="server" OnClick="btnEliminarFiltro_Click" Text="Eliminar filtro" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Button ID="Provincia" runat="server" CommandArgument='<%# Eval("Id_Provincia") %>' CommandName="FiltroProvincias" OnCommand="Provincia_Command" Text='<%# Eval("DescripcionProvincia") %>' Height="35px" Width="202px" />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                    <td class="auto-style31"></td>
                    <td class="auto-style32">
                        <asp:Label ID="lblSeleccionados" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:UpdatePanel ID="updMensaje" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Timer ID="tMensaje" runat="server" Enabled="False" Interval="40000" OnTick="tMensaje_Tick">
                                </asp:Timer>
                                <asp:ScriptManager ID="smMensaje" runat="server">
                                </asp:ScriptManager>
                                <asp:Label ID="lblMensaje" runat="server" Visible="False">(No se está filtrando por ninguna provincia actualmente)</asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <asp:ListView ID="lvSucursales" runat="server" DataSourceID="SqlDataSourceSucursales" GroupItemCount="3" DataKeyNames="Id_Sucursal" style="margin-bottom: 0px">

                            <%--<AlternatingItemTemplate>
                                <td runat="server" style="background-color: #FFFFFF;color: #284775;">Id_Sucursal:
                                    <asp:Label ID="Id_SucursalLabel" runat="server" Text='<%# Eval("Id_Sucursal") %>' />
                                    <br />
                                    NombreSucursal:
                                    <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' />
                                    <br />
                                    DescripcionSucursal:
                                    <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' />
                                    <br />
                                    Id_ProvinciaSucursal:
                                    <asp:Label ID="Id_ProvinciaSucursalLabel" runat="server" Text='<%# Eval("Id_ProvinciaSucursal") %>' />
                                    <br />
                                    URL_Imagen_Sucursal:
                                    <asp:Label ID="URL_Imagen_SucursalLabel" runat="server" Text='<%# Eval("URL_Imagen_Sucursal") %>' />
                                    <br />
                                </td>
                            </AlternatingItemTemplate>--%>
                            <EditItemTemplate>
                                <td runat="server" style="background-color: #999999;">NombreSucursal:
                                    <asp:TextBox ID="NombreSucursalTextBox" runat="server" Text='<%# Bind("NombreSucursal") %>' />
                                    <br />
                                    DescripcionSucursal:
                                    <asp:TextBox ID="DescripcionSucursalTextBox" runat="server" Text='<%# Bind("DescripcionSucursal") %>' />
                                    <br />
                                    URL_Imagen_Sucursal:
                                    <asp:TextBox ID="URL_Imagen_SucursalTextBox" runat="server" Text='<%# Bind("URL_Imagen_Sucursal") %>' />
                                    <br />
                                    Id_Sucursal:
                                    <asp:Label ID="Id_SucursalLabel1" runat="server" Text='<%# Eval("Id_Sucursal") %>' />
                                    <br />
                                    Id_ProvinciaSucursal:
                                    <asp:TextBox ID="Id_ProvinciaSucursalTextBox" runat="server" Text='<%# Bind("Id_ProvinciaSucursal") %>' />
                                    <br />
                                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                                    <br />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                                    <br />
                                </td>
                            </EditItemTemplate>
                            <EmptyDataTemplate>
                                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                                    <tr>
                                        <td>No se han devuelto datos.</td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <EmptyItemTemplate>
                                <td runat="server" />
                            </EmptyItemTemplate>
                            <GroupTemplate>
                                <tr id="itemPlaceholderContainer" runat="server">
                                    <td id="itemPlaceholder" runat="server"></td>
                                </tr>
                            </GroupTemplate>
                            <InsertItemTemplate>
                                <td runat="server" style="">NombreSucursal:
                                    <asp:TextBox ID="NombreSucursalTextBox" runat="server" Text='<%# Bind("NombreSucursal") %>' />
                                    <br />
                                    DescripcionSucursal:
                                    <asp:TextBox ID="DescripcionSucursalTextBox" runat="server" Text='<%# Bind("DescripcionSucursal") %>' />
                                    <br />
                                    URL_Imagen_Sucursal:
                                    <asp:TextBox ID="URL_Imagen_SucursalTextBox" runat="server" Text='<%# Bind("URL_Imagen_Sucursal") %>' />
                                    <br />
                                    Id_ProvinciaSucursal:
                                    <asp:TextBox ID="Id_ProvinciaSucursalTextBox" runat="server" Text='<%# Bind("Id_ProvinciaSucursal") %>' />
                                    <br />
                                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                                    <br />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                                    <br />
                                </td>
                            </InsertItemTemplate>
                            <ItemTemplate >
                               
                                <td runat="server" style="background-color: #E0FFFF;color: #333333; padding:20px;" class="auto-style35">
                                    <asp:Label ID="Id_SucursalLabel" runat="server" Text='<%# Eval("Id_Sucursal", "{0:N}") %>' Visible="False" />
                                    <asp:Label ID="Id_ProvinciaSucursalLabel" runat="server" Text='<%# Eval("Id_ProvinciaSucursal", "{0:N}") %>' Visible="False"></asp:Label>
                                    <br />
                                    &nbsp;<asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal", "{0}") %>' Font-Bold="True" />
                                    <br />
                                    <br />
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("URL_Imagen_Sucursal") %>' />
                                    <br />
                                    <br />
                                    &nbsp;<asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal", "{0}") %>' />
                                    <br />
                                    <br />
                                    <asp:Button ID="bSeleccionar" runat="server" CommandArgument='<%# Eval("Id_Sucursal").ToString() + "|" + Eval("NombreSucursal").ToString() + "|" + Eval("DescripcionSucursal").ToString() + "|" + Eval("DireccionSucursal").ToString() %>' CommandName="Seleccion" OnCommand="bSeleccionar_Command" Text="Seleccionar" />
                                    <br /> 
                                </td>
                                   
                            </ItemTemplate>
                            <LayoutTemplate>
                               <table runat="server">
                                    <tr runat="server">
                                        <td runat="server">
                                            <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif; text-align: center;">
                                                <tr id="groupPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr runat="server">
                                        <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF; padding:10px;" >
                                            <asp:DataPager ID="DataPager1" runat="server" PageSize="6">
                                                <Fields>
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                    <asp:NumericPagerField />
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                </Fields>
                                            </asp:DataPager>
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                            <SelectedItemTemplate>
                                <td runat="server" style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                                    <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' />
                                    <br />
                                    DescripcionSucursal:
                                    <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' />
                                    <br />
                                    URL_Imagen_Sucursal:
                                    <asp:Label ID="URL_Imagen_SucursalLabel" runat="server" Text='<%# Eval("URL_Imagen_Sucursal") %>' />
                                    <br />
                                    Id_Sucursal:
                                    <asp:Label ID="Id_SucursalLabel" runat="server" Text='<%# Eval("Id_Sucursal") %>' />
                                    <br />
                                    Id_ProvinciaSucursal:
                                    <asp:Label ID="Id_ProvinciaSucursalLabel" runat="server" Text='<%# Eval("Id_ProvinciaSucursal") %>' />
                                    <br />
                                </td>
                            </SelectedItemTemplate>
                        </asp:ListView>
                        <br />
                        </td>
                    <td class="auto-style33"></td>
                    <td class="auto-style34"></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style5">
                        <asp:SqlDataSource ID="SqlDataSourceSucursales" runat="server" ConnectionString="<%$ ConnectionStrings:BDSucursalesConnectionString %>" SelectCommand="SELECT [NombreSucursal], [DescripcionSucursal], [URL_Imagen_Sucursal], [Id_Sucursal], [Id_ProvinciaSucursal], [DireccionSucursal] FROM [Sucursal]"></asp:SqlDataSource>
                        <br />
                    </td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p class="auto-style20">
        &nbsp;</p>
</body>
</html>
   width: 187px;
         