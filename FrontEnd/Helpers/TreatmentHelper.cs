using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TreatmentHelper
    {
        public List<TreatmentViewModel> GetAll()
        {

            ServiceRepository Repository = new ServiceRepository();
            HttpResponseMessage responseMessage = Repository.GetResponse("api/Treatment");
            responseMessage.EnsureSuccessStatusCode();
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            List<TreatmentViewModel> Treatments =
                JsonConvert.DeserializeObject<List<TreatmentViewModel>>(content);

            return Treatments;

        }

        public TreatmentViewModel Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Treatment/" + id.ToString());
            response.EnsureSuccessStatusCode();
            TreatmentViewModel TreatmentViewModel = response.Content.ReadAsAsync<TreatmentViewModel>().Result;
            return TreatmentViewModel;
        }

        public TreatmentViewModel Create(TreatmentViewModel Treatment)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Treatment/", Treatment);
            response.EnsureSuccessStatusCode();
            TreatmentViewModel TreatmentViewModel =
            response.Content.ReadAsAsync<TreatmentViewModel>().Result;
            return TreatmentViewModel;
        }

        public TreatmentViewModel Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/advice/" + id.ToString());
            response.EnsureSuccessStatusCode();
            TreatmentViewModel TreatmentViewModel = response.Content.ReadAsAsync<TreatmentViewModel>().Result;

            return TreatmentViewModel;
        }


        public TreatmentViewModel EditResult(TreatmentViewModel Treatment)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/Treatment/", Treatment);
            response.EnsureSuccessStatusCode();
            TreatmentViewModel TreatmentViewModel =
            response.Content.ReadAsAsync<TreatmentViewModel>().Result;
            return TreatmentViewModel;
        }

        public TreatmentViewModel Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Treatment/" + id.ToString());
            response.EnsureSuccessStatusCode();
            TreatmentViewModel TreatmentViewModel = response.Content.ReadAsAsync<TreatmentViewModel>().Result;
            return TreatmentViewModel;
        }

        public bool DeleteResponse(TreatmentViewModel Treatment)
        {
            int id = Treatment.TreatmentId;
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Treatment/" + id.ToString());
            response.EnsureSuccessStatusCode();
            bool Eliminado = response.Content.ReadAsAsync<bool>().IsCompleted;
            return Eliminado;
        }
    }
}
