using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class AdviceHelper
    {
        /// <summary>
        /// List all advices
        /// </summary>
        /// <returns>AdviceViewModel GetAll</returns>
        public List<AdviceViewModel> GetAll(string token)
        {          
            ServiceRepository Repository = new ServiceRepository(token);
            HttpResponseMessage responseMessage = Repository.GetResponse("api/Advice");
            responseMessage.EnsureSuccessStatusCode();
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            List<AdviceViewModel> advices =
                JsonConvert.DeserializeObject<List<AdviceViewModel>>(content);

            return advices;

        }

        public AdviceViewModel Details(int id, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.GetResponse("api/advice/" + id.ToString());
            response.EnsureSuccessStatusCode();
            AdviceViewModel adviceViewModel = response.Content.ReadAsAsync<AdviceViewModel>().Result;

            return adviceViewModel;
        }


        /// <summary>
        /// Create a new advice
        /// </summary>
        /// <param name="advice"></param>
        /// <param name="fileUpload"></param>
        /// <returns>AdviceViewModel</returns>
        public AdviceViewModel Create(AdviceViewModel advice, List<IFormFile> fileUpload, string token)
        {
            if (fileUpload.Count > 0)
            {
                foreach (var file in fileUpload)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        advice.Picture = ms.ToArray();
                    }

                }

            }
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.PostResponse("api/advice/", advice);
            response.EnsureSuccessStatusCode();
            AdviceViewModel adviceViewModel =
            response.Content.ReadAsAsync<AdviceViewModel>().Result;
            return adviceViewModel;
        }


        /// <summary>
        /// Edit an advice
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AdviceViewModel</returns>

        public AdviceViewModel Edit(AdviceViewModel advice, List<IFormFile> fileUpload, string token)
        {
            if (fileUpload.Count > 0)
            {
                foreach (var file in fileUpload)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        advice.Picture = ms.ToArray();
                    }

                }

            }
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.PutResponse("api/advice/", advice);
            response.EnsureSuccessStatusCode();
            AdviceViewModel adviceViewModel =
            response.Content.ReadAsAsync<AdviceViewModel>().Result;
            return adviceViewModel;
        }

        public bool Delete(AdviceViewModel advice, string token)
        {
            ServiceRepository serviceObj = new ServiceRepository(token);
            HttpResponseMessage response = serviceObj.DeleteResponse("api/advice/" + advice.AdviceId.ToString());
            response.EnsureSuccessStatusCode();
            bool Eliminado = response.Content.ReadAsAsync<bool>().IsCompleted;
            return Eliminado;
        }


    }
}
