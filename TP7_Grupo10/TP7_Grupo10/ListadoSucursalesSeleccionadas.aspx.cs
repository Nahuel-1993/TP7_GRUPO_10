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

            if (Session["EstadoDireccion"] == null)
            {
                Session["EstadoDireccion"] = false;
            }

            if (!IsPostBack) 
            {
                if (sessionSelecciones._dataTable != null && sessionSelecciones._dataTable.Rows.Count > 0)
                {
                    Session["EstadoDireccion"] = false;
                    gvSucursalesSeleccionadas.DataSource = sessionSelecciones._dataTable;
                    gvSucursalesSeleccionadas.DataBind();
                    lblMensaje.Visible = false; // Ocultamos el mensaje si hay datos
                    btnMostrarDireccion.Visible = true;
                }
                else
                {
                    lblMensaje.Text = "No hay sucursales seleccionadas";
                    lblMensaje.Visible = true;
                    btnMostrarDireccion.Visible = false;
                }

            }

            gvSucursalesSeleccionadas.Columns[4].Visible = estadoDireccion;

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

                if(gvSucursalesSeleccionadas.Rows.Count == 0)
                {
                    btnMostrarDireccion.Visible = false;
                }
            }
        }

        bool estadoDireccion
        {
            get { return Session["EstadoDireccion"] != null ? (bool)Session["EstadoDireccion"] : false; }
            set { Session["EstadoDireccion"] = value; }
        }
        protected void btnMostrarDireccion_Click(object sender, EventArgs e)
        {
            if (!estadoDireccion)
            {
                estadoDireccion = true;
                gvSucursalesSeleccionadas.Columns[4].Visible = true;
                btnMostrarDireccion.Text = "Ocultar Dirección";
            }

            else
            {
                estadoDireccion = false;
                gvSucursalesSeleccionadas.Columns[4].Visible = false;
                btnMostrarDireccion.Text = "Mostrar Dirección";
            }
        }
    }
}