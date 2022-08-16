using APIUsageChallenge.Models;
using static System.Console;

namespace APIUsageChallenge
{
    class SWApiCaller
    {
        static HttpClient client = new HttpClient();
        static string baseUrl = "https://swapi.dev/api/people/";

        public static Person getPersonByID(int id)
        {
            Person person = null;

            try
            {
                person = callAPIGetPeopelById(id).Result;
            }
            catch (Exception ex)
            {
                WriteLine(ex);
                throw;
            }

            return person;
        }

        private static async Task<Person> callAPIGetPeopelById(int id)
        {
            Person person = null;
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

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

        private static async Task<Person> GetPersonAsync(string path)
        {
            Person person = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode) {
                person = await response.Content.ReadAsAsync<Person>();
            } else
            {
                throw new Exception("No person with the given id");
            }

            return person;
        }
    }
}
