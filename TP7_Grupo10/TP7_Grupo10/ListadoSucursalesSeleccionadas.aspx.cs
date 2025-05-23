using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TP7_Grupo10.Clases;
using System.Reflection;


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
                    btnEliminarTodo.Visible = true;
                }
                else
                {
                    lblMensaje.Visible = true;
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
                    lblMensaje.Visible = true;
                }

                if(gvSucursalesSeleccionadas.Rows.Count == 0)
                {
                    btnMostrarDireccion.Visible = false;
                    btnEliminarTodo.Visible = false;
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

        protected void btnEliminarTodo_Click(object sender, EventArgs e)
        {
            DataTable dt = sessionSelecciones._dataTable;
            dt.Rows.Clear();
            dt.AcceptChanges();
            sessionSelecciones._dataTable = dt;
            gvSucursalesSeleccionadas.DataSource = dt;
            gvSucursalesSeleccionadas.DataBind();

            btnEliminarTodo.Visible = false;
            btnMostrarDireccion.Visible = false;

            lblMensaje.Visible = true;
        }
    }
}