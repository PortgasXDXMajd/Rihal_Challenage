using rihal_challenge.Models;

namespace rihal_challenge.ViewModels
{
    public class HomeViewModel
    {
        public List<Student>? studentList { get; set; }
        public List<Country>? countryList { get; set; }
        public List<Class>? classList { get; set; }
        public double StudentAvrageAge { get; set; }


        public HomeViewModel()
        {

        }
    }
}
