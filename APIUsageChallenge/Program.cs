using APIUsageChallenge.Models;
using static System.Console;

namespace APIUsageChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SWApiCaller SWApiCaller = new SWApiCaller();

            Write("Id of desired person: ");

            string input = ReadLine();

            Task<Person> person = SWApiCaller.callGetPeopelById(int.Parse(input));

            Person personResult = person.Result;

            Console.WriteLine("Person's name: " + personResult.Name);

            Console.WriteLine("Person's height: " + personResult.Height);

            Console.WriteLine("Person's gender: " + personResult.Gender);

            Console.WriteLine("Person's mass: " + personResult.Mass);

            Console.WriteLine("Person's eye color: " + personResult.EyeColor);
        }
    }
}