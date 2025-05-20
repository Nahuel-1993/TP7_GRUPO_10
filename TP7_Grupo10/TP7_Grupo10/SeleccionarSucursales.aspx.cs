using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP7_Grupo10
{
    public partial class SeleccionarSucursales : System.Web.UI.Page
    {
        string ConsultaBase = "SELECT [Id_Sucursal], [NombreSucursal], [DescripcionSucursal], [Id_ProvinciaSucursal], [URL_Imagen_Sucursal] FROM [Sucursal]";
        string CondicionWhere = string.Empty;      

        protected void Page_Load(object sender, EventArgs e)
        {                       
                if (Session["TablaSucursales"] == null)
                {
                    Session["TablaSucursales"] = CrearTabla();
                }            
        }

        protected void Provincia_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "FiltroProvincias")
            {
                CondicionWhere = "WHERE [Id_ProvinciaSucursal] = @Id_Provincia";
                // Antes de agregar el nuevo parámetro, elimina el anterior si existe
                if( SqlDataSourceSucursales.SelectParameters["Id_Provincia"] != null)
                {
                    SqlDataSourceSucursales.SelectParameters.Remove(SqlDataSourceSucursales.SelectParameters["Id_Provincia"]);
                }
                SqlDataSourceSucursales.SelectParameters.Add("Id_Provincia", e.CommandArgument.ToString());
                SqlDataSourceSucursales.SelectCommand = ConsultaBase + " " + CondicionWhere;
                SqlDataSourceSucursales.DataBind();
            }
        }

        protected void lvSucursales_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            ///agregar el código en respuesta a Seleccionar
            
        }

        private DataTable CrearTabla()
        {
            DataTable tabla = new DataTable();

            DataColumn columna = new DataColumn("ID SUCURSAL", System.Type.GetType("System.String"));
            tabla.Columns.Add(columna);

            columna = new DataColumn("NOMBRE", System.Type.GetType("System.String"));
            tabla.Columns.Add(columna);

            columna = new DataColumn("DESCRIPCIÓN", System.Type.GetType("System.String"));
            tabla.Columns.Add(columna);

            return tabla;
        }

        private void AgregarFila(DataTable tabla, ListViewItem item)
        {

        }
    }
}