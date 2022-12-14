using Logica.VOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAOs
{
    public class DAOCancion
    {
        public SqlConnection Conexion()
        {
            string strConn = @"data source = KATHERINEFE9E8B\MSSQLSERVER02; " + "initial catalog = Spotify; " + "integrated security = true";
            //string strConn = @"data source = NB-MPEREZ\SQLEXPRESS; " + "initial catalog = Spotify; " + "integrated security = true";
            SqlConnection conn = new SqlConnection(strConn);
            return conn;
        }

        public String ConsultaListar(string nombre, int anio, string generoMusical)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select  *  from Cancion");

            if (nombre != null || anio != 0 || generoMusical != null)
            {

                sb.Append(" where ");

                List<string> parametros = new List<string>();
                if (nombre != null)
                {
                    parametros.Add("Nombre like @nombre");
                }
                if (anio != 0)
                {
                    parametros.Add("Anio = @anio");
                }
                if (generoMusical != null)
                {
                    parametros.Add("GeneroMusical like @genero");
                }

                sb.Append(String.Join(" AND ", parametros));
            }
            return sb.ToString();
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
            return voc;
        }


        public void Insertar(VOCancion voc)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Cancion ");
            sb.Append("values(@Nombre, @Duracion, @Anio, @Genero, @Cantante) ");
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
                    Value = voc.Nombre,
                    SqlDbType = SqlDbType.VarChar
                };
                comando.Parameters.Add(nombreParameter);

                SqlParameter duracionParameter = new SqlParameter()
                {
                    ParameterName = "@Duracion",
                    Value = voc.Duracion,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(duracionParameter);

                SqlParameter anioParameter = new SqlParameter()
                {
                    ParameterName = "@Anio",
                    Value = voc.Anio,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(anioParameter);

                SqlParameter generoParameter = new SqlParameter()
                {
                    ParameterName = "@Genero",
                    Value = voc.GeneroMusical,
                    SqlDbType = SqlDbType.VarChar
                };
                comando.Parameters.Add(generoParameter);

                SqlParameter cantanteParameter = new SqlParameter()
                {
                    ParameterName = "@Cantante",
                    Value = voc.IdCantante,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(cantanteParameter);

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


        public List<VOCancion> Listar()
        {

            String consulta = "select  *  from Cancion";
            SqlConnection conn = null;
            SqlDataReader myReader = null;
            List<VOCancion> listVoc = new List<VOCancion>();

            try
            {
                conn = Conexion();
                conn.Open();

                SqlCommand comando = new SqlCommand(consulta, conn);


                myReader = comando.ExecuteReader();
                VOCancion voc;
                while (myReader.Read())
                {
                    voc = new VOCancion();
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
        public List<VOCancion> Listar(string nombre, int anio, string generoMusical)
        {

            SqlConnection conn = null;
            SqlDataReader myReader = null;
            List<VOCancion> listVoc = new List<VOCancion>();
            try
            {
                conn = Conexion();
                conn.Open();

                String consulta = ConsultaListar(nombre, anio, generoMusical);

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
                if (anio != 0)
                {
                    SqlParameter anioParameter = new SqlParameter()
                    {
                        ParameterName = "@anio",
                        Value = anio,
                        SqlDbType = SqlDbType.Int
                    };
                    comando.Parameters.Add(anioParameter);
                }
                if (generoMusical != null)
                {
                    SqlParameter genParameter = new SqlParameter()
                    {
                        ParameterName = "@genero",
                        Value = generoMusical,
                        SqlDbType = SqlDbType.VarChar
                    };
                    comando.Parameters.Add(genParameter);
                }

                myReader = comando.ExecuteReader();
                while (myReader.Read())
                {
                    VOCancion voc = new VOCancion();
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

        public void Borrar(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from Cancion ");
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



    }
}