using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rihal_challenge.Models
{
    public class Student
    {

        [Key]
        public Guid StudentId { get; set; }
        public string? StudentName { get; set; }
        public DateTime StudentDateOfBirth { get; set; }
        public Guid CountryId { get; set; }
        public Guid ClassId { get; set; }
        
        [ForeignKey("CountryId")]
        public virtual Country? Country { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class? Class { get; set; }

        public Student()
        {

        }
    }
}
