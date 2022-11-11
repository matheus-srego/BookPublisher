using BookPublisher.Web.DTOs;
using BookPublisher.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace BookPublisher.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly string URL = "https://localhost:49153/books";
        private readonly string URL_AUTHOR = "https://localhost:49153/authors";
        List<int> AuthorsId;

        public BookController()
        {
            AuthorsId = new List<int>();
        }

        public IActionResult List()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            List<BookViewDTO> list = new List<BookViewDTO>();
            
            using(var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(URL))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<BookViewDTO>>(apiResponse);
                }
            }

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            BookViewDTO model = new BookViewDTO();

            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync(URL + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<BookViewDTO>(apiResponse);
                    /*foreach(var bookAuthor in model.BookAuthor)
                    {
                        TempData["BookAuthor"] = bookAuthor;
                    }*/
                }
            }

            return View(model);
        }

        public async Task<IActionResult> ListAuthors()
        {
            List<AuthorViewModel> list = new List<AuthorViewModel>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(URL_AUTHOR))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<AuthorViewModel>>(apiResponse);
                }
            }

            return View(list);
        }

        public async Task<IActionResult> Insert()
        {
            List<AuthorViewModel> listAuthor = new List<AuthorViewModel>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(URL_AUTHOR))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listAuthor = JsonConvert.DeserializeObject<List<AuthorViewModel>>(apiResponse);
                }
            }

            var list = new List<SelectListItem>();

            foreach(var autor in listAuthor)
            {
                var selectListItem = new SelectListItem
                {
                    Value = ((int)autor.Id).ToString(),
                    Text = autor.Name + " " + autor.LastName
                };
                list.Add(selectListItem);
            }
            ViewBag.Authors = list;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(BookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

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
            BookViewDTO model = new BookViewDTO();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(URL + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<BookViewDTO>(apiResponse);
                }
            }

            List<AuthorViewModel> listAuthor = new List<AuthorViewModel>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(URL_AUTHOR))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listAuthor = JsonConvert.DeserializeObject<List<AuthorViewModel>>(apiResponse);
                }
            }

            var list = new List<SelectListItem>();

            foreach (var autor in listAuthor)
            {
                var selectListItem = new SelectListItem
                {
                    Value = ((int)autor.Id).ToString(),
                    Text = autor.Name + " " + autor.LastName
                };
                list.Add(selectListItem);
            }
            ViewBag.Authors = list;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BookViewModel model)
        {
            if (model.AuthorsId.Count == 0)
            {
                BookViewDTO dto = new BookViewDTO();

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(URL + "/" + model.Id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        dto = JsonConvert.DeserializeObject<BookViewDTO>(apiResponse);
                    }
                }

                foreach(var author in dto.BookAuthor)
                {
                    model.AuthorsId.Add(author.Author.Id);
                }
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

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
