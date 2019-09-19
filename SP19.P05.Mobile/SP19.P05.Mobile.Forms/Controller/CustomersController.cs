using RestSharp;
using SP19.P05.Mobile.Forms.Model;

namespace SP19.P05.Mobile.Forms.Controller
{
    public class CustomersController
    {
        public CustomersController() { }

        public void RegisterUser(Customer customer)
        {
            var client = new RestClient("https://localhost:5000/");
            var request = new RestRequest("Postasync/", Method.POST);
            request.AddJsonBody(
            new
            {
                customer
            });
            IRestResponse response = client.Execute(request);

        }
    }
}
