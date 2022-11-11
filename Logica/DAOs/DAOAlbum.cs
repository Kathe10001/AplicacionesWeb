using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.VOs;

namespace Logica.DAOs
{
    class DAOAlbum
    {
        public SqlConnection Conexion()
        {
            string strConn = @"data source = NB-MPEREZ\SQLEXPRESS; " + "initial catalog = Spotify; " + "integrated security = true";
            SqlConnection conn = new SqlConnection(strConn);
            return conn;
        }
        public VOAlbum Buscar(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Album ");
            sb.Append("where Id= @id ");
            SqlConnection conn = null;
            SqlDataReader myReader = null;
            VOAlbum voa = null;

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
                    voa = new VOAlbum();
                    voa.Id = id;
                    voa.Nombre = Convert.ToString(myReader["Nombre"]);
                    voa.GeneroMusical = Convert.ToString(myReader["GeneroMusical"]);
                    voa.IdBanda = Convert.ToInt32(myReader["Banda"]);
                    voa.AnioCreacion = Convert.ToInt32(myReader["AnioCreacion"]);
                }
            }
            catch (SqlException e)
            {
                throw new ApplicationException("Error con acceso a datos");
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
            return voa;
        }


        public void Insertar(VOAlbum voa)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Album ");
            sb.Append("values(@Nombre, @AnioCreacion, @GeneroMusical, @Banda) ");
            SqlConnection conn = null;
            SqlDataReader myReader = null;

            try
            {
                conn = Conexion();
                conn.Open();

                SqlCommand comando = new SqlCommand(sb.ToString(), conn);
                SqlParameter nombreParameter = new SqlParameter()
                {
                    ParameterName = "@Nombre",
                    Value = voa.Nombre,
                    SqlDbType = SqlDbType.VarChar
                };
                comando.Parameters.Add(nombreParameter);

                SqlParameter anioCParameter = new SqlParameter()
                {
                    ParameterName = "@AnioCreacion",
                    Value = voa.AnioCreacion,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(anioCParameter);

                SqlParameter generoMParameter = new SqlParameter()
                {
                    ParameterName = "@GeneroMusical",
                    Value = voa.GeneroMusical,
                    SqlDbType = SqlDbType.VarChar
                };
                comando.Parameters.Add(generoMParameter);

                SqlParameter bandaParameter = new SqlParameter()
                {
                    ParameterName = "@Banda",
                    Value = voa.IdBanda,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(bandaParameter);
                myReader = comando.ExecuteReader();
            }
            catch (SqlException e)
            {
                throw new ApplicationException("Error con acceso a datos");
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
        }


        public List<VOAlbum> Listar()
        {

            String consulta = "select  *  from Album";
            SqlConnection conn = null;
            SqlDataReader myReader = null;
            List<VOAlbum> listvoa = null;

            try
            {
                conn = Conexion();
                conn.Open();

                SqlCommand comando = new SqlCommand(consulta, conn);
                myReader = comando.ExecuteReader();
                VOAlbum voa = new VOAlbum();
                while (myReader.Read())
                {
                    voa.Id = Convert.ToInt32(myReader["Id"]);
                    voa.Nombre = Convert.ToString(myReader["Nombre"]);
                    voa.GeneroMusical = Convert.ToString(myReader["GeneroMusical"]);
                    voa.IdBanda = Convert.ToInt32(myReader["Banda"]);
                    voa.AnioCreacion = Convert.ToInt32(myReader["AnioCreacion"]);
                    listvoa.Add(voa);
                }

            }
            catch (SqlException e)
            {
                throw new ApplicationException("Error con acceso a datos");
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
            return listvoa;
        }

        public void Borrar(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from Album ");
            sb.Append("where Id= @id ");
            SqlConnection conn = null;
            SqlDataReader myReader = null;

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

            }
            catch (SqlException e)
            {
                throw new ApplicationException("Error con acceso a datos");
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
        }

        public List<VOCancion> ListarCanciones(int idAlbum)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select  C.*  from Cancion C inner join ");
            sb.Append("CancionAlbum CA on C.Id = CA.IdCancion ");
            sb.Append("where CA.IdAlbum = @idAlbum ");

            SqlConnection conn = null;
            SqlDataReader myReader = null;
            List<VOCancion> listVoc = null;

            try
            {
                conn = Conexion();
                conn.Open();
                SqlCommand comando = new SqlCommand(sb.ToString(), conn);

                SqlParameter idParameter = new SqlParameter()
                {
                    ParameterName = "@idAlbum",
                    Value = idAlbum,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(idParameter);

                myReader = comando.ExecuteReader();
                VOCancion voc = new VOCancion();
                while (myReader.Read())
                {
                    voc.Id = Convert.ToInt32(myReader["Id"]);
                    voc.Nombre = Convert.ToString(myReader["Nombre"]);
                    voc.GeneroMusical = Convert.ToString(myReader["GeneroMusical"]);
                    voc.Duracion = Convert.ToInt32(myReader["Duracion"]);
                    voc.Anio = Convert.ToInt32(myReader["Anio"]);
                    voc.IdCantante = Convert.ToInt32(myReader["Cantante"]);
                    listVoc.Add(voc);
                }

            }
            catch (SqlException e)
            {
                throw new ApplicationException("Error con acceso a datos");
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
            return listVoc;
        }
    }
}
