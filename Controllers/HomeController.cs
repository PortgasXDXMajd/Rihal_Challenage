using Microsoft.AspNetCore.Mvc;
using rihal_challenge.Context;
using rihal_challenge.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using rihal_challenge.ViewModels;

namespace rihal_challenge.Controllers
{   
    public class HomeController : Controller
    {
        private MyDbContext _context;

        public HomeController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel _HomeViewModel = new HomeViewModel();
            int ageSum = 0;

            var students = _context.student_table!.Include(s => s.Country).Include(s=>s.Class).ToList();
            var countries = _context.country_table!.Include(country => country.StudentList).ToList();
            var classes = _context.class_table!.Include(c => c.StudentList).ToList();

            
            
            foreach (Student student in students)
            {
                int age = 0;
                age = DateTime.Now.Subtract(student.StudentDateOfBirth).Days;
                age = age / 365;
                ageSum += age;
            }

            _HomeViewModel.studentList = students;
            _HomeViewModel.classList = classes;
            _HomeViewModel.countryList = countries;
            _HomeViewModel.StudentAvrageAge = ageSum/ students.Count();

            return View(_HomeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}