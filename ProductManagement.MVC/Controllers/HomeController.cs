using Microsoft.AspNetCore.Mvc;
using ProductManagement.MVC.Models;
using System.Diagnostics;
using System.Reflection;

namespace ProductManagement.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly HttpClient _http;
        public HomeController(ILogger<HomeController> logger, HttpClient http)
        {
            _logger = logger;
            _http = http;
        }

        [ActionName("Index")]
        public async Task<IActionResult> IndexAsync()
        {
            var respone = await _http.GetAsync("https://localhost:7297/api/Product");

            if(respone.IsSuccessStatusCode)
            {
                var products = await respone.Content.ReadFromJsonAsync<GetProductResponseModel>();

                return View(products.products);
            }
            else
            {
                ModelState.AddModelError("", "Failed to load products");
            }
            return View("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]int id)
        {

            var content = JsonContent.Create(new { ProductId = id });
            var response = await _http.PostAsync($"https://localhost:7297/api/Product/Delete", content);
            if (response.IsSuccessStatusCode)
            {
                TempData["IsSuccess"] = true;
                TempData["Message"] = "Delete successful";

                return RedirectToAction("Index");
            }

            return StatusCode((int)response.StatusCode, "Failed to delete.");
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductRequestModel reqModel)
        {
            var content = JsonContent.Create(reqModel);
            var response = await _http.PostAsync("https://localhost:7297/api/Product/Update", content);

            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }

            return StatusCode((int)response.StatusCode, "Failed to update.");
        }

        [HttpPost]
        [ActionName("Create")]

        public async Task<IActionResult> CreateAsync([FromBody] AddProductRequestModel reqModel)
        {
            var content = JsonContent.Create(reqModel);
            var response = await _http.PostAsync("https://localhost:7297/api/Product/Create", content);

            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }

            return StatusCode((int)response.StatusCode, "Failed to Create.");
        }

    }
}
