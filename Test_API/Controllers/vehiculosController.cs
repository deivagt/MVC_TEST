using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CLASS_MODELS_TEST;

namespace Test_API.Controllers
{
    [RoutePrefix("api/vehiculos")]
    public class VehiculosController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WEB_API_TUTO"].ConnectionString);

        [HttpGet, Route("{id}")]
        
        public IHttpActionResult Get(string id)
        {
            SqlCommand cmd = new SqlCommand("obtener_Vehiculo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            DataTable dt = new DataTable();
            List<vehiculosModel> vehiculos = new List<vehiculosModel>();
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                foreach (DataRow el in dt.Rows)
                {
                    vehiculosModel temp = new vehiculosModel();
                    temp.id = int.Parse(el["id"].ToString());
                    temp.marca = el["marca"].ToString();
                    temp.color = el["color"].ToString();
                    temp.modelo = int.Parse(el["modelo"].ToString());
                    temp.precio = Decimal.Parse(el["precio"].ToString());
                    temp.fechaRec = (DateTime)el["fechaRec"];
                    temp.idEstado = int.Parse(el["idEstado"].ToString());
                    temp.estado = el["estado"].ToString();


                    vehiculos.Add(temp);
                }
                return Ok(vehiculos);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
            
            
        }
        [HttpGet]
        public IHttpActionResult GetNoID()
        {
            SqlCommand cmd = new SqlCommand("SELECT dbo.vehiculos.*, dbo.estados.estado FROM dbo.vehiculos  JOIN dbo.estados ON dbo.vehiculos.idEstado =  dbo.estados.id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                DataTable dt = new DataTable();
                da.Fill(dt);
                List<vehiculosModel> vehiculos = new List<vehiculosModel>();
                foreach (DataRow el in dt.Rows)
                {
                    vehiculosModel temp = new vehiculosModel();
                    temp.id = int.Parse(el["id"].ToString());
                    temp.marca = el["marca"].ToString();
                    temp.color = el["color"].ToString();
                    temp.modelo = int.Parse(el["modelo"].ToString());
                    temp.precio = Decimal.Parse(el["precio"].ToString());
                    temp.fechaRec = (DateTime)el["fechaRec"];
                    temp.idEstado = int.Parse(el["idEstado"].ToString());
                    temp.estado = el["estado"].ToString();

                    vehiculos.Add(temp);
                }
                return Ok(vehiculos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet, Route("{idEstado}")]
        public IHttpActionResult GetPorEstado(string id)
        {
            SqlCommand cmd = new SqlCommand("obtener_Vehiculo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            DataTable dt = new DataTable();
            List<vehiculosModel> vehiculos = new List<vehiculosModel>();
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                foreach (DataRow el in dt.Rows)
                {
                    vehiculosModel temp = new vehiculosModel();
                    temp.id = int.Parse(el["id"].ToString());
                    temp.marca = el["marca"].ToString();
                    temp.color = el["color"].ToString();
                    temp.modelo = int.Parse(el["modelo"].ToString());
                    temp.precio = Decimal.Parse(el["precio"].ToString());
                    temp.fechaRec = (DateTime)el["fechaRec"];
                    temp.idEstado = int.Parse(el["idEstado"].ToString());
                    temp.estado = el["estado"].ToString();


                    vehiculos.Add(temp);
                }
                return Ok(vehiculos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }



        }

        [HttpPost]
        public IHttpActionResult Post(vehiculosModel vehiculo)
        {
            SqlCommand cmd = new SqlCommand("insertar_Vehiculo", con);
            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                cmd.Parameters.AddWithValue("@marca", vehiculo.marca);
                cmd.Parameters.AddWithValue("@color", vehiculo.color);
                cmd.Parameters.AddWithValue("@modelo", vehiculo.modelo);

                cmd.Parameters.AddWithValue("@precio", vehiculo.precio);
                cmd.Parameters.AddWithValue("@fechaRec", vehiculo.fechaRec);
                cmd.Parameters.AddWithValue("@idEstado", vehiculo.idEstado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut, Route("{id}")]
        public IHttpActionResult Put(string id, vehiculosModel vehiculo)
        {

            SqlCommand cmd = new SqlCommand("actualizar_Vehiculo", con);
            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@marca", vehiculo.marca);
                cmd.Parameters.AddWithValue("@color", vehiculo.color);
                cmd.Parameters.AddWithValue("@modelo", vehiculo.modelo);
                cmd.Parameters.AddWithValue("@precio", vehiculo.precio);
                cmd.Parameters.AddWithValue("@fechaRec", vehiculo.fechaRec);
                cmd.Parameters.AddWithValue("@idEstado", vehiculo.idEstado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }





        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            SqlCommand cmd = new SqlCommand("eliminar_Vehiculo", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
