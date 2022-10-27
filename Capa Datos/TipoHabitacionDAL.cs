using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Capa_Datos
{
    public class TipoHabitacionDAL
    {
        /*
        public List<TipoHabitacionCLS> listarTipoHabitacion()
        {
            List<TipoHabitacionCLS> lista = new List<TipoHabitacionCLS>();
            lista.Add(new TipoHabitacionCLS
            {
                id = 1,
                nombre = "Simple",
                descripcion = "Solo para uno"
            });
            lista.Add(new TipoHabitacionCLS
            {
                id = 2,
                nombre = "Doble",
                descripcion = "Hecho para casados"
            });

            return lista;
        }
        */

        public List<TipoHabitacionCLS> listarTipoHabitacion()
        {
            List<TipoHabitacionCLS> lista = null;
            using (SqlConnection cn = new SqlConnection("server=ALEJANDRO-PC;database=BDHotel; Integrated Security=true"))
            {
                try
                {
                    // abro la conexion
                    cn.Open();
                    // llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarTipoHabitacion", cn))
                    {
                        // buena practica (Opcional) -> Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if(drd != null)
                        {
                            lista = new List<TipoHabitacionCLS>();
                            TipoHabitacionCLS oTipoHabitacionCLS;
                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.GetInt32(0);
                                oTipoHabitacionCLS.nombre = drd.GetString(1);
                                oTipoHabitacionCLS.descripcion = drd.GetString(2);
                                lista.Add(oTipoHabitacionCLS);
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
