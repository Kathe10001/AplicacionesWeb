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
    public class DAOUsuario
    {
        public SqlConnection Conexion()
        {
            string strConn = @"data source = KATHERINEFE9E8B\MSSQLSERVER02; " + "initial catalog = Spotify; " + "integrated security = true";
            //string strConn = @"data source = NB-MPEREZ\SQLEXPRESS; " + "initial catalog = Spotify; " + "integrated security = true";
            SqlConnection conn = new SqlConnection(strConn);
            return conn;
        }
        public VOUsuario Buscar(String email)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Usuario ");
            sb.Append("where Email= @email ");
            SqlConnection conn = null;
            SqlDataReader myReader = null;
            VOUsuario vou = null;

            try
            {
                conn = Conexion();
                conn.Open();

                SqlCommand comando = new SqlCommand(sb.ToString(), conn);
                SqlParameter emailParameter = new SqlParameter()
                {
                    ParameterName = "@email",
                    Value = email,
                    SqlDbType = SqlDbType.VarChar
                };
                comando.Parameters.Add(emailParameter);
                myReader = comando.ExecuteReader();
                if (myReader.Read())
                {
                    vou = new VOUsuario();
                    vou.Id = Convert.ToInt32(myReader["Id"]);
                    vou.Nombre = Convert.ToString(myReader["Nombre"]);
                    vou.Apellido = Convert.ToString(myReader["Apellido"]);
                    vou.Email = email;
                    vou.Contrasenia = Convert.ToString(myReader["Contrasenia"]);
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
            return vou;
        }


        public int Insertar(VOUsuario vou)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Usuario ");
            sb.Append("values(@Nombre, @Apellido, @Email, @Contrasenia) ");
            sb.Append("SELECT CAST(scope_identity() AS int)")
;           SqlConnection conn = null;
          
            int id = -1;
            try
            {
                conn = Conexion();
                conn.Open();

                SqlCommand comando = new SqlCommand(sb.ToString(), conn);
                SqlParameter nombreParameter = new SqlParameter()
                {
                    ParameterName = "@Nombre",
                    Value = vou.Nombre,
                    SqlDbType = SqlDbType.VarChar
                };
                comando.Parameters.Add(nombreParameter);

                SqlParameter apellidoMParameter = new SqlParameter()
                {
                    ParameterName = "@Apellido",
                    Value = vou.Apellido,
                    SqlDbType = SqlDbType.VarChar
                };
                comando.Parameters.Add(apellidoMParameter);

                SqlParameter emailParameter = new SqlParameter()
                {
                    ParameterName = "@Email",
                    Value = vou.Email,
                    SqlDbType = SqlDbType.VarChar
                };
                comando.Parameters.Add(emailParameter);

                SqlParameter contraseniaParameter = new SqlParameter()
                {
                    ParameterName = "@Contrasenia",
                    Value = vou.Contrasenia,
                    SqlDbType = SqlDbType.VarChar
                };
                comando.Parameters.Add(contraseniaParameter);

                id = (Int32)comando.ExecuteScalar();

            }
            catch (SqlException e)
            {
                throw new ApplicationException("Error con acceso a datos");
            }
            finally
            {

                if (conn != null)
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
            }
            return id;
        }


        public List<VOUsuario> Listar()
        {

            String consulta = "select  *  from Usuario";
            SqlConnection conn = null;
            SqlDataReader myReader = null;
            List<VOUsuario> listvou = null;

            try
            {
                conn = Conexion();
                conn.Open();

                SqlCommand comando = new SqlCommand(consulta, conn);


                myReader = comando.ExecuteReader();
                VOUsuario vou;
                while (myReader.Read())
                {
                    vou = new VOUsuario();
                    vou.Id = Convert.ToInt32(myReader["Id"]);
                    vou.Nombre = Convert.ToString(myReader["Nombre"]);
                    vou.Apellido = Convert.ToString(myReader["Apellido"]);
                    vou.Email = Convert.ToString(myReader["Email"]);
                    vou.Contrasenia = Convert.ToString(myReader["Contrasenia"]);
                    listvou.Add(vou);
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
            return listvou;
        }

        public void Borrar(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from Usuario ");
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
