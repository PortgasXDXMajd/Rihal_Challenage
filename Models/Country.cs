using System.ComponentModel.DataAnnotations;

namespace rihal_challenge.Models
{
    public class Country
    {
        [Key]
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }
        public virtual List<Student>? StudentList { get; set; }
        public Country()
        {

        }
    }
}
