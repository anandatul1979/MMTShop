using System.Net.Http;
using System.Threading.Tasks;

namespace Console.Strategies
{
    public class ShowCategories : IProgramInput
    {
        private IHttpClientFactory _clientFactory;

        public ShowCategories(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task Execute()
        {
            var client = _clientFactory.CreateClient(Strings.DemoClient);
            var response = await client.GetAsync(Strings.ApiCategoriesAll);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                System.Console.WriteLine(responseStream.ReadAllText());
            }
            else
            {
                System.Console.WriteLine($"An error occurred while calling the get all categories endpoint: {response.ReasonPhrase}");
            }
        }
    }
}
