using Camiones.Datos.Interfaz;
using Camiones.Entidades;
using Camiones.Presentacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Camiones.Datos.Implementacion
{
    internal class CamionDao : ICamionDao
    {
        public bool CrearCamion(Camion oCamion)
        {

            bool resultado = true;

            // Creamos la transaccion
            SqlTransaction t = null;
            SqlConnection conexion = HelperDao.ObtenerInstancia().ObtenerConexion();

            try
            {
                conexion.Open();

                SqlCommand comandoMaestro = new SqlCommand();
                // Ponemos a la conexion bajo transaccion
                t = conexion.BeginTransaction(); // Aca la estariamos iniciando
                comandoMaestro.Connection = conexion;

                comandoMaestro.Transaction = t;
                comandoMaestro.CommandType = CommandType.StoredProcedure;
                comandoMaestro.CommandText = "SP_INSERTAR_CAMION";
                // Agregamos los parametros de entrada
                comandoMaestro.Parameters.AddWithValue("@patente", oCamion.Patente);
                comandoMaestro.Parameters.AddWithValue("@estadoCamion", oCamion.EstadoCamion.Estado);
                comandoMaestro.Parameters.AddWithValue("@pesoMax", oCamion.PesoMaximo);

                SqlParameter param = new SqlParameter();
                param.Direction = ParameterDirection.Output;
                param.ParameterName = "@proxCamion";
                param.DbType = DbType.Int32;
                comandoMaestro.Parameters.Add(param);

                comandoMaestro.ExecuteNonQuery();

                t.Commit(); // Confirmamos la transaccion
            }
            catch
            {
                if (t != null)
                {
                    t.Rollback(); // "Desconfirmamos" la transaccion
                }

                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open) // Si la conexion no esta vacia, y en este momento esta abierta
                {
                    conexion.Close(); // Cerramos la conexion

                }
            }
            return resultado;
        }

        public bool ActualizarCamion(Camion oCamion)
        {

            bool resultado = true;

            // Creamos la transaccion
            SqlTransaction t = null;
            SqlConnection conexion = HelperDao.ObtenerInstancia().ObtenerConexion();

            try
            {
                conexion.Open();

                SqlCommand comandoMaestro = new SqlCommand();
                // Ponemos a la conexion bajo transaccion
                t = conexion.BeginTransaction(); // Aca la estariamos iniciando
                comandoMaestro.Connection = conexion;

                comandoMaestro.Transaction = t;
                comandoMaestro.CommandType = CommandType.StoredProcedure;
                comandoMaestro.CommandText = "SP_ACTUALIZAR_CAMION";
                // Agregamos los parametros de entrada
                comandoMaestro.Parameters.AddWithValue("@id", oCamion.Id);
                comandoMaestro.Parameters.AddWithValue("@patente", oCamion.Patente);
                comandoMaestro.Parameters.AddWithValue("@estado", oCamion.EstadoCamion.Estado);
                comandoMaestro.Parameters.AddWithValue("@peso", oCamion.PesoMaximo);

                comandoMaestro.ExecuteNonQuery();

                SqlCommand comandoDetalle = new SqlCommand();
                comandoDetalle.Connection = conexion;
                comandoDetalle.Transaction = t;
                comandoDetalle.CommandType = CommandType.StoredProcedure;
                comandoDetalle.CommandText = "SP_ELIMINAR_CARGAS";
                comandoDetalle.Parameters.AddWithValue("@idCamion", oCamion.Id);

                comandoDetalle.ExecuteNonQuery();

                t.Commit(); // Confirmamos la transaccion
            }
            catch
            {
                if (t != null)
                {
                    t.Rollback(); // "Desconfirmamos" la transaccion
                }

                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open) // Si la conexion no esta vacia, y en este momento esta abierta
                {
                    conexion.Close(); // Cerramos la conexion

                }
            }
            return resultado;
        }

        public bool AgregarCarga(Carga oCarga)
        {

            bool resultado = true;

            // Creamos la transaccion
            SqlTransaction t = null;
            SqlConnection conexion = HelperDao.ObtenerInstancia().ObtenerConexion();

            try
            {
                conexion.Open();

                SqlCommand comandoMaestro = new SqlCommand();
                // Ponemos a la conexion bajo transaccion
                t = conexion.BeginTransaction(); // Aca la estariamos iniciando
                comandoMaestro.Connection = conexion;

                comandoMaestro.Transaction = t;
                comandoMaestro.CommandType = CommandType.StoredProcedure;
                comandoMaestro.CommandText = "SP_INSERTAR_CARGA";
                // Agregamos los parametros de entrada
                comandoMaestro.Parameters.AddWithValue("@peso", oCarga.Peso);
                comandoMaestro.Parameters.AddWithValue("@tipo", oCarga.TipoCarga.Id);
                comandoMaestro.Parameters.AddWithValue("@id_camion", oCarga.IdCamion);

                comandoMaestro.ExecuteNonQuery();

                t.Commit(); // Confirmamos la transaccion
            }
            catch
            {
                if (t != null)
                {
                    t.Rollback(); // "Desconfirmamos" la transaccion
                }

                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open) // Si la conexion no esta vacia, y en este momento esta abierta
                {
                    conexion.Close(); // Cerramos la conexion

                }
            }
            return resultado;
        }

        public bool EliminarCarga(int id)
        {

            bool resultado = true;

            // Creamos la transaccion
            SqlTransaction t = null;
            SqlConnection conexion = HelperDao.ObtenerInstancia().ObtenerConexion();

            try
            {
                conexion.Open();

                SqlCommand comandoMaestro = new SqlCommand();
                // Ponemos a la conexion bajo transaccion
                t = conexion.BeginTransaction(); // Aca la estariamos iniciando
                comandoMaestro.Connection = conexion;

                comandoMaestro.Transaction = t;
                comandoMaestro.CommandType = CommandType.StoredProcedure;
                comandoMaestro.CommandText = "SP_ELIMINAR_CARGA";
                // Agregamos los parametros de entrada
                comandoMaestro.Parameters.AddWithValue("@idCarga", id);

                comandoMaestro.ExecuteNonQuery();

                t.Commit(); // Confirmamos la transaccion
            }
            catch
            {
                if (t != null)
                {
                    t.Rollback(); // "Desconfirmamos" la transaccion
                }

                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open) // Si la conexion no esta vacia, y en este momento esta abierta
                {
                    conexion.Close(); // Cerramos la conexion

                }
            }
            return resultado;
        }

        public int obtenerProximoCamion()
        {
            return HelperDao.ObtenerInstancia().ConsultarOut("SP_PROXIMO_CAMION", "@next");
        }

        public List<Camion> obtenerCamiones()
        {
            List<Camion> lCamiones = new List<Camion>();
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_CAMIONES");
            //mapear un registro de la tabla a un objeto del modelo de dominio
            foreach (DataRow row in tabla.Rows)
            {
                int id = Convert.ToInt32(row[0]);
                string patente = row[1].ToString();
                int pesomax = Convert.ToInt32(row[3]);
                EstadoCamion estado = new EstadoCamion(0, 0); ;
                if (row[2].ToString() == "De Viaje")
                {
                    estado.Estado = 2;
                }
                if (row[2].ToString() == "En Reparacion")
                {
                    estado.Estado = 1;
                }
                Camion p = new Camion(id, patente, pesomax, estado);
                lCamiones.Add(p);
            }
            return lCamiones;
        }

        public List<EstadoCamion> obtenerEstados()
        {
            List<EstadoCamion> lEstados = new List<EstadoCamion>();
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_ESTADOS");
            //mapear un registro de la tabla a un objeto del modelo de dominio
            foreach (DataRow fila in tabla.Rows)
            {
                int numero = int.Parse(fila["id_estado_camion"].ToString());
                string nombre = fila["estado"].ToString();
                EstadoCamion p = new EstadoCamion(nombre, numero);
                lEstados.Add(p);
            }
            return lEstados;
        }

        public List<Camion> obtenerCamionesFiltrados(List<Parametro> lParam)
        {
            List<Camion> lCamiones = new List<Camion>();
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTA_CAMIONES", lParam);
            //mapear un registro de la tabla a un objeto del modelo de dominio
            foreach (DataRow row in tabla.Rows)
            {
                int id = Convert.ToInt32(row[0]);
                string patente = row[1].ToString();
                int pesomax = Convert.ToInt32(row[3]);
                int pesoocu = Convert.ToInt32(row[4]);  
                EstadoCamion estado = new EstadoCamion(0, 0); ;
                estado.Nombre = "Disponible";
                if (row[2].ToString() == "De Viaje")
                {
                    estado.Estado = 2;
                    estado.Id = 2;
                    estado.Nombre = "De Viaje";
                }
                if (row[2].ToString() == "En Reparacion")
                {
                    estado.Estado = 1;
                    estado.Id = 1;
                    estado.Nombre = "En Reparacion";
                }
                Camion p = new Camion(id, patente, pesomax, pesoocu, estado);
                lCamiones.Add(p);
            }
            return lCamiones;
        }

        public List<Carga> obtenerCargas(List<Parametro> lParam)
        {
            List<Carga> lCargas = new List<Carga>();
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_CARGAS", lParam);
            //mapear un registro de la tabla a un objeto del modelo de dominio
            foreach (DataRow row in tabla.Rows)
            {
                int id = Convert.ToInt32(row[0]);
                int peso = Convert.ToInt32(row[1]);
                string nombre = row[2].ToString();
                TipoCarga tipo = new TipoCarga(nombre);
                Carga c = new Carga(id, peso, tipo);
                lCargas.Add(c);
            }
            return lCargas;
        }

        public List<TipoCarga> obtenerTiposCargas()
        {
            List<TipoCarga> lTCargas = new List<TipoCarga>();
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_TIPOS_CARGA");
            //mapear un registro de la tabla a un objeto del modelo de dominio
            foreach (DataRow row in tabla.Rows)
            {
                int id = Convert.ToInt32(row[0]);
                string nombre = row[1].ToString();
                TipoCarga tipo = new TipoCarga(nombre, id);
                lTCargas.Add(tipo);
            }
            return lTCargas;
        }
    }
}
