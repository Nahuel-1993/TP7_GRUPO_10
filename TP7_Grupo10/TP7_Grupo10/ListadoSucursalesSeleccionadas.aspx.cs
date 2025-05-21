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
        SessionSelecciones sessionSelecciones;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sessionSelecciones = new SessionSelecciones(Session);

                if(sessionSelecciones._dataTable.Rows.Count <= 0)
                {
                    gvSucursalesSeleccionadas.DataSource = sessionSelecciones._dataTable;
                    gvSucursalesSeleccionadas.DataBind();
                }
                else
                {
                    //Mensaje si no hay sucursales seleccionadas
                }
            }

        }
    }
}