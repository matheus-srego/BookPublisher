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
        public ViewResult Insert() => View();

        [HttpPost]
        public async Task<IActionResult> Insert(AuthorModel model)
        {
            AuthorModel author = new AuthorModel();
            using(var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using(var response = await httpClient.PostAsync(URL, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    author = JsonConvert.DeserializeObject<AuthorModel>(apiResponse);
                }

                return View(author);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            AuthorModel author = new AuthorModel();

            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync(URL + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    author = JsonConvert.DeserializeObject<AuthorModel>(apiResponse);
                }
            }

            return View(author);
        }
