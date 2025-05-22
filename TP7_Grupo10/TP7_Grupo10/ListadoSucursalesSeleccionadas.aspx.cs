using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TP7_Grupo10.Clases;


namespace TP7_Grupo10
{
    public partial class ListadoSucursalesSeleccionadas : System.Web.UI.Page
    {
        SessionGestion sessionSelecciones;
        protected void Page_Load(object sender, EventArgs e)
        {
            sessionSelecciones = new SessionGestion(Session);

            if (!IsPostBack)
            {
                if (sessionSelecciones._dataTable != null && sessionSelecciones._dataTable.Rows.Count > 0)
                {
                    gvSucursalesSeleccionadas.DataSource = sessionSelecciones._dataTable;
                    gvSucursalesSeleccionadas.DataBind();
                    lblMensaje.Visible = false; // Ocultamos el mensaje si hay datos
                }
                else
                {
                    lblMensaje.Text = "No hay sucursales seleccionadas";
                    lblMensaje.Visible = true;
                }
            }
        }


        protected void gvSucursalesSeleccionadas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable dt = sessionSelecciones._dataTable;
                dt.Rows[index].Delete();
                dt.AcceptChanges();
                sessionSelecciones._dataTable = dt;
                gvSucursalesSeleccionadas.DataSource = dt;
                gvSucursalesSeleccionadas.DataBind();

                if (sessionSelecciones._dataTable == null || sessionSelecciones._dataTable.Rows.Count <= 0)
                {
                    lblMensaje.Text = "No hay sucursales seleccionadas";
                    lblMensaje.Visible = true;
                }
            }
        }
    }
}