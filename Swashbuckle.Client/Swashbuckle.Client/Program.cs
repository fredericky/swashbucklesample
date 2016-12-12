using System;
using Swashbuckle.Sample.Client;
using Swashbuckle.Sample.Client.Models;

namespace Swashbuckle.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SwashbuckleSampleClient();
            var students = client.Students.GetByGender(Gender.Female);
            Console.WriteLine("{0}", students.Value.Count);

            Console.Write("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
