using CLASS_MODELS_TEST;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Test_API.Controllers
{
    [RoutePrefix("api/estados")]
    public class estadosController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WEB_API_TUTO"].ConnectionString);

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(string id)
        {
            SqlCommand cmd = new SqlCommand("obtener_estado", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            DataTable dt = new DataTable();

            List<estadoModel> estados = new List<estadoModel>();
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                foreach (DataRow el in dt.Rows)
                {
                    estadoModel temp = new estadoModel();
                    temp.id = int.Parse(el["id"].ToString());
                    temp.estado=el["estado"].ToString();
                    estados.Add(temp);
                }
                return Ok(estados);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }



        }
        [HttpGet]
        public IHttpActionResult GetNoID()
        {
            SqlCommand cmd = new SqlCommand("Select * from estados", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);


            List<estadoModel> estados = new List<estadoModel>();
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow el in dt.Rows)
                {
                    estadoModel temp = new estadoModel();
                    temp.id = int.Parse(el["id"].ToString());
                    temp.estado = el["estado"].ToString();
                    estados.Add(temp);
                }
                return Ok(estados);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public IHttpActionResult Post(estadoModel estado)
        {
            SqlCommand cmd = new SqlCommand("insertar_estado", con);
            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                cmd.Parameters.AddWithValue("@estado", estado.estado);

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
        public IHttpActionResult Put(string id, estadoModel estado)
        {

            SqlCommand cmd = new SqlCommand("actualizar_estado", con);
            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@estado", estado.estado);

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
            SqlCommand cmd = new SqlCommand("eliminar_estado", con);
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
