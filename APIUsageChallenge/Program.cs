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

            string inputString = ReadLine();
            int inputId = 0;

            try
            {
                inputId = int.Parse(inputString);
            }
            catch (FormatException)
            {
                WriteLine("You need to use an integer as an id");
                throw;
            }
            catch (Exception e)
            {
                WriteLine(e.ToString());
                throw;
            }

            Person person = SWApiCaller.getPersonByID(inputId);

            try
            {
                WriteLine("Person's name: " + person.Name);

                WriteLine("Person's height: " + person.Height);

                WriteLine("Person's gender: " + person.Gender);

                WriteLine("Person's mass: " + person.Mass);

                WriteLine("Person's eye color: " + person.EyeColor);
            }
            catch (NullReferenceException)
            {
                WriteLine("No persion with that id.");
            }
        }
    }
}