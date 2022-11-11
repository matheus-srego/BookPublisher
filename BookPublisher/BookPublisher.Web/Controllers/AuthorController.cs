using BookPublisher.Web.DTOs;
using BookPublisher.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace BookPublisher.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly string URL = "https://localhost:49153/authors";

        public async Task<IActionResult> Index()
        {
            List<AuthorViewDTO> list = new List<AuthorViewDTO>();

            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync(URL))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<AuthorViewDTO>>(apiResponse);
                }
            }

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            AuthorViewDTO model = new AuthorViewDTO();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(URL + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<AuthorViewDTO>(apiResponse);
                }
            }

            return View(model);
        }

        public ViewResult Insert() => View();

        [HttpPost]
        public async Task<IActionResult> Insert(AuthorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AuthorViewModel author = new AuthorViewModel();
            using(var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using(var response = await httpClient.PostAsync(URL, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    author = JsonConvert.DeserializeObject<AuthorViewModel>(apiResponse);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            AuthorViewModel author = new AuthorViewModel();

            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync(URL + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    author = JsonConvert.DeserializeObject<AuthorViewModel>(apiResponse);
                }
            }

            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AuthorViewModel model)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync(URL, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Sucesso!";
                    JsonConvert.DeserializeObject<AuthorViewModel>(apiResponse);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            AuthorViewModel author = new AuthorViewModel();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(URL + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    author = JsonConvert.DeserializeObject<AuthorViewModel>(apiResponse);
                }
            }

            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AuthorViewModel model)
        {
            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.DeleteAsync(URL + "/" + model.Id))
                {
                    await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
