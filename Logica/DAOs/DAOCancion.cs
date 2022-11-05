using Logica.VOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.DAOs
{
    class DAOCancion
    {
        public SqlConnection Conexion()
        {
            string strConn = @"data source = NB-MPEREZ\SQLEXPRESS; " + "initial catalog = Spotify; " + "integrated security = true";
            SqlConnection conn = new SqlConnection(strConn);
            return conn;
        }
        public VOCancion Buscar(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Cancion ");
            sb.Append("where Id= @id ");
            SqlConnection conn = null;
            SqlDataReader myReader = null;
            VOCancion voc = null;
 
            try
            {
                conn = Conexion();
                conn.Open();

                SqlCommand comando = new SqlCommand(sb.ToString(), conn);
                SqlParameter idParameter = new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = id,
                    SqlDbType = SqlDbType.Int 
                };
                comando.Parameters.Add(idParameter);
                myReader = comando.ExecuteReader();
                if (myReader.Read())
                {
                   voc = new VOCancion();
                   voc.Id = id;
                   voc.Nombre = Convert.ToString(myReader["Nombre"]);
                   voc.GeneroMusical = Convert.ToString(myReader["GeneroMusical"]);
                   voc.Duracion = Convert.ToInt32(myReader["Duracion"]);
                   voc.Anio = Convert.ToInt32(myReader["Anio"]);
                   voc.IdCantante = Convert.ToInt32(myReader["Cantante"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed)
                        myReader.Close();

                if (conn != null)
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
            }
            return voc;
        }

    }
}
