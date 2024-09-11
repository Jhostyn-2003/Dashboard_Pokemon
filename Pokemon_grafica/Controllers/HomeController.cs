using Microsoft.AspNetCore.Mvc;
using Pokemon_grafica.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;

namespace Pokemon_grafica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            var pokemonAbilities = await GetPokemonAbilitiesAsync();
            ViewBag.PokemonAbilities = pokemonAbilities;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<Dictionary<string, int>> GetPokemonAbilitiesAsync()
        {
            if (!_cache.TryGetValue("PokemonAbilities", out Dictionary<string, int> abilitiesCount))
            {
                abilitiesCount = new Dictionary<string, int>();
                using (var client = new HttpClient())
                {
                    // Obtener la lista de todos los Pokémon
                    var response = await client.GetStringAsync("https://pokeapi.co/api/v2/pokemon?limit=50&offset=0");
                    var pokemonList = JObject.Parse(response)["results"];

                    var tasks = pokemonList.Select(async pokemon =>
                    {
                        var pokemonUrl = pokemon["url"].ToString();
                        var pokemonResponse = await client.GetStringAsync(pokemonUrl);
                        var pokemonDetails = JObject.Parse(pokemonResponse);
                        var abilities = pokemonDetails["abilities"].Select(a => a["ability"]["name"].ToString());

                        lock (abilitiesCount)
                        {
                            abilitiesCount[pokemonDetails["name"].ToString()] = abilities.Count();
                        }
                    });

                    await Task.WhenAll(tasks);
                }

                // Cachear los resultados por 1 hora
                _cache.Set("PokemonAbilities", abilitiesCount, TimeSpan.FromHours(1));
            }

            return abilitiesCount;
        }
    }
}
