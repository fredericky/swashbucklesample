namespace Swashbuckle.Sample.Models
{
    /// <summary>
    /// The Student model.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// The identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The gender.
        /// </summary>
        public Gender Gender { get; set; }
    }
}
