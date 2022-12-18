using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class ScheduleHelper
    {
        public List<ScheduleViewModel> GetAll(string token)
        {
            ServiceRepository Repository = new ServiceRepository(token);
            HttpResponseMessage responseMessage = Repository.GetResponse("api/schedule");
            responseMessage.EnsureSuccessStatusCode();
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            List<ScheduleViewModel> schedules = JsonConvert.DeserializeObject<List<ScheduleViewModel>>(content);

            return schedules;
        }

        public ScheduleViewModel Details(int id, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.GetResponse("api/schedule/" + id.ToString());
            response.EnsureSuccessStatusCode();
            ScheduleViewModel ScheduleViewModel = response.Content.ReadAsAsync<ScheduleViewModel>().Result;
            return ScheduleViewModel;
        }

        public ScheduleViewModel Create(ScheduleViewModel Schedule, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.PostResponse("api/Schedule/", Schedule);
            response.EnsureSuccessStatusCode();
            ScheduleViewModel ScheduleViewModel =
            response.Content.ReadAsAsync<ScheduleViewModel>().Result;
            return ScheduleViewModel;
        }

        public ScheduleViewModel Edit(int id, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.GetResponse("api/advice/" + id.ToString());
            response.EnsureSuccessStatusCode();
            ScheduleViewModel ScheduleViewModel = response.Content.ReadAsAsync<ScheduleViewModel>().Result;

            return ScheduleViewModel;
        }


        public ScheduleViewModel EditResult(ScheduleViewModel Schedule, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.PutResponse("api/Schedule/", Schedule);
            response.EnsureSuccessStatusCode();
            ScheduleViewModel ScheduleViewModel =
            response.Content.ReadAsAsync<ScheduleViewModel>().Result;
            return ScheduleViewModel;
        }

        public bool Delete(ScheduleViewModel Schedule, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Schedule/" + Schedule.ScheduleId.ToString());
            response.EnsureSuccessStatusCode();
            bool Eliminado = response.Content.ReadAsAsync<bool>().IsCompleted;
            return Eliminado;
        }
    }
}
