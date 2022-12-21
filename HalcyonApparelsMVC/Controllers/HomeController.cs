using HalcyonApparelsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HalcyonApparelsMVC.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> AccessoryView()
    {
        HttpClientHandler clienthandler = new HttpClientHandler();
        clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslpolicyerrors) => { return true; };

        HttpClient client = new HttpClient(clienthandler);
        client.BaseAddress = new Uri("https://localhost:7200");
        List<AccessoryDetailsMVC>? acclist = new List<AccessoryDetailsMVC>();

        HttpResponseMessage res = client.GetAsync("api/Accessory/Get").Result;
        if (res.IsSuccessStatusCode)
        {
            var result = res.Content.ReadAsStringAsync().Result;
            acclist = JsonConvert.DeserializeObject<List<AccessoryDetailsMVC>>(result);
        }
        return View(acclist);

    }
    //[HttpPost]
    public IActionResult Post(AccessoryDetailsMVC accsrydet)
    {
        accsrydet.ImageUrl = "file";
        HttpClientHandler clienthandler = new HttpClientHandler();
        clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslpolicyerrors) => { return true; };


        HttpClient client = new HttpClient(clienthandler);
        client.BaseAddress = new Uri("https://localhost:7200");
        var postTask = client.PostAsJsonAsync<AccessoryDetailsMVC>("api/Accessory/Post/", accsrydet);
        postTask.Wait();
        var Result = postTask.Result;
        if (Result.IsSuccessStatusCode)
        {
                TempData["AlertMessage"] = " Accessory Added ";
                return RedirectToAction("AccessoryView");
        }
        return View();
    }

    public async Task<IActionResult> Delete(int id)
    {
            
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7200");
        await client.DeleteAsync($"api/Accessory/Delete/{id}");
        
        TempData["AlertMessage"] = " Accessory Deleted ";
        return RedirectToAction("AccessoryView");


        }

    [HttpPost]
    public async Task<IActionResult> Edit(TempData temp)
    {
        temp.AccessoryId = Convert.ToInt32(TempData["id"]);
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7200");
        var postTask = client.PostAsJsonAsync<TempData>("api/Accessory/Edit", temp);
        postTask.Wait();
        var Result = postTask.Result;
        if (Result.IsSuccessStatusCode)
        {
                TempData["AlertMessage"] = " Accessory Added";
                return RedirectToAction("AccessoryView");
        }
        return View();

   
        }

        public async Task<IActionResult> Edit(int id)
        {
            TempData["id"] = id;
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7200");

            TempData accssry = new TempData();
            HttpResponseMessage res = await client.GetAsync($"api/Accessory/Get/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                accssry = JsonConvert.DeserializeObject<TempData>(result);
            }


            return View(accssry);
        }

        public async Task<IActionResult> Details(int id)
        {
            
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7200");
                AccessoryDetailsMVC accss = new AccessoryDetailsMVC();

                HttpResponseMessage res = await client.GetAsync($"api/Accessory/Get/{id}");
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    accss = JsonConvert.DeserializeObject<AccessoryDetailsMVC>(result);
                }
                return View(accss);
          


        }

    }

    
}