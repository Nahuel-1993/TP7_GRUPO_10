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

            lblSeleccionados.Text = string.Empty;
        }

        protected void Provincia_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "FiltroProvincias")
            {
                // Se guarda la consulta WHERE en Session
                ViewState["FiltroProvincia"] = "WHERE [Id_ProvinciaSucursal] = @Id_Provincia";

                // Antes de agregar el nuevo parámetro, elimina el anterior si existe
                if (SqlDataSourceSucursales.SelectParameters["Id_Provincia"] != null)
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreSucursal = txtNombreSucursal.Text.Trim();
            string consultaWhere = " WHERE NombreSucursal LIKE @NombreSucursal";
            ViewState["FiltroProvincia"] = null;

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
            lblSeleccionados.Text = string.Empty;
        }

        protected void bSeleccionar_Command(object sender, CommandEventArgs e)
        {
            sucursal = new Sucursal();

            if (e.CommandName == "Seleccion")
            {
                string commandArgument = e.CommandArgument.ToString();
                string[] datos = commandArgument.Split('|');

                sucursal.IdSucursal = Convert.ToInt32(datos[0]);
                sucursal.nombreSucursal = datos[1];
                sucursal.descripcionSucursal = datos[2];

                if (sessionSelecciones.AgregarFila(sucursal))
                {
                    // Se agrega la fila a la tabla de la sesión
                    lblSeleccionados.Text = "Sucursal " + datos[1] + "  seleccionada correctamente.";
                }
                else
                {
                    // La sucursal ya estaba seleccionada
                    lblSeleccionados.Text = "La sucursal " + datos[1] + " ya fue seleccionada.";
                }

            }
        }
    }
}