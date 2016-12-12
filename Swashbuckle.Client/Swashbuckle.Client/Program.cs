using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Swashbuckle.Sample.Client;
using Swashbuckle.Sample.Client.Models;

namespace Swashbuckle.Client
{
    /// <summary>
    /// Client code.
    /// The service side predefined two entities.
    /// Id = 1,Name = "Alice",Gender = Gender.Female
    /// Id = 2,Name = "Bob",Gender = Gender.Male
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SwashbuckleSampleClient();
            var students = client.Students.GetByGender(Gender.Female);
            Assert.AreEqual(1, students.Value.Count);
            var student = students.Value[0];
            Assert.AreEqual(1, student.Id);
            Assert.AreEqual("Alice", student.Name);
            Assert.AreEqual(Gender.Female, student.Gender);

            var student2 = client.Students.GetById(2);
            Assert.IsNotNull(student2);
            Assert.AreEqual(2, student2.Id);
            Assert.AreEqual("Bob", student2.Name);
            Assert.AreEqual(Gender.Male, student2.Gender);

            var student3 = client.Students.GetById(3);
            Assert.IsNull(student3);

            Console.Write("Press enter to exit.");
            Console.ReadLine();
        }
    }
}