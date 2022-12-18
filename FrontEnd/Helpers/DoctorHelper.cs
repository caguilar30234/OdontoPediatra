using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class DoctorHelper
    {
        public List<DoctorViewModel> GetAll(string token)
        {

            ServiceRepository Repository = new ServiceRepository(token);
            HttpResponseMessage responseMessage = Repository.GetResponse("api/doctor");
            responseMessage.EnsureSuccessStatusCode();
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            List<DoctorViewModel> doctors =
                JsonConvert.DeserializeObject<List<DoctorViewModel>>(content);

            return doctors;

        }

        public DoctorViewModel Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/doctor/" + id.ToString());
            response.EnsureSuccessStatusCode();
            DoctorViewModel doctorViewModel = response.Content.ReadAsAsync<DoctorViewModel>().Result;
            return doctorViewModel;
        }

        public DoctorViewModel Create(DoctorViewModel doctor)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/doctor/", doctor);
            response.EnsureSuccessStatusCode();
            DoctorViewModel doctorViewModel =
            response.Content.ReadAsAsync<DoctorViewModel>().Result;
            return doctorViewModel;
        }

        public DoctorViewModel Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/doctor/" + id.ToString());
            response.EnsureSuccessStatusCode();
            DoctorViewModel doctorViewModel = response.Content.ReadAsAsync<DoctorViewModel>().Result;

            return doctorViewModel;
        }


        public DoctorViewModel EditResult(DoctorViewModel doctor)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/doctor/", doctor);
            response.EnsureSuccessStatusCode();
            DoctorViewModel doctorViewModel =
            response.Content.ReadAsAsync<DoctorViewModel>().Result;
            return doctorViewModel;
        }

        public DoctorViewModel Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/doctor/" + id.ToString());
            response.EnsureSuccessStatusCode();
            DoctorViewModel doctorViewModel = response.Content.ReadAsAsync<DoctorViewModel>().Result;
            return doctorViewModel;
        }

        public bool DeleteResponse(DoctorViewModel doctor)
        {
            int id = doctor.DoctorId;
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/doctor/" + id.ToString());
            response.EnsureSuccessStatusCode();
            bool Eliminado = response.Content.ReadAsAsync<bool>().IsCompleted;
            return Eliminado;
        }
    }
}
