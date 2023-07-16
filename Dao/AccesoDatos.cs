using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Dao
{
    class AccesoDatos
    {
        String rutaConsultorios =
         "Data Source=localhost\\sqlexpress;Initial Catalog=BDConsultorios_ProgV2;Integrated Security=True";

        public AccesoDatos()
        {
            
        }

        private SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(rutaConsultorios);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        private SqlDataAdapter ObtenerAdaptador(String consultaSql, SqlConnection cn)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, cn);
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }


        public SqlDataReader ObtenerEspecialidades(string Sql)
        {
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(Sql, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();

            return datos;
        }

        public SqlDataReader ObtenerEspecialistas(string Sql)
        {
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(Sql, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();

            return datos;
        }

        public SqlDataReader ObtenerObrasSociales(string Sql)
        {
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(Sql, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();

            return datos;
        }

        public string Contar(string Sql)
        {
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(Sql, Conexion);
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                string cantidad = result.ToString();
                return cantidad;
            }
            else
            {
                return "no";
            }

        }

        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }

        public Boolean existe(String consulta)
        {
            Boolean estado = false;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }
            return estado;
        }

        public string buscarTipoUsuario(string consulta)
        {
            string tipoUsuario = "Null";
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                tipoUsuario = datos["TipoUsuario"].ToString();
            }

            return tipoUsuario;
        }

        public string buscarCodEspecialidad(string consulta)
        {
            string cod = "";
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
               cod = datos["CodEspecialidad_Esp"].ToString();
            }

            return cod;
        }

        public int buscarCodPaciente (string consulta)
        {
            int cod = 0;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                cod = Convert.ToInt32(datos[0].ToString());
            }

            return cod;
        }

        public string buscarMatricula(string consulta)
        {
            string cod = "";
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                cod = datos["Matricula_PxE"].ToString();
            }

            return cod;
        }

        public string buscarConsultorio(string consulta)
        {
            string numConsultorio = "";
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                numConsultorio = datos["NumConsultorio_Con"].ToString();
            }

            return numConsultorio;
        }

        public string ObtenerDatosPacientes(string consulta)
        {
            string nombreApellido = "";
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                nombreApellido = datos["DatosPaciente_Pac"].ToString();
            }

            return nombreApellido;
        }


        public int ObtenerMaximo(String consulta)
        {
            int max = 0;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                max = Convert.ToInt32(datos[0].ToString());
            }
            return max;
        }
    }


}
