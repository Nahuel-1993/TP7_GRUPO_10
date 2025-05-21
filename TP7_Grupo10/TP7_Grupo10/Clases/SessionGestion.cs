using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;


namespace TP7_Grupo10.Clases
{
	public class SessionGestion
	{
        HttpSessionState session;
        DataTable dataTable;
        const string nombreSession = "TablaSucursales";
        public SessionGestion(HttpSessionState sesion)
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

        public DataTable CrearTabla()
        {
            DataTable tabla = new DataTable();

            DataColumn columna = new DataColumn("ID SUCURSAL", System.Type.GetType("System.Int32"));
            tabla.Columns.Add(columna);

            columna = new DataColumn("NOMBRE", System.Type.GetType("System.String"));
            tabla.Columns.Add(columna);

            columna = new DataColumn("DESCRIPCIÓN", System.Type.GetType("System.String"));
            tabla.Columns.Add(columna);

            return tabla;
        }

       public bool AgregarFila(Sucursal sucursal)
        {

            foreach (DataRow fila in dataTable.Rows)
            {
                if (Convert.ToInt32(fila["ID Sucursal"]) == sucursal.IdSucursal)
                {
                    return false;
                }
            }

            DataRow filaNueva = dataTable.NewRow();

            filaNueva["ID SUCURSAL"] = sucursal.IdSucursal;
            filaNueva["NOMBRE"] = sucursal.nombreSucursal;
            filaNueva["DESCRIPCIÓN"] = sucursal.nombreSucursal;

            dataTable.Rows.Add(filaNueva);

            session[nombreSession] = dataTable; // Actualiza la sesión con la nueva tabla

            return true;
        }

    }
}