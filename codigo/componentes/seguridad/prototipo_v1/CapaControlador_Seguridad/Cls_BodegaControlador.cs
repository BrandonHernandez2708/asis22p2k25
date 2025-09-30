using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo_Seguridad;
using System.Data;

namespace CapaControlador_Seguridad

{
   public class Cls_BodegaControlador
    {
        Cls_BodegaDAO DAO = new Cls_BodegaDAO();
        public DataTable ObtenerBodegas()
        {
            return DAO.ObtenerBodegas();
        }
        public bool InsertarBodega(string nombre_bodegas)
        {
            return DAO.InsertarBodega(nombre_bodegas);
        }

        // Actualizar empleado
        public bool ActualizarBodega(int codigo_vodegas, string nombre_bodega, bool estatus_bodega)
        {
            return DAO.ActualizarBodega(codigo_vodegas, nombre_bodega, estatus_bodega);
        }

        // Eliminar empleado
        public bool EliminarBodega(int codigo_vodegas)
        {
            return DAO.EliminarBodega(codigo_vodegas);
        }

        // Consultar empleado por ID (regresa DataRow)
        public DataRow ConsultarBodegaPorId(int codigo_vodegas)
        {
            return DAO.ConsultarBodegasPorId(codigo_vodegas);
        }
    }
}
