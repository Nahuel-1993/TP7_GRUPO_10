using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace MiPractica_TP_N_7.Clases_Flor
{
	public class SessionSelecciones
	{
        HttpSessionState session;
        DataTable dataTable;
        const string nombreSession = "SeleccionSucursal";
        public SessionSelecciones(HttpSessionState sesion)
        {
            session = sesion;

            if (session[nombreSession] == null)
            {
                session[nombreSession] = CrearTabla();
            }
            else
            {
                dataTable = session[nombreSession] as DataTable;
            }

        }
        public HttpSessionState _session
        { 
            get 
            { 
                return session; 
            }

            set 
            { 
                session = value; 
            } 
        }

        public DataTable _dataTable
        {
            get
            {
                return dataTable;
            }
            set
            {
                dataTable = value;
            }
        }

        private DataTable CrearTabla()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id Sucursal", typeof(int));
            dataTable.Columns.Add("Nombre", typeof(string));
            dataTable.Columns.Add("Descripcion", typeof(string));
            return dataTable;
        }

        public bool AgregarFilaTabla(Sucursales_Flor sucursal)
        {
            if (Sucursal_Ya_Seleccionada(sucursal))
            {
                return false;
            }
            else
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["Id Sucursal"] = sucursal.IdSucursal;
                dataRow["Nombre"] = sucursal.nombreSucursal;
                dataRow["Descripcion"] = sucursal.descripcionSucursal;
                dataTable.Rows.Add(dataRow);
                return true;
            }
        }

        public bool Sucursal_Ya_Seleccionada(Sucursales_Flor sucursal)
        {
            // Verifica si la sesión de usuario es nula
            if (session[nombreSession] != null)
            {
                DataTable tablaSession = session[nombreSession] as DataTable;
                foreach (DataRow row in tablaSession.Rows) // Cambiado de DataTable a DataRow
                {
                    // Verifica si el ID de la Sucursal seleccionada es igual al ID de la sucursal en la fila seleccionada
                    if (Convert.ToInt32(row["Id Sucursal"]) == sucursal.IdSucursal)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}