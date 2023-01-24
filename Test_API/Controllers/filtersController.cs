using CLASS_MODELS_TEST;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;

namespace Test_API.Controllers
{
    [RoutePrefix("api/filtersV")]
    public class filtersVController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WEB_API_TUTO"].ConnectionString);

        [HttpGet, Route("{id}")]
        public IHttpActionResult GetPorEstado(string id)
        {
            SqlCommand cmd = new SqlCommand("obtener_vehiculo_estado", con);
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
    }
}
