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
    public class DAOBanda
    {
        public SqlConnection Conexion()
        {
            string strConn = @"data source = KATHERINEFE9E8B\MSSQLSERVER02; " + "initial catalog = Spotify; " + "integrated security = true";
            //string strConn = @"data source = NB-MPEREZ\SQLEXPRESS; " + "initial catalog = Spotify; " + "integrated security = true";
            SqlConnection conn = new SqlConnection(strConn);
            return conn;
        }

        public String ConsultaListar(string nombre, string generoMusical)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select  *  from Banda");

            if (nombre != null || generoMusical != null)
            {

                sb.Append(" where ");

                List<string> parametros = new List<string>();
                if (nombre != null)
                {
                    parametros.Add("Nombre like @nombre");
                }

                if (generoMusical != null)
                {
                    parametros.Add("GeneroMusical like @generoMusical");
                }

                sb.Append(String.Join(" AND ", parametros));
            }
            return sb.ToString();
        }

        public VOBanda Buscar(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Banda ");
            sb.Append("where Id= @id ");
            SqlConnection conn = null;
            SqlDataReader myReader = null;
            VOBanda vob = null;

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
                    vob = new VOBanda();
                    vob.Id = id;
                    vob.Nombre = Convert.ToString(myReader["Nombre"]);
                    vob.GeneroMusical = Convert.ToString(myReader["GeneroMusical"]);
                    vob.AnioCreacion = Convert.ToInt32(myReader["AnioCreacion"]);
                    vob.AnioSeparacion = Convert.ToInt32(myReader["AnioSeparacion"]);
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
            return vob;
        }


        public void Insertar(VOBanda vob)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Banda ");
            sb.Append("values(@Nombre, @GeneroMusical, @AnioCreacion, @AnioSeparacion) ");
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
                    Value = vob.Nombre,
                    SqlDbType = SqlDbType.VarChar
                };
                comando.Parameters.Add(nombreParameter);

                SqlParameter generoMParameter = new SqlParameter()
                {
                    ParameterName = "@GeneroMusical",
                    Value = vob.GeneroMusical,
                    SqlDbType = SqlDbType.VarChar
                };
                comando.Parameters.Add(generoMParameter);

                SqlParameter anioCParameter = new SqlParameter()
                {
                    ParameterName = "@AnioCreacion",
                    Value = vob.AnioCreacion,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(anioCParameter);

                SqlParameter anioSParameter = new SqlParameter()
                {
                    ParameterName = "@AnioSeparacion",
                    Value = vob.AnioSeparacion,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(anioSParameter);

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


        public List<VOBanda> Listar()
        {

            String consulta = "select  *  from Banda";
            SqlConnection conn = null;
            SqlDataReader myReader = null;
            List<VOBanda> listvob = new List<VOBanda>();

            try
            {
                conn = Conexion();
                conn.Open();

                SqlCommand comando = new SqlCommand(consulta, conn);


                myReader = comando.ExecuteReader();
                VOBanda vob;
                while (myReader.Read())
                {
                    vob = new VOBanda();
                    vob.Id = Convert.ToInt32(myReader["Id"]);
                    vob.Nombre = Convert.ToString(myReader["Nombre"]);
                    vob.GeneroMusical = Convert.ToString(myReader["GeneroMusical"]);
                    vob.AnioCreacion = Convert.ToInt32(myReader["AnioCreacion"]);
                    vob.AnioSeparacion = Convert.ToInt32(myReader["AnioSeparacion"]);

                    listvob.Add(vob);
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
            return listvob;
        }

        public List<VOBanda> Listar(string nombre, string generoMusical)
        {

            SqlConnection conn = null;
            SqlDataReader myReader = null;
            List<VOBanda> listVoc = new List<VOBanda>();
            try
            {
                conn = Conexion();
                conn.Open();

                String consulta = ConsultaListar(nombre, generoMusical);

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
                    VOBanda voc = new VOBanda();
                    voc.Id = Convert.ToInt32(myReader["Id"]);
                    voc.Nombre = Convert.ToString(myReader["Nombre"]);
                    voc.GeneroMusical = Convert.ToString(myReader["GeneroMusical"]);
                    voc.AnioCreacion = Convert.ToInt32(myReader["AnioCreacion"]);
                    voc.AnioSeparacion = Convert.ToInt32(myReader["Anioseparacion"]);
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
            sb.Append("delete from Banda ");
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

        public List<VOIntegrante> ListarIntegrantes(int idBanda)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select I.* from Integrante I inner join BandaIntegrante BI ");
            sb.Append("on I.Id = BI.IdIntegrante where BI.IdBanda = @id ");

            SqlConnection conn = null;
            SqlDataReader myReader = null;
            VOIntegrante voi = null;
            List<VOIntegrante> listaintegrantes = new List<VOIntegrante>();
            try
            {
                conn = Conexion();
                conn.Open();

                SqlCommand comando = new SqlCommand(sb.ToString(), conn);
                SqlParameter idParameter = new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = idBanda,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(idParameter);


                myReader = comando.ExecuteReader();
                while (myReader.Read())
                {
                    voi = new VOIntegrante();
                    voi.Id = Convert.ToInt32(myReader["Id"]);
                    voi.Nombre = Convert.ToString(myReader["Nombre"]);
                    voi.Apellido = Convert.ToString(myReader["Apellido"]);
                    voi.FechaNacimiento = Convert.ToDateTime(myReader["FechaNacimiento"]);
                    listaintegrantes.Add(voi);
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
            return listaintegrantes;
        }
        public void AgregarIntegrante(int idBanda, int idIntegrante)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into BandaIntegrante ");
            sb.Append("values(@IdIntegrante, @IdBanda) ");
            SqlConnection conn = null;
            SqlDataReader myReader = null;

            try
            {
                conn = Conexion();
                conn.Open();

                SqlCommand comando = new SqlCommand(sb.ToString(), conn);
                SqlParameter idintegratneParameter = new SqlParameter()
                {
                    ParameterName = "@IdIntegrante",
                    Value = idIntegrante,
                    SqlDbType = SqlDbType.VarChar
                };
                comando.Parameters.Add(idintegratneParameter);

                SqlParameter idbandaParameter = new SqlParameter()
                {
                    ParameterName = "@IdBanda",
                    Value = idBanda,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(idbandaParameter);

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

        public void QuitarIntegrante(int idIntegrante, int idBanda)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from BandaIntegrante ");
            sb.Append("where IdIntegrante = @idIntegrante and IdBanda = @idBanda ");
            SqlConnection conn = null;
            SqlDataReader myReader = null;

            try
            {
                conn = Conexion();
                conn.Open();

                SqlCommand comando = new SqlCommand(sb.ToString(), conn);
                SqlParameter idintegranteParameter = new SqlParameter()
                {
                    ParameterName = "@idIntegrante",
                    Value = idIntegrante,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(idintegranteParameter);

                SqlParameter idbandaParameter = new SqlParameter()
                {
                    ParameterName = "@idBanda",
                    Value = idBanda,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(idbandaParameter);

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