using APIUsageChallenge.Models;
using Microsoft.Extensions.Caching.Memory;
using static System.Console;

namespace APIUsageChallenge
{
    class SWApiCaller
    {
        static HttpClient client = new HttpClient();
        static string baseUrl = "https://swapi.dev/api/people/";
        static IMemoryCache cache = new MemoryCache(new MemoryCacheOptions());

        public SWApiCaller()
        {
            // initializing the clinet, so it is not necessary every time the api is called
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static Person getPersonByID(int id)
        {
            Person person = null;

            // checks if person is already in cache
            if (cache.TryGetValue(id, out person))
            {
                return person;
            }
            else
            {
                // if person is not in cache so it tries to call the API
                try
                {
                    person = callAPIGetPeopelById(id).Result;

                    // caching the returned person
                    cache.Set(id, person);
                }
                catch (Exception ex)
                {
                    WriteLine(ex);
                    throw;
                }
            }

            return person;
        }

        // sending request to URL with person's id
        private static async Task<Person> callAPIGetPeopelById(int id)
        {
            Person person = null;

            try
            {
                person = await GetPersonAsync(baseUrl + id);
            }
            catch (Exception ex)
            {
                WriteLine(ex);
                throw;
            }

            return person;
        }

        // async GET request to get person
        private static async Task<Person> GetPersonAsync(string path)
        {
            Person person = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode) {
                person = await response.Content.ReadAsAsync<Person>();
            }
            else
            {
                throw new Exception("No person with the given id");
            }

            return person;
        }
    }
}
