using BookPublisher.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace BookPublisher.Web.Controllers
{
    public class AuthController : Controller
    {
        private HttpClient _httpClient;
        public AuthController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:49157/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();

            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(mediaType);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if(ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("user", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("login");
                }
                else
                {
                    return NotFound();
                }
            }
            return View(model);
        }
    }
}
