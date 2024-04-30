using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RickMortyApi.Shared.Models;

namespace RickMortyApi.Server.Controllers
{
    [Route("api/characters")]
    public class CharactersController : Controller
    {
       private HttpClient _httpclient;

        public CharactersController()
        {
            _httpclient = new HttpClient();
        }

        [HttpGet]
        [Route("all")]
        public async Task<Characters> GetAllCharacters()
        {
            try
            {
                Characters? characters = null;
                HttpResponseMessage httpResponseMessage = await 
                    _httpclient.GetAsync("https://rickandmortyapi.com/api/character");

                httpResponseMessage.EnsureSuccessStatusCode();

                string responseBody = await 
                    httpResponseMessage.Content.ReadAsStringAsync();

                var tempCharacters = JsonConvert.DeserializeObject<Characters>(responseBody);

                if (tempCharacters != null)
                {
                    characters = tempCharacters;
                    return characters;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }

            catch (Exception)
            {
                throw new ArgumentNullException();
            }

        }
    }
}
