using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP7_Grupo10.Clases;

namespace TP7_Grupo10
{
    public partial class SeleccionarSucursales : System.Web.UI.Page
    {
        private SessionGestion sessionSelecciones;
        private Sucursal sucursal;

        private const string ConsultaBase = "SELECT [Id_Sucursal], [NombreSucursal], [DescripcionSucursal], [Id_ProvinciaSucursal], [URL_Imagen_Sucursal] FROM [Sucursal]";

        protected void Page_Load(object sender, EventArgs e)
        {
            sessionSelecciones = new SessionGestion(Session);

            if (!IsPostBack)
            {
                SqlDataSourceSucursales.SelectCommand = ConsultaBase;
            }
            else if (Session["FiltroProvincia"] != null)
            {
                SqlDataSourceSucursales.SelectCommand = ConsultaBase + " " + Session["FiltroProvincia"].ToString();
                SqlDataSourceSucursales.DataBind();
            }
        }

        protected void Provincia_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "FiltroProvincias")
            {
                // Se guarda la consulta WHERE en Session
                Session["FiltroProvincia"] = "WHERE [Id_ProvinciaSucursal] = @Id_Provincia";

                // Antes de agregar el nuevo parámetro, elimina el anterior si existe
                if ( SqlDataSourceSucursales.SelectParameters["Id_Provincia"] != null)
                {
                    SqlDataSourceSucursales.SelectParameters.Remove(SqlDataSourceSucursales.SelectParameters["Id_Provincia"]);
                }
                
                SqlDataSourceSucursales.SelectParameters.Add("Id_Provincia", e.CommandArgument.ToString());
                SqlDataSourceSucursales.SelectCommand = ConsultaBase + " " + Session["FiltroProvincia"].ToString();
                SqlDataSourceSucursales.DataBind();

                // Reinicia la paginación del ListView
                DataPager dataPager = lvSucursales.FindControl("DataPager1") as DataPager;
                
                if (dataPager != null)
                {
                    dataPager.SetPageProperties(0, dataPager.PageSize, true);
                }
            }
        }

        protected void lvSucursales_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int idSucursal = Convert.ToInt32(e.CommandArgument);

                // Obtener valores del ListView
                Label lblNombre = e.Item.FindControl("NombreSucursalLabel") as Label;
                Label lblDescripcion = e.Item.FindControl("DescripcionSucursalLabel") as Label;

                // Crear DataTable si la sesión no tiene datos
                DataTable dtSucursalesSeleccionadas = Session["SucursalesSeleccionadas"] as DataTable;
                if (dtSucursalesSeleccionadas == null)
                {
                    dtSucursalesSeleccionadas = new DataTable();
                    dtSucursalesSeleccionadas.Columns.Add("Id_Sucursal", typeof(int));
                    dtSucursalesSeleccionadas.Columns.Add("NombreSucursal", typeof(string));
                    dtSucursalesSeleccionadas.Columns.Add("DescripcionSucursal", typeof(string));
                }

                // Agregar nueva fila con los datos seleccionados
                DataRow nuevaFila = dtSucursalesSeleccionadas.NewRow();
                nuevaFila["Id_Sucursal"] = idSucursal;
                nuevaFila["NombreSucursal"] = lblNombre;
                nuevaFila["DescripcionSucursal"] = lblDescripcion;
                dtSucursalesSeleccionadas.Rows.Add(nuevaFila);

                // Guardar en sesión
                Session["SucursalesSeleccionadas"] = dtSucursalesSeleccionadas;

                ///Mensaje de prueba
                lblMensaje.Text = e.CommandArgument.ToString();
            }
        }

    }
}