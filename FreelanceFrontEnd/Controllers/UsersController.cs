using FreelanceFrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;


namespace FreelanceFrontEnd.Controllers
{
    public class UsersController : Controller
    {
        
        Uri baseAddress = new Uri("https://localhost:7000/api");
        
        private readonly HttpClient _client;

        public UsersController()
        {
            _client = new HttpClient ();
            _client.BaseAddress = baseAddress; 
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<UsersViewModel> usersList = new List<UsersViewModel>();
            //var test = _client.GetAsync(_client.BaseAddress + "/Users/GetAllUsers");
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/Users/GetAllUsers").Result;
            
            if(respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
     
                usersList = JsonConvert.DeserializeObject<List<UsersViewModel>>(data);

            }
            return View(usersList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            List<SkillsListing> skillsList = new List<SkillsListing>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/Users/GetAllSkill").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                skillsList = JsonConvert.DeserializeObject<List<SkillsListing>>(data);

                var viewModel = new UsersViewModel();
                viewModel.SkillSet = skillsList;
                return View(viewModel);
            }
            return View();
            
        }

        [HttpPost]
        public IActionResult CreateUser(UsersViewModel users)
        {
            try
            {
                List<SkillsListing> skillsListing = new List<SkillsListing>();

                foreach (var newuser in users.SkillSet.Where(x=>x.IsChecked == true))
                {
                    SkillsListing singleListing = new SkillsListing();
                    singleListing.skillid = newuser.skillid;
                    singleListing.skillname = newuser.skillname;
                    skillsListing.Add(singleListing);
                }


                var usersnew = new UsersViewModel { Username = users.Username, Email = users.Email, PhoneNumber = users.PhoneNumber, Hobby = users.Hobby , SkillSet = skillsListing
                };

                   
                string data = JsonConvert.SerializeObject(usersnew);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Users/CreateUser", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Users Has Been Created Successfully";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();

            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            try
            {
                List<SkillsListing> skillsList = new List<SkillsListing>();
              
                UsersViewModel usersViewModel = new UsersViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Users/GetUsers/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result.TrimStart('[').TrimEnd(']');
                    usersViewModel = JsonConvert.DeserializeObject<UsersViewModel>(data);
                    

                }
                return View(usersViewModel);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            
        }


        [HttpPost]
        public IActionResult Edit(UsersViewModel usersViewModel)
        {
            try
            {
                string data = JsonConvert.SerializeObject(usersViewModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Users/UpdateUser/", content).Result;

                if (response.IsSuccessStatusCode)
                {

                    TempData["success"] = "User Details Update Successfully";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                UsersViewModel usersViewModel = new UsersViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Users/GetUsers/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result.TrimStart('[').TrimEnd(']');
                    usersViewModel = JsonConvert.DeserializeObject<UsersViewModel>(data);
                }
                return View(usersViewModel);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();

            }
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Users/DeleteUser/" + id).Result;
            try
            {

                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "User Details Deleted Successfully";
                    return Redirect("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return Redirect("Index");
        }
    }
}
