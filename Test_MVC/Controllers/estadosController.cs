using CLASS_MODELS_TEST;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Test_MVC.ViewModels;
using System.Threading.Tasks;
using System.Data;

namespace Test_MVC.Controllers
{
    public class estadosController : Controller
    {
        string baseAddress = "https://localhost:44365/api/";
       
        public async Task<ActionResult> Index()
        {
           DataTable estados = new DataTable();
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                
                HttpResponseMessage getData = await client.GetAsync("estados");

                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    estados = JsonConvert.DeserializeObject<DataTable>(results);
                }
                else
                {
                    return HttpNotFound();
                }

            }
            
            return View(estados);
        }
    }
}