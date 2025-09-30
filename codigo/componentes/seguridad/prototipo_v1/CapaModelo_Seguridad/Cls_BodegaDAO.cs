using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo_Seguridad
{
   public class Cls_BodegaDAO
    {
        Conexion conexion = new Conexion();
        public DataTable ObtenerBodegas()
        {
            DataTable dt = new DataTable();
            string query = "SELECT codigo_vodegas, nombre_bodegas FROM bodegas";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public bool InsertarBodega(string nombre_bodegas )
        {
            string query = "INSERT INTO bodegas (nombre_bodegas, estatus_bodega) VALUES (?, ?, ?, ?)";
            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", nombre_bodegas);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Actualizar empleado
        public bool ActualizarBodega(int codigo_vodegas, string nombre_bodega, bool estatus_bodega)
        {
            string query = "UPDATE bodegas SET nombre_bodegas = ?, estatus_bodega = ? WHERE codigo_vodegas = ?";
            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", nombre_bodega);
                    cmd.Parameters.AddWithValue("?", estatus_bodega ? 1 : 0);
                    return cmd.ExecuteNonQuery() > 0;
                   
                }
            }
        }
        public bool EliminarBodega(int codigo_vodegas)
        {
            string query = "DELETE FROM bodegas WHERE codigo_vodejas = ?";
            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", codigo_vodegas);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public DataRow ConsultarBodegasPorId(int codigo_vodegas)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Bodegas WHERE codigo_vodejas = ?";
            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", codigo_vodegas);
                    using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
    }
}
