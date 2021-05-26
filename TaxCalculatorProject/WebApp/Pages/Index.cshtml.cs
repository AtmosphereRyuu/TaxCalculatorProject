using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Common.WebApiModels;
using RestSharp;
using RestSharp.Authenticators;
using Common.WebApiModels.TaxCalculation;
using Newtonsoft.Json;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public string Output { get; set; }

        public IndexModel()
        {
        }

        public async Task OnPostSubmitAsync(TaxCalculationPostModel taxCalculationPostModel)
        {
            var client = new RestClient("https://localhost:44338/");
            client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request = new RestRequest("api/TaxCalculation", Method.POST);
            request.AddJsonBody(taxCalculationPostModel);

            var response = client.Post(request);

            if (response.StatusCode != HttpStatusCode.Created)
            {
                var controllerErrorModel = JsonConvert.DeserializeObject<ControllerErrorModel>(response.Content);
                this.Output = $"Error Message: {controllerErrorModel.ErrorMessage}";
            }
            else
            {
                var taxCalculationGetModel = JsonConvert.DeserializeObject<TaxCalculationGetModel>(response.Content);
                this.Output = $"Calculated Tax: {taxCalculationGetModel.CalculatedTax}";
            }
        }
    }
}
