using System.Net.Http;
using System.Threading.Tasks;

namespace Console.Strategies
{
    public class ShowProductsInCategory : IProgramInput
    {
        private IHttpClientFactory _clientFactory;

        public ShowProductsInCategory(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task Execute()
        {
            System.Console.WriteLine();
            System.Console.Write("Enter category id then press <enter>: ");
            var categoryId = System.Console.ReadLine();


            var request = new HttpRequestMessage(HttpMethod.Get, Strings.ApiProductsByCategoryId.Replace("{categoryId}", categoryId));
            var client = _clientFactory.CreateClient(Strings.DemoClient);
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                System.Console.WriteLine(responseStream.ReadAllText());
            }
            else
            {
                System.Console.WriteLine($"An error occurred while calling the get products by category id endpoint: {response.ReasonPhrase}");
            }
        }
    }
}
