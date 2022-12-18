using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TreatmentHelper
    {

        public List<TreatmentViewModel> GetAll(string token)
        {

            ServiceRepository Repository = new ServiceRepository(token);
            HttpResponseMessage responseMessage = Repository.GetResponse("api/Treatment");
            responseMessage.EnsureSuccessStatusCode();
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            List<TreatmentViewModel> Treatments =
                JsonConvert.DeserializeObject<List<TreatmentViewModel>>(content);

            return Treatments;

        }

        public TreatmentViewModel Details(int id, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.GetResponse("api/Treatment/" + id.ToString());
            response.EnsureSuccessStatusCode();
            TreatmentViewModel TreatmentViewModel = response.Content.ReadAsAsync<TreatmentViewModel>().Result;
            return TreatmentViewModel;
        }

        public TreatmentViewModel Create(TreatmentViewModel Treatment, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.PostResponse("api/Treatment/", Treatment);
            response.EnsureSuccessStatusCode();
            TreatmentViewModel TreatmentViewModel =
            response.Content.ReadAsAsync<TreatmentViewModel>().Result;
            return TreatmentViewModel;
        }

        public TreatmentViewModel Edit(int id, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.GetResponse("api/advice/" + id.ToString());
            response.EnsureSuccessStatusCode();
            TreatmentViewModel TreatmentViewModel = response.Content.ReadAsAsync<TreatmentViewModel>().Result;

            return TreatmentViewModel;
        }


        public TreatmentViewModel EditResult(TreatmentViewModel Treatment, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.PutResponse("api/Treatment/", Treatment);
            response.EnsureSuccessStatusCode();
            TreatmentViewModel TreatmentViewModel =
            response.Content.ReadAsAsync<TreatmentViewModel>().Result;
            return TreatmentViewModel;
        }

        public TreatmentViewModel Delete(int id, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.GetResponse("api/Treatment/" + id.ToString());
            response.EnsureSuccessStatusCode();
            TreatmentViewModel TreatmentViewModel = response.Content.ReadAsAsync<TreatmentViewModel>().Result;
            return TreatmentViewModel;
        }

        public bool DeleteResponse(TreatmentViewModel Treatment, string token)
        {
            int id = Treatment.TreatmentId;
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Treatment/" + id.ToString());
            response.EnsureSuccessStatusCode();
            bool Eliminado = response.Content.ReadAsAsync<bool>().IsCompleted;
            return Eliminado;
        }
    }
}
