using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class ProvinceHelper
    {
        public List<ProvinceViewModel> GetAll()
        {

            ServiceRepository Repository = new ServiceRepository();
            HttpResponseMessage responseMessage = Repository.GetResponse("api/Province");
            responseMessage.EnsureSuccessStatusCode();
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            List<ProvinceViewModel> Provinces =
                JsonConvert.DeserializeObject<List<ProvinceViewModel>>(content);

            return Provinces;

        }

        public ProvinceViewModel Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Province/" + id.ToString());
            response.EnsureSuccessStatusCode();
            ProvinceViewModel ProvinceViewModel = response.Content.ReadAsAsync<ProvinceViewModel>().Result;
            return ProvinceViewModel;
        }

        public ProvinceViewModel Create(ProvinceViewModel Province)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Province/", Province);
            response.EnsureSuccessStatusCode();
            ProvinceViewModel ProvinceViewModel =
            response.Content.ReadAsAsync<ProvinceViewModel>().Result;
            return ProvinceViewModel;
        }

        public ProvinceViewModel Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/advice/" + id.ToString());
            response.EnsureSuccessStatusCode();
            ProvinceViewModel ProvinceViewModel = response.Content.ReadAsAsync<ProvinceViewModel>().Result;

            return ProvinceViewModel;
        }


        public ProvinceViewModel EditResult(ProvinceViewModel Province)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/Province/", Province);
            response.EnsureSuccessStatusCode();
            ProvinceViewModel ProvinceViewModel =
            response.Content.ReadAsAsync<ProvinceViewModel>().Result;
            return ProvinceViewModel;
        }

        public ProvinceViewModel Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Province/" + id.ToString());
            response.EnsureSuccessStatusCode();
            ProvinceViewModel ProvinceViewModel = response.Content.ReadAsAsync<ProvinceViewModel>().Result;
            return ProvinceViewModel;
        }

        public bool DeleteResponse(ProvinceViewModel Province)
        {
            int id = Province.ProvinceId;
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Province/" + id.ToString());
            response.EnsureSuccessStatusCode();
            bool Eliminado = response.Content.ReadAsAsync<bool>().IsCompleted;
            return Eliminado;
        }
    }
}
