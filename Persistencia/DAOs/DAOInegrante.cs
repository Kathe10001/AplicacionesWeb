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
    public class DAOIntegrante
    {
        public SqlConnection Conexion()
        {
            string strConn = @"data source = KATHERINEFE9E8B\MSSQLSERVER02; " + "initial catalog = Spotify; " + "integrated security = true";
            //string strConn = @"data source = NB-MPEREZ\SQLEXPRESS; " + "initial catalog = Spotify; " + "integrated security = true";
            SqlConnection conn = new SqlConnection(strConn);
            return conn;
        }

        public String ConsultaListar(string nombre, string apellido)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select  *  from Integrante");

            if (nombre != null || apellido != null)
            {

                sb.Append(" where ");

                List<string> parametros = new List<string>();
                if (nombre != null)
                {
                    parametros.Add("Nombre like @nombre");
                }

                if (apellido != null)
                {
                    parametros.Add("Apellido like @apellido");
                }

                sb.Append(String.Join(" AND ", parametros));
            }
            return sb.ToString();
        }

        public VOIntegrante Buscar(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Integrante ");
            sb.Append("where Id= @id ");
            SqlConnection conn = null;
            SqlDataReader myReader = null;
            VOIntegrante voi = null;

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
                    voi = new VOIntegrante();
                    voi.Id = id;
                    voi.Nombre = Convert.ToString(myReader["Nombre"]);
                    voi.Apellido = Convert.ToString(myReader["Apellido"]);
                    voi.FechaNacimiento = Convert.ToDateTime(myReader["FechaNacimiento"]);
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
            return voi;
        }


        public void Insertar(VOIntegrante voi)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Integrante ");
            sb.Append("values(@Nombre, @Apellido, @FechaNacimiento) ");
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
                    Value = voi.Nombre,
                    SqlDbType = SqlDbType.VarChar
                };
                comando.Parameters.Add(nombreParameter);

                SqlParameter apellidoMParameter = new SqlParameter()
                {
                    ParameterName = "@Apellido",
                    Value = voi.Apellido,
                    SqlDbType = SqlDbType.VarChar
                };
                comando.Parameters.Add(apellidoMParameter);

                SqlParameter fechaNParameter = new SqlParameter()
                {
                    ParameterName = "@FechaNacimiento",
                    Value = voi.FechaNacimiento,
                    SqlDbType = SqlDbType.DateTime
                };
                comando.Parameters.Add(fechaNParameter);

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


        public List<VOIntegrante> Listar()
        {

            String consulta = "select  *  from Integrante";
            SqlConnection conn = null;
            SqlDataReader myReader = null;
            List<VOIntegrante> listvoi = new List<VOIntegrante>();

            try
            {
                conn = Conexion();
                conn.Open();

                SqlCommand comando = new SqlCommand(consulta, conn);


                myReader = comando.ExecuteReader();
                VOIntegrante voi;
                while (myReader.Read())
                {
                    voi = new VOIntegrante();
                    voi.Id = Convert.ToInt32(myReader["Id"]);
                    voi.Nombre = Convert.ToString(myReader["Nombre"]);
                    voi.Apellido = Convert.ToString(myReader["Apellido"]);
                    voi.FechaNacimiento = Convert.ToDateTime(myReader["FechaNacimiento"]);
                    listvoi.Add(voi);
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
            return listvoi;
        }

        public List<VOIntegrante> Listar(string nombre, string apellido)
        {

            SqlConnection conn = null;
            SqlDataReader myReader = null;
            List<VOIntegrante> listVoc = new List<VOIntegrante>();
            try
            {
                conn = Conexion();
                conn.Open();

                String consulta = ConsultaListar(nombre, apellido);

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

                if (apellido != null)
                {
                    SqlParameter apParameter = new SqlParameter()
                    {
                        ParameterName = "@apellido",
                        Value = apellido,
                        SqlDbType = SqlDbType.VarChar
                    };
                    comando.Parameters.Add(apParameter);
                }

                myReader = comando.ExecuteReader();
                while (myReader.Read())
                {
                    VOIntegrante voc = new VOIntegrante();
                    voc.Id = Convert.ToInt32(myReader["Id"]);
                    voc.Nombre = Convert.ToString(myReader["Nombre"]);
                    voc.Apellido = Convert.ToString(myReader["Apellido"]);
                    voc.FechaNacimiento = Convert.ToDateTime(myReader["FechaNacimiento"]);
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
            sb.Append("delete from Integrante ");
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