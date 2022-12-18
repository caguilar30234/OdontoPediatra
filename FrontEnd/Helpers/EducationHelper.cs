using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class EducationHelper
    {
        public List<EducationViewModel> GetAll(string token)
        {

            ServiceRepository Repository = new ServiceRepository(token);
            HttpResponseMessage responseMessage = Repository.GetResponse("api/Education");
            responseMessage.EnsureSuccessStatusCode();
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            List<EducationViewModel> Educations =
                JsonConvert.DeserializeObject<List<EducationViewModel>>(content);

            return Educations;

        }

        public EducationViewModel Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Education/" + id.ToString());
            response.EnsureSuccessStatusCode();
            EducationViewModel EducationViewModel = response.Content.ReadAsAsync<EducationViewModel>().Result;
            return EducationViewModel;
        }

        public EducationViewModel Create(EducationViewModel Education)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Education/", Education);
            response.EnsureSuccessStatusCode();
            EducationViewModel EducationViewModel =
            response.Content.ReadAsAsync<EducationViewModel>().Result;
            return EducationViewModel;
        }

        public EducationViewModel Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/advice/" + id.ToString());
            response.EnsureSuccessStatusCode();
            EducationViewModel EducationViewModel = response.Content.ReadAsAsync<EducationViewModel>().Result;

            return EducationViewModel;
        }


        public EducationViewModel EditResult(EducationViewModel Education)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/Education/", Education);
            response.EnsureSuccessStatusCode();
            EducationViewModel EducationViewModel =
            response.Content.ReadAsAsync<EducationViewModel>().Result;
            return EducationViewModel;
        }

        public EducationViewModel Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Education/" + id.ToString());
            response.EnsureSuccessStatusCode();
            EducationViewModel EducationViewModel = response.Content.ReadAsAsync<EducationViewModel>().Result;
            return EducationViewModel;
        }

        public bool DeleteResponse(EducationViewModel Education)
        {
            int id = Education.EducationId;
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Education/" + id.ToString());
            response.EnsureSuccessStatusCode();
            bool Eliminado = response.Content.ReadAsAsync<bool>().IsCompleted;
            return Eliminado;
        }
    }
}
