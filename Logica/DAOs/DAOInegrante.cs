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
    class DAOIntegrante
    {
        public SqlConnection Conexion()
        {
            string strConn = @"data source = NB-MPEREZ\SQLEXPRESS; " + "initial catalog = Spotify; " + "integrated security = true";
            SqlConnection conn = new SqlConnection(strConn);
            return conn;
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
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(apellidoMParameter);

                SqlParameter fechaNParameter = new SqlParameter()
                {
                    ParameterName = "@FechaNacimiento",
                    Value = voi.FechaNacimiento,
                    SqlDbType = SqlDbType.Int
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
            List<VOIntegrante> listvoi = null;

            try
            {
                conn = Conexion();
                conn.Open();

                SqlCommand comando = new SqlCommand(consulta, conn);


                myReader = comando.ExecuteReader();
                VOIntegrante voi = new VOIntegrante();
                while (myReader.Read())
                {
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

        public List<VOIntegrante> ListarIntegrantes(int idIntegrante)
        {
            throw new NotImplementedException();
        }
    }
}
