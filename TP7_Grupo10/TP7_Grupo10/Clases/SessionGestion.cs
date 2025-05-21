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

        private DataTable CrearTabla()
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

        private bool AgregarFila(DataTable tabla, Sucursal sucursal)
        {
           /* if (Sucursal_Ya_Seleccionada(sucursal))
            {
                return false;
            }*/

            foreach (DataRow fila in tabla.Rows)
            {
                if (Convert.ToInt32(fila["ID Sucursal"]) == sucursal.IdSucursal)
                {
                    return false;
                }
            }

            DataRow filaNueva = tabla.NewRow();

            filaNueva["ID SUCURSAL"] = sucursal.IdSucursal;
            filaNueva["NOMBRE"] = sucursal.nombreSucursal;
            filaNueva["DESCRIPCIÓN"] = sucursal.nombreSucursal;

            tabla.Rows.Add(filaNueva);

            return true;
        }

      /*  public bool Sucursal_Ya_Seleccionada(Sucursal sucursal)
        {
            
        }*/
    }
}