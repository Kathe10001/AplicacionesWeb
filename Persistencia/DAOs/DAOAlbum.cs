using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.VOs;

namespace Persistencia.DAOs
{
    public class DAOAlbum
    {
        public SqlConnection Conexion()
        {
            string strConn = @"data source = KATHERINEFE9E8B\MSSQLSERVER02; " + "initial catalog = Spotify; " + "integrated security = true";
            //string strConn = @"data source = NB-MPEREZ\SQLEXPRESS; " + "initial catalog = Spotify; " + "integrated security = true";
            SqlConnection conn = new SqlConnection(strConn);
            return conn;
        }

        public String ConsultaListar(string nombre, int anioCreacion, string generoMusical)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select  *  from Album");

            if (nombre != null || anioCreacion != 0 || generoMusical != null)
            {

                sb.Append(" where ");

                List<string> parametros = new List<string>();
                if (nombre != null)
                {
                    parametros.Add("Nombre like @nombre");
                }
                if (anioCreacion != 0)
                {
                    parametros.Add("AnioCreacion = @anioCreacion");
                }
                if (generoMusical != null)
                {
                    parametros.Add("GeneroMusical like @generoMusical");
                }

                sb.Append(String.Join(" AND ", parametros));
            }
            return sb.ToString();
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
            sb.Append("values(@Nombre, @GeneroMusical, @Banda,@AnioCreacion) ");
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
            List<VOAlbum> listvoa = new List<VOAlbum>();

            try
            {
                conn = Conexion();
                conn.Open();

                SqlCommand comando = new SqlCommand(consulta, conn);
                myReader = comando.ExecuteReader();
                VOAlbum voa;
                while (myReader.Read())
                {
                    voa = new VOAlbum();
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

        public List<VOAlbum> Listar(string nombre, int anioCreacion, string generoMusical)
        {

            SqlConnection conn = null;
            SqlDataReader myReader = null;
            List<VOAlbum> listVoc = new List<VOAlbum>();
            try
            {
                conn = Conexion();
                conn.Open();

                String consulta = ConsultaListar(nombre, anioCreacion, generoMusical);

                SqlCommand comando = new SqlCommand(consulta, conn);

                if (nombre != null)
                {
                    SqlParameter nomParameter = new SqlParameter()
                    {
                        ParameterName = "@nombre",
                        Value = nombre,
                        SqlDbType = SqlDbType.VarChar
                    };
                    comando.Parameters.Add(nomParameter);
                }
                if (anioCreacion != 0)
                {
                    SqlParameter anioParameter = new SqlParameter()
                    {
                        ParameterName = "@anioCreacion",
                        Value = anioCreacion,
                        SqlDbType = SqlDbType.Int
                    };
                    comando.Parameters.Add(anioParameter);
                }
                if (generoMusical != null)
                {
                    SqlParameter genParameter = new SqlParameter()
                    {
                        ParameterName = "@generoMusical",
                        Value = generoMusical,
                        SqlDbType = SqlDbType.VarChar
                    };
                    comando.Parameters.Add(genParameter);
                }

                myReader = comando.ExecuteReader();
                while (myReader.Read())
                {
                    VOAlbum voc = new VOAlbum();
                    voc.Id = Convert.ToInt32(myReader["Id"]);
                    voc.Nombre = Convert.ToString(myReader["Nombre"]);
                    voc.GeneroMusical = Convert.ToString(myReader["GeneroMusical"]);
                    voc.IdBanda = Convert.ToInt32(myReader["Banda"]);
                    voc.AnioCreacion = Convert.ToInt32(myReader["AnioCreacion"]);
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
            List<VOCancion> listVoc = new List<VOCancion>();

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

        public void AgregarCancion(int idAlbum, int idCancion)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into CancionAlbum ");
            sb.Append("values(@IdCancion, @IdAlbum) ");
            SqlConnection conn = null;
            SqlDataReader myReader = null;

            try
            {
                conn = Conexion();
                conn.Open();

                SqlCommand comando = new SqlCommand(sb.ToString(), conn);
                SqlParameter idcancionParameter = new SqlParameter()
                {
                    ParameterName = "@IdCancion",
                    Value = idCancion,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(idcancionParameter);

                SqlParameter idalbumCParameter = new SqlParameter()
                {
                    ParameterName = "@IdAlbum",
                    Value = idAlbum,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(idalbumCParameter);

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

        public void QuitarCancion(int idAlbum, int idCancion)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from CancionAlbum ");
            sb.Append("where IdCancion = @IdCancion and IdAlbum =  @IdAlbum ");
            SqlConnection conn = null;
            SqlDataReader myReader = null;

            try
            {
                conn = Conexion();
                conn.Open();

                SqlCommand comando = new SqlCommand(sb.ToString(), conn);
                SqlParameter idcancionParameter = new SqlParameter()
                {
                    ParameterName = "@IdCancion",
                    Value = idCancion,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(idcancionParameter);

                SqlParameter idalbumCParameter = new SqlParameter()
                {
                    ParameterName = "@IdAlbum",
                    Value = idAlbum,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(idalbumCParameter);

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
    }
}