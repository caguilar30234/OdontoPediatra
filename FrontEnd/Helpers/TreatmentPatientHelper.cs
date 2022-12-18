using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TreatmentPatientHelper
    {
        public List<TreatmentPatientViewModel> GetAll()
        {

            ServiceRepository Repository = new ServiceRepository();
            HttpResponseMessage responseMessage = Repository.GetResponse("api/TreatmentPatient");
            responseMessage.EnsureSuccessStatusCode();
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            List<TreatmentPatientViewModel> treatmentPatients =
                JsonConvert.DeserializeObject<List<TreatmentPatientViewModel>>(content);

            return treatmentPatients;

        }

        public TreatmentPatientViewModel Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/TreatmentPatient/" + id.ToString());
            response.EnsureSuccessStatusCode();
            TreatmentPatientViewModel treatmentPatientViewModel = response.Content.ReadAsAsync<TreatmentPatientViewModel>().Result;
            return treatmentPatientViewModel;
        }

        public TreatmentPatientViewModel Create(TreatmentPatientViewModel treatmentPatient)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/TreatmentPatient/", treatmentPatient);
            response.EnsureSuccessStatusCode();
            TreatmentPatientViewModel treatmentPatientViewModel =
            response.Content.ReadAsAsync<TreatmentPatientViewModel>().Result;
            return treatmentPatientViewModel;
        }

        public TreatmentPatientViewModel Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/TreatmentPatient/" + id.ToString());
            response.EnsureSuccessStatusCode();
            TreatmentPatientViewModel treatmentPatientViewModel = response.Content.ReadAsAsync<TreatmentPatientViewModel>().Result;

            return treatmentPatientViewModel;
        }


        public TreatmentPatientViewModel EditResult(TreatmentPatientViewModel treatmentPatient)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/TreatmentPatient/", treatmentPatient);
            response.EnsureSuccessStatusCode();
            TreatmentPatientViewModel treatmentPatientViewModel =
            response.Content.ReadAsAsync<TreatmentPatientViewModel>().Result;
            return treatmentPatientViewModel;
        }

        public TreatmentPatientViewModel Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/TreatmentPatient/" + id.ToString());
            response.EnsureSuccessStatusCode();
            TreatmentPatientViewModel treatmentPatientViewModel = response.Content.ReadAsAsync<TreatmentPatientViewModel>().Result;
            return treatmentPatientViewModel;
        }

        public bool DeleteResponse(TreatmentPatientViewModel treatmentPatient)
        {
            int id = treatmentPatient.TreatmentPatientId;
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/TreatmentPatient/" + id.ToString());
            response.EnsureSuccessStatusCode();
            bool Eliminado = response.Content.ReadAsAsync<bool>().IsCompleted;
            return Eliminado;
        }
    }
}
