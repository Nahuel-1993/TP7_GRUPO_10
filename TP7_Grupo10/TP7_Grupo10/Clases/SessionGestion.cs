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

        //Constructor vacio
        public SessionGestion()
        {

        }

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


            columna = new DataColumn("DIRECCIÓN", System.Type.GetType("System.String"));
            tabla.Columns.Add(columna);

            return tabla;
        }
        
        public bool AgregarFila(Sucursal sucursal)
        {

             if (Sucursal_Ya_Seleccionada(sucursal))
             {
                 return false;
             }

            DataRow filaNueva = dataTable.NewRow();

            filaNueva["ID SUCURSAL"] = sucursal.IdSucursal;
            filaNueva["NOMBRE"] = sucursal.nombreSucursal;
            filaNueva["DESCRIPCIÓN"] = sucursal.descripcionSucursal;
            filaNueva["DIRECCIÓN"] = sucursal.direccionSucursal;

            dataTable.Rows.Add(filaNueva);

            session[nombreSession] = dataTable; // Actualiza la sesión con la nueva tabla

            return true;
        }

        public bool EliminarSession()
        {
            //Si sesion no esta en null
            if (session != null && dataTable != null) { 

                //Los igualo a null
                session = null;
                dataTable = null;

                //Devulevo true
                return true;
            }
            else
            {
                //Devuelvo false
                return false; //Si devuelve false deberia de mandar un mensaje que diga que no hay nada seleccionado
            }
   
        }
        public bool Sucursal_Ya_Seleccionada(Sucursal sucursal)
        {
            if (session[nombreSession] != null)
            {
                DataTable tablaSession = session[nombreSession] as DataTable;

                foreach (DataRow row in tablaSession.Rows) 
                {
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