using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using XamarinTraining.Core.Domain;

namespace XamarinTraining.Core.Services
{
    public class DataService : IDataService
    {
        private HttpClient httpClient;

        public DataService()
        {
            httpClient = new HttpClient();
        }

        public async Task<Character> GetCharacterAsync(int id)
        {
            return await Task.Run(async () =>
            {
                HttpResponseMessage resultMessage = await httpClient.GetAsync("https://rickandmortyapi.com/api/character/" + id);
                string resultContent = await resultMessage.Content.ReadAsStringAsync();
                Character character = JsonConvert.DeserializeObject<Character>(resultContent);
                return character;
            });
        }

    }
}