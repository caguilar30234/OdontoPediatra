using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class UserHelper
    {
        public List<UserViewModel> GetAll()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/user/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<UserViewModel> users = JsonConvert.DeserializeObject<List<UserViewModel>>(content);
            return users;
        }

        public UserViewModel Details(string id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/user/" + id);
            response.EnsureSuccessStatusCode();
            UserViewModel userViewModel = response.Content.ReadAsAsync<UserViewModel>().Result;
            return userViewModel;
        }
    }
}
