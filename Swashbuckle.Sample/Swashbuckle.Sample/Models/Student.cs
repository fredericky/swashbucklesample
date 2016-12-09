using System.ComponentModel.DataAnnotations;

namespace Swashbuckle.Sample.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }
    }
}
