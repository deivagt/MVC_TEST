using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Text;
using CLASS_MODELS_TEST;
using Test_MVC.ViewModels;

namespace Test_MVC.Controllers
{
    public class vehiculosController : Controller
    {
        string baseAddress = "https://localhost:44365/api/";

        [HttpPost]
        public async Task<ActionResult> Index(IndexViewModel modelo)
        {
            List<vehiculosModel> vehiculos = new List<vehiculosModel>();
            LinkedList<estadoModel> estados = new LinkedList<estadoModel>();
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData;
                //get vehiculos
                if (modelo.estadoSel == -1)
                {
                    getData = await client.GetAsync("vehiculos");
                }
                else {
                    getData = await client.GetAsync("filtersV/" + modelo.estadoSel);
                }

                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    vehiculos = JsonConvert.DeserializeObject<List<vehiculosModel>>(results);
                }
                else
                {
                    return HttpNotFound();
                }

                //get estados
                getData = await client.GetAsync("estados");
                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    estados = JsonConvert.DeserializeObject<LinkedList<estadoModel>>(results);
                }
                else
                {
                    return HttpNotFound();
                }

            }
            estados.AddFirst(new estadoModel { id = -1, estado = "Todos" });

            IndexViewModel nuevoModelo = new IndexViewModel
            {
                estadoSel = modelo.estadoSel, //Todos
                vehiculos = vehiculos,
                estados = estados
            };
            return View(nuevoModelo);
        }
            // GET: vehiculos
            public async Task<ActionResult> Index()
        {
            List < vehiculosModel> vehiculos = new List<vehiculosModel>();
            LinkedList < estadoModel> estados = new LinkedList<estadoModel>();
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //get vehiculos
                HttpResponseMessage getData = await client.GetAsync("vehiculos");

                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    vehiculos = JsonConvert.DeserializeObject<List<vehiculosModel>>(results);
                }
                else
                {
                    return HttpNotFound();
                }

                //get estados
                getData = await client.GetAsync("estados");
                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    estados = JsonConvert.DeserializeObject<LinkedList<estadoModel>>(results);
                }
                else
                {
                    return HttpNotFound();
                }

            }
            estados.AddFirst(new estadoModel { id = -1, estado = "Todos" });
            IndexViewModel modelo = new IndexViewModel
            {
                estadoSel = -1, //Todos
                vehiculos = vehiculos,
                estados = estados
            };
            return View(modelo);
        }

        
        public async Task<ActionResult> eliminarV(string id)
        {
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage deleteData = await client.DeleteAsync("vehiculos/" + id);

                if (deleteData.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound();
                }


            }

        }

        [HttpGet]
        public async Task<ActionResult> editarV(string id)
        {
            List<vehiculosModel> vehiculo = new List<vehiculosModel>();
            List<estadoModel> estados = new List<estadoModel>();
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //get vehiculos
                HttpResponseMessage getData = await client.GetAsync("vehiculos/" + id);

                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    vehiculo = JsonConvert.DeserializeObject<List<vehiculosModel>>(results);
                }
                else
                {
                    return HttpNotFound();
                }

                //get estados
                 getData = await client.GetAsync("estados");
                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    estados = JsonConvert.DeserializeObject<List<estadoModel>>(results);
                }
                else
                {
                    return HttpNotFound();
                }
            }

            EditarVehiculoViewModel modelo = new EditarVehiculoViewModel
            {
                vehiculo = vehiculo[0],
                estados = estados
            };

            return View(modelo);
        }

        [HttpPost]
        public async Task<ActionResult> editarV(string id, EditarVehiculoViewModel v)
        {
           

            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string ruta = "vehiculos/" + id;
                HttpResponseMessage putData = await client.PutAsync(ruta, new StringContent(JsonConvert.SerializeObject(v.vehiculo), Encoding.UTF8, "application/json"));

                if (putData.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound();
                }



            }

        }

        [HttpGet]
        public async Task<ActionResult> crearV(string id)
        {
            List<vehiculosModel> vehiculo = new List<vehiculosModel>();
            List<estadoModel> estados = new List<estadoModel>();
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                //get estados
                HttpResponseMessage getData = await client.GetAsync("estados");
                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    estados = JsonConvert.DeserializeObject<List<estadoModel>>(results);
                }
                else
                {
                    return HttpNotFound();
                }
            }

            EditarVehiculoViewModel modelo = new EditarVehiculoViewModel
            {
                vehiculo = new vehiculosModel()
                {
                    fechaRec = new DateTime()
                },
                estados = estados
            };

            return View(modelo);
        }

        [HttpPost]
        public async Task<ActionResult> crearV(string id, EditarVehiculoViewModel v)
        {


            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string ruta = "vehiculos/" + id;
                HttpResponseMessage putData = await client.PostAsync(ruta, new StringContent(JsonConvert.SerializeObject(v.vehiculo), Encoding.UTF8, "application/json"));

                if (putData.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound();
                }



            }

        }
    }
}