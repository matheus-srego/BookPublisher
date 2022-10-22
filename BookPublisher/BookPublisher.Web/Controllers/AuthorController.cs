        public async Task<IActionResult> Index()
        {
            List<AuthorModel> list = new List<AuthorModel>();

            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync(URL))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<AuthorModel>>(apiResponse);
                }
            }

            return View(list);
        }
