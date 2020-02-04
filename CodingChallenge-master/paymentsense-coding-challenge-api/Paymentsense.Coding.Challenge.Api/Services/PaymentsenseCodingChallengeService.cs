using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Paymentsense.Coding.Challenge.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class PaymentsenseCodingChallengeService : IPaymentsenseCodingChallengeService
    {
        private readonly IMemoryCache cache;
        private const string cacheKey = "CountriesCacheKey";
        public PaymentsenseCodingChallengeService(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public async Task<List<Country>> GetCountries()
        {
            return await cache.GetOrCreateAsync(cacheKey, cacheEntry => { return GetCountriesFromSource(); });
        }

        public async Task<List<Country>> GetCountriesFromSource()
        {
            using var client = new HttpClient();
            var task = await client.GetAsync("https://restcountries.eu/rest/v2/all");
            var jsonString = await task.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Country>>(jsonString);
        }
    }
}
