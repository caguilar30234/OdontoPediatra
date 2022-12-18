using FrontEnd.Models;
using Newtonsoft.Json;
using System.ComponentModel;

namespace FrontEnd.Helpers
{
    public class AppointmentHelper
    {
        public List<AppointmentViewModel> GetAll(string token)
        {

            ServiceRepository Repository = new ServiceRepository(token);
            HttpResponseMessage responseMessage = Repository.GetResponse("api/appointment");
            responseMessage.EnsureSuccessStatusCode();
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            List<AppointmentViewModel> appointments =
                JsonConvert.DeserializeObject<List<AppointmentViewModel>>(content);

            return appointments;

        }

        public AppointmentViewModel Details(int id, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.GetResponse("api/appointment/" + id.ToString());
            response.EnsureSuccessStatusCode();
            AppointmentViewModel appointmentViewModel = response.Content.ReadAsAsync<AppointmentViewModel>().Result;
            return appointmentViewModel;
        }

        public AppointmentViewModel Create(AppointmentViewModel appointment, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.PostResponse("api/appointment/", appointment);
            response.EnsureSuccessStatusCode();
            AppointmentViewModel appointmentViewModel =
            response.Content.ReadAsAsync<AppointmentViewModel>().Result;
            return appointmentViewModel;
        }

        public AppointmentViewModel Edit(int id, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.GetResponse("api/advice/" + id.ToString());
            response.EnsureSuccessStatusCode();
            AppointmentViewModel appointmentViewModel = response.Content.ReadAsAsync<AppointmentViewModel>().Result;

            return appointmentViewModel;
        }


        public AppointmentViewModel EditResult(AppointmentViewModel appointment, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.PutResponse("api/appointment/", appointment);
            response.EnsureSuccessStatusCode();
            AppointmentViewModel appointmentViewModel =
            response.Content.ReadAsAsync<AppointmentViewModel>().Result;
            return appointmentViewModel;
        }

        public AppointmentViewModel Delete(int id, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.GetResponse("api/appointment/" + id.ToString());
            response.EnsureSuccessStatusCode();
            AppointmentViewModel appointmentViewModel = response.Content.ReadAsAsync<AppointmentViewModel>().Result;
            return appointmentViewModel;
        }

        public bool DeleteResponse(AppointmentViewModel appointment, string token)
        {
            int id = appointment.AppoinmentId;
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.DeleteResponse("api/appointment/" + id.ToString());
            response.EnsureSuccessStatusCode();
            bool Eliminado = response.Content.ReadAsAsync<bool>().IsCompleted;
            return Eliminado;
        }
    }
}
