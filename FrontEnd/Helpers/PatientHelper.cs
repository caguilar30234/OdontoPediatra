using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class PatientHelper
    {
        public List<PatientViewModel> GetAll(string token)
        {
            ServiceRepository Repository = new ServiceRepository(token);
            HttpResponseMessage responseMessage = Repository.GetResponse("api/Patient");
            responseMessage.EnsureSuccessStatusCode();
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            List<PatientViewModel> Patients = JsonConvert.DeserializeObject<List<PatientViewModel>>(content);

            return Patients;

        }

        public PatientViewModel GetPatient(int id, string token) {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.GetResponse("api/Patient/" + id.ToString());
            var content = response.Content.ReadAsStringAsync().Result;
            PatientViewModel patientViewModel = response.Content.ReadAsAsync<PatientViewModel>().Result;
            return patientViewModel;
        }

        public PatientViewModel Details(int id, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.GetResponse("api/Patient/" + id.ToString());
            response.EnsureSuccessStatusCode();
            PatientViewModel PatientViewModel = response.Content.ReadAsAsync<PatientViewModel>().Result;
            return PatientViewModel;
        }

        public PatientViewModel Create(PatientViewModel Patient, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.PostResponse("api/Patient/", Patient);
            response.EnsureSuccessStatusCode();
            PatientViewModel PatientViewModel =
            response.Content.ReadAsAsync<PatientViewModel>().Result;
            return PatientViewModel;
        }

        public PatientViewModel Edit(int id, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.GetResponse("api/Patient/" + id.ToString());
            response.EnsureSuccessStatusCode();
            PatientViewModel PatientViewModel = response.Content.ReadAsAsync<PatientViewModel>().Result;

            return PatientViewModel;
        }


        public PatientViewModel EditResult(PatientViewModel Patient, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.PutResponse("api/Patient/", Patient);
            response.EnsureSuccessStatusCode();
            PatientViewModel PatientViewModel =
            response.Content.ReadAsAsync<PatientViewModel>().Result;
            return PatientViewModel;
        }

        public PatientViewModel Delete(int id, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.GetResponse("api/Patient/" + id.ToString());
            response.EnsureSuccessStatusCode();
            PatientViewModel PatientViewModel = response.Content.ReadAsAsync<PatientViewModel>().Result;
            return PatientViewModel;
        }

        public bool DeleteResponse(PatientViewModel Patient, string token)
        {
            int id = Patient.PatientId;
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Patient/" + id.ToString());
            response.EnsureSuccessStatusCode();
            bool Eliminado = response.Content.ReadAsAsync<bool>().IsCompleted;
            return Eliminado;
        }
    }
}
