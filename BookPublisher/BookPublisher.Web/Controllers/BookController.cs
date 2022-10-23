using BookPublisher.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BookPublisher.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly string URL = "https://localhost:49153/books";

        public async Task<IActionResult> Index()
        {
            List<BookViewModel> list = new List<BookViewModel>();
            
            using(var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(URL))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<BookViewModel>>(apiResponse);
                }
            }

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            BookViewModel model = new BookViewModel();

            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync(URL + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<BookViewModel>(apiResponse);
                }
            }

            return View(model);
        }

        public ViewResult Insert() => View();

        [HttpPost]
        public async Task<IActionResult> Insert(BookViewModel model)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(URL, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    JsonConvert.DeserializeObject<BookViewModel>(apiResponse);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            BookViewModel model = new BookViewModel();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(URL + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<BookViewModel>(apiResponse);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BookViewModel model)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync(URL, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    JsonConvert.DeserializeObject<BookViewModel>(apiResponse);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            BookViewModel model = new BookViewModel();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(URL + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<BookViewModel>(apiResponse);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BookViewModel model)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(URL + "/" + model.Id))
                {
                    await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
