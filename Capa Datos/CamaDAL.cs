using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CamaDAL:CadenaDAL
    {
        public List<CamaCLS> listarCama()
        {
            List<CamaCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    // abro la conexion
                    cn.Open();
                    // llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarCama", cn))
                    {
                        // buena practica (Opcional) -> Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<CamaCLS>();
                            CamaCLS oCamaCLS;

                            int posId = drd.GetOrdinal("IIDCAMA");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");

                            while (drd.Read())
                            {
                                oCamaCLS = new CamaCLS();
                                oCamaCLS.idcama = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oCamaCLS.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);
                                oCamaCLS.descripcion = drd.IsDBNull(posDescripcion) ? "" : drd.GetString(posDescripcion);
                                lista.Add(oCamaCLS);
                            }
                        }
                    }
                    // cierro una vez que trae la data
                    cn.Close();
                }
                catch (Exception)
                {
                    cn.Close();
                    //throw;
                }
            }
            return lista;
        }
    }
}
