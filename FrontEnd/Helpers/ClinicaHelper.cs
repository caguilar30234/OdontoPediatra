using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class ClinicaHelper
    {
        public List<ClinicViewModel> GetAll()
        {

            ServiceRepository Repository = new ServiceRepository();
            HttpResponseMessage responseMessage = Repository.GetResponse("api/Clinic");
            responseMessage.EnsureSuccessStatusCode();
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            List<ClinicViewModel> Clinics =
                JsonConvert.DeserializeObject<List<ClinicViewModel>>(content);

            return Clinics;

        }

        public ClinicViewModel Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Clinic/" + id.ToString());
            response.EnsureSuccessStatusCode();
            ClinicViewModel ClinicViewModel = response.Content.ReadAsAsync<ClinicViewModel>().Result;
            return ClinicViewModel;
        }

        public ClinicViewModel Create(ClinicViewModel clinic)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/clinic/", clinic);
            response.EnsureSuccessStatusCode();
            ClinicViewModel clinicViewModel =
            response.Content.ReadAsAsync<ClinicViewModel>().Result;
            return clinicViewModel;
        }

        public ClinicViewModel Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/clinic/" + id.ToString());
            response.EnsureSuccessStatusCode();
            ClinicViewModel clinicViewModel = response.Content.ReadAsAsync<ClinicViewModel>().Result;

            return clinicViewModel;
        }


        public ClinicViewModel EditResult(ClinicViewModel clinic)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/clinic/", clinic);
            response.EnsureSuccessStatusCode();
            ClinicViewModel clinicViewModel =
            response.Content.ReadAsAsync<ClinicViewModel>().Result;
            return clinicViewModel;
        }

        public ClinicViewModel Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/clinic/" + id.ToString());
            response.EnsureSuccessStatusCode();
            ClinicViewModel ClinicViewModel = response.Content.ReadAsAsync<ClinicViewModel>().Result;
            return ClinicViewModel;
        }

        public bool DeleteResponse(ClinicViewModel Clinic)
        {
            int id = Clinic.ClinicId;
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/clinic/" + id.ToString());
            response.EnsureSuccessStatusCode();
            bool Eliminado = response.Content.ReadAsAsync<bool>().IsCompleted;
            return Eliminado;
        }
    }
}
