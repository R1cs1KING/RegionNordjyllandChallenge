using APIUsageChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIUsageChallenge
{
    class SWApiCaller
    {
        static HttpClient client = new HttpClient();
        static string baseUrl = "https://swapi.dev/api/people/";

        public static async Task<Person> callGetPeopelById(int id)
        {
            Person person = null;
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                Console.WriteLine("tries");
                person = await GetPersonAsync(baseUrl + id);
            } catch (Exception e) {
                Console.WriteLine(e);
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
            }

            return person;
        }
    }
}
