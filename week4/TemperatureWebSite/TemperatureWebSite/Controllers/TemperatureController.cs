using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TemperatureWebSite.Models;

namespace TemperatureWebSite.Controllers
{
    public class TemperatureController : Controller
    {
        public HttpClient Client { get; set; }

        // dependency injection
        public TemperatureController(HttpClient client)
        {
            Client = client;
        }

        // GET: Temperature
        public async Task<ActionResult> Index()
        {
            // send "GET api/Temperature" to service, get headers of response
            HttpResponseMessage response = await Client.GetAsync("https://localhost:44365/api/temperature");

            // (if status code is not 200-299 (for success))
            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction("Error", "Home");
            }

            // get the whole response body (second await)
            var responseBody = await response.Content.ReadAsStringAsync();

            // this is a string, so it must be deserialized into a C# object.
            // we could use DataContractSerializer, .NET built-in, but it's more awkward
            // than the third-party Json.NET aka Newtonsoft JSON.
            List<TemperatureRecord> temperatures = JsonConvert.DeserializeObject<List<TemperatureRecord>>(responseBody);

            return View(temperatures);
        }

        // GET: Temperature/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Temperature/Create
        public ActionResult Create()
        {
            return View(new TemperatureRecord());
        }

        // POST: Temperature/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TemperatureRecord temperatureRecord)
        {
            try
            {
                //var stringContent = new StringContent(jObject.ToString());
                //var response = await httpClient.PostAsync("http://www.sample.com/write", stringContent);

                string message = JsonConvert.SerializeObject(temperatureRecord);
                HttpContent hc = new StringContent(message, Encoding.UTF8,"application/json");
                

                HttpResponseMessage response = await Client.PostAsync("https://localhost:44365/api/temperature", hc);
                   // await Client.GetAsync("https://localhost:44365/api/temperature");

                // (if status code is not 200-299 (for success))
                if (!response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Error", "Home");
                }

                // get the whole response body (second await)
                //var responseBody = await response.Content.ReadAsStringAsync();


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Temperature/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage response = await Client.GetAsync("https://localhost:44365/api/temperature");

            // (if status code is not 200-299 (for success))
            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction("Error", "Home");
            }

            // get the whole response body (second await)
            var responseBody = await response.Content.ReadAsStringAsync();

            // this is a string, so it must be deserialized into a C# object.
            // we could use DataContractSerializer, .NET built-in, but it's more awkward
            // than the third-party Json.NET aka Newtonsoft JSON.
            List<TemperatureRecord> temperatures = JsonConvert.DeserializeObject<List<TemperatureRecord>>(responseBody);
            return View(temperatures.First(a=> a.Id == id));
        }

        // POST: Temperature/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TemperatureRecord temperatureRecord)
        {
            try
            {
                string message = JsonConvert.SerializeObject(temperatureRecord);
                HttpContent hc = new StringContent(message, Encoding.UTF8, "application/json");


                HttpResponseMessage response = await Client.PutAsync("https://localhost:44365/api/temperature/" +  temperatureRecord.Id, hc);
                // await Client.GetAsync("https://localhost:44365/api/temperature");

                // (if status code is not 200-299 (for success))
                if (!response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Error", "Home");
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Temperature/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage response = await Client.GetAsync("https://localhost:44365/api/temperature");

            // (if status code is not 200-299 (for success))
            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction("Error", "Home");
            }

            // get the whole response body (second await)
            var responseBody = await response.Content.ReadAsStringAsync();

            // this is a string, so it must be deserialized into a C# object.
            // we could use DataContractSerializer, .NET built-in, but it's more awkward
            // than the third-party Json.NET aka Newtonsoft JSON.
            List<TemperatureRecord> temperatures = JsonConvert.DeserializeObject<List<TemperatureRecord>>(responseBody);
            var chosen = temperatures.First(a => a.Id == id);
            return View(chosen);
        }

        // POST: Temperature/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {

                //string message = JsonConvert.SerializeObject(temperatureRecord);
                //HttpContent hc = new StringContent(message, Encoding.UTF8, "application/json");

                await Client.DeleteAsync("https://localhost:44365/api/temperature/" + id);
                //HttpResponseMessage response = await Client.PostAsync("https://localhost:44365/api/temperature", hc);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}