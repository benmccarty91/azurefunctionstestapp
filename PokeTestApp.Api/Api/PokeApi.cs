using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace Api
{
    public static class PokeApi
    {
        [FunctionName("GetPokemon")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "GetPokemon")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://pokeapi.co/api/v2/pokemon");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync()).results;

            return new OkObjectResult(data);
        }
    }
}
