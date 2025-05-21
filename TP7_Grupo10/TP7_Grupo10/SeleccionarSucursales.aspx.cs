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
            else if (ViewState["FiltroProvincia"] != null)
            {
                SqlDataSourceSucursales.SelectCommand = ConsultaBase + " " + ViewState["FiltroProvincia"].ToString();
                SqlDataSourceSucursales.DataBind();
            }
        }

        protected void Provincia_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "FiltroProvincias")
            {
                // Se guarda la consulta WHERE en Session
                ViewState["FiltroProvincia"] = "WHERE [Id_ProvinciaSucursal] = @Id_Provincia";

                // Antes de agregar el nuevo parámetro, elimina el anterior si existe
                if ( SqlDataSourceSucursales.SelectParameters["Id_Provincia"] != null)
                {
                    SqlDataSourceSucursales.SelectParameters.Remove(SqlDataSourceSucursales.SelectParameters["Id_Provincia"]);
                }
                
                SqlDataSourceSucursales.SelectParameters.Add("Id_Provincia", e.CommandArgument.ToString());
                SqlDataSourceSucursales.SelectCommand = ConsultaBase + " " + ViewState["FiltroProvincia"].ToString();
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
            ///agregar el código en respuesta a Seleccionar (cargar objeto sucursal y enviarlo a metodo essionSelecciones.AgregarFila(sucursal))
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreSucursal = txtNombreSucursal.Text.Trim();
            string consultaWhere = " WHERE NombreSucursal LIKE @NombreSucursal";

            // Limpiar parámetros anteriores
            if (SqlDataSourceSucursales.SelectParameters["NombreSucursal"] != null)
            {
                SqlDataSourceSucursales.SelectParameters.Remove(SqlDataSourceSucursales.SelectParameters["NombreSucursal"]);
            }

            SqlDataSourceSucursales.SelectParameters.Add("NombreSucursal", "%" + nombreSucursal + "%");
            SqlDataSourceSucursales.SelectCommand = ConsultaBase + consultaWhere;
            SqlDataSourceSucursales.DataBind();

            // Reinicia la paginación del ListView
            DataPager dataPager = lvSucursales.FindControl("DataPager1") as DataPager;

            if (dataPager != null)
            {
                dataPager.SetPageProperties(0, dataPager.PageSize, true);
            }

            txtNombreSucursal.Text = string.Empty;
        }
    }
}