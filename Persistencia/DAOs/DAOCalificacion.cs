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
    public class DAOCalificacion
    {
        public SqlConnection Conexion()
        {
            string strConn = @"data source = KATHERINEFE9E8B\MSSQLSERVER02; " + "initial catalog = Spotify; " + "integrated security = true";
            //string strConn = @"data source = NB-MPEREZ\SQLEXPRESS; " + "initial catalog = Spotify; " + "integrated security = true";
            SqlConnection conn = new SqlConnection(strConn);
            return conn;
        }


        public String QueryAlta(TipoCalificacion tipo)
        {
            StringBuilder sb = new StringBuilder();
            if (tipo == TipoCalificacion.BANDA)
            {
               
                sb.Append("insert into UsuarioBanda ");
                sb.Append("values(@IdUsuario, @Id, @Puntaje, @Comentario) ");
            }
            else
            {
                sb.Append("insert into UsuarioCalificacion ");
                sb.Append("values(@IdUsuario, @Id, @Puntaje, @Comentario) ");
            }

            return sb.ToString();
        }

        public String QueryUpdate(TipoCalificacion tipo)
        {
            StringBuilder sb = new StringBuilder();
            if (tipo == TipoCalificacion.BANDA)
            {

                sb.Append("update UsuarioBanda ");
                sb.Append("set Puntaje = @Puntaje, Comentario = @Comentario ");
                sb.Append("where IdUsuario = @IdUsuario and IdBanda = @Id ");
            }
            else
            {
                sb.Append("update UsuarioCancion ");
                sb.Append("set Puntaje = @Puntaje, Comentario = @Comentario ");
                sb.Append("where IdUsuario = @IdUsuario and IdCancion = @Id ");
            }

            return sb.ToString();
        }

        public String QueryBuscar(TipoCalificacion tipo)
        {
            StringBuilder sb = new StringBuilder();
            if (tipo == TipoCalificacion.BANDA)
            {

                sb.Append("select * from UsuarioBanda ");
                sb.Append("where IdUsuario = @IdUsuario and IdBanda = @Id ");
            }
            else
            {

                sb.Append("select * from UsuarioCancion ");
                sb.Append("where IdUsuario = @IdUsuario and IdCancion = @Id ");
            }

            return sb.ToString();
        }




        public void Alta(VOCalificacion voc)
        {
            
            SqlConnection conn = null;
            SqlDataReader myReader = null;

            try
            {
                conn = Conexion();
                conn.Open();

                String query = QueryAlta(voc.Tipo);

                SqlCommand comando = new SqlCommand(query, conn);
                SqlParameter idUsuarioParameter = new SqlParameter()
                {
                    ParameterName = "@IdUsuario",
                    Value = voc.IdUsuario,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(idUsuarioParameter);

                SqlParameter idParameter = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = voc.Id,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(idParameter);

                SqlParameter puntajeParameter = new SqlParameter()
                {
                    ParameterName = "@Puntaje",
                    Value = voc.Puntaje,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(puntajeParameter);

                SqlParameter comentarioParameter = new SqlParameter()
                {
                    ParameterName = "@Comentario",
                    Value = voc.Comentario,
                    SqlDbType = SqlDbType.VarChar
                };
                comando.Parameters.Add(comentarioParameter);

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

        public void Modificar(VOCalificacion voc)
        {

            SqlConnection conn = null;
            SqlDataReader myReader = null;

            try
            {
                conn = Conexion();
                conn.Open();

                String query = QueryUpdate(voc.Tipo);

                SqlCommand comando = new SqlCommand(query, conn);
                SqlParameter idUsuarioParameter = new SqlParameter()
                {
                    ParameterName = "@IdUsuario",
                    Value = voc.IdUsuario,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(idUsuarioParameter);

                SqlParameter idParameter = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = voc.Id,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(idParameter);

                SqlParameter puntajeParameter = new SqlParameter()
                {
                    ParameterName = "@Puntaje",
                    Value = voc.Puntaje,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(puntajeParameter);

                SqlParameter comentarioParameter = new SqlParameter()
                {
                    ParameterName = "@Comentario",
                    Value = voc.Comentario,
                    SqlDbType = SqlDbType.VarChar
                };
                comando.Parameters.Add(comentarioParameter);

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


        public VOCalificacion Buscar(int idUsuario, int id, TipoCalificacion tipo)
        {

            SqlConnection conn = null;
            SqlDataReader myReader = null;
            VOCalificacion voc=new VOCalificacion(); 

            try
            {
                conn = Conexion();
                conn.Open();

                String query = QueryBuscar(tipo);

                SqlCommand comando = new SqlCommand(query, conn);
                SqlParameter idUsuarioParameter = new SqlParameter()
                {
                    ParameterName = "@IdUsuario",
                    Value = idUsuario,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(idUsuarioParameter);

                SqlParameter idParameter = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id,
                    SqlDbType = SqlDbType.Int
                };
                comando.Parameters.Add(idParameter);
                myReader = comando.ExecuteReader();
                if (myReader.Read())
                {
                    voc.Id = id;
                    voc.IdUsuario = idUsuario;
                    voc.Tipo = tipo;
                    voc.Puntaje = Convert.ToInt32(myReader["Puntaje"]);
                    voc.Comentario = Convert.ToString(myReader["Comentario"]);
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
    }
}
