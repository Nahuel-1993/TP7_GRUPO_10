using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP7_Grupo10.Clases
{
	public class Sucursal
	{
		private int _IdSucursal;
		private string _nombreSucursal;
		private string _descripcionSucursal;
		private int _IdHorario_Sucursal;
		private int _IdProvincia_Sucursal;
		private string _direccionSucursal;
		private string _URLImagen_Sucursal;

        public Sucursal() { }

        public Sucursal(int _id_Sucursal, string _NombreSucurssal, string _DescripcionSucursal, int _idHorario_Sucursal, int _idProvincia_Sucursal, string _DireccionSucursal, string _URLimagen ) 
        {
            _IdSucursal = _id_Sucursal;
            _nombreSucursal = _NombreSucurssal;
            _descripcionSucursal = _DescripcionSucursal;
            _IdHorario_Sucursal = _idHorario_Sucursal;
            _IdProvincia_Sucursal = _idProvincia_Sucursal;
            _direccionSucursal = _DireccionSucursal;
            _URLImagen_Sucursal = _URLimagen;

        }

        public int IdSucursal
		{

			get 
			{
				return _IdSucursal;
			
			}
			set 
			{
                _IdSucursal = value;
            }
		}

        public string nombreSucursal
        {

            get
            {
				return _nombreSucursal;

            }
            set
            {
               _nombreSucursal = value;
            }
        }

        public string descripcionSucursal
        {
            get
            {
                return _descripcionSucursal;
            }
            set
            {
                _descripcionSucursal = value;
            }
        }

        public int IdHorario_Sucursal
        {
            get
            {
                return _IdHorario_Sucursal;
            }
            set
            {
                _IdHorario_Sucursal = value;
            }
        }

        public int IdProvincia_Sucursal
        {
            get
            {
                return _IdProvincia_Sucursal;
            }
            set
            {
                _IdProvincia_Sucursal = value;
            }
        }

        public string direccionSucursal
        {
            get
            {
                return _direccionSucursal;
            }
            set
            {
                _direccionSucursal = value;
            }
        }

        public string URLImagen_Sucursal
        {
            get
            {
                return _URLImagen_Sucursal;
            }
            set
            {
                _URLImagen_Sucursal = value;
            }
        }
    }
}