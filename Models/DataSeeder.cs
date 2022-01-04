using rihal_challenge.Context;
using System;

namespace rihal_challenge.Models
{
    public class DataSeeder
    {
        private readonly MyDbContext _context;

        public DataSeeder(MyDbContext context)
        {
            this._context = context;
        }

        public void Seed()
        {
            Random rnd = new Random();
            List<Guid> classesIds = new List<Guid>();
            List<Guid> countriesIds = new List<Guid>();

            if (!_context.country_table!.Any())
            {
                var countries = new List<Country>()
                {
                        new Country()
                        {
                            CountryId = Guid.NewGuid(),
                            CountryName = "Syria",
                        },
                        new Country()
                        {
                            CountryId = Guid.NewGuid(),
                            CountryName = "Tunis",
                        },
                        new Country()
                        {
                            CountryId = Guid.NewGuid(),
                            CountryName = "Oman",
                        }
                };

                foreach (Country country in countries)
                {
                    countriesIds.Add(country.CountryId);
                }

                _context.country_table!.AddRange(countries);
                _context.SaveChanges();
            }

            if (!_context.class_table!.Any())
            {
                var classes = new List<Class>()
                {
                        new Class()
                        {
                            ClassId = Guid.NewGuid(),
                            ClassName = "Computer Science",
                        },
                        new Class()
                        {
                            ClassId = Guid.NewGuid(),
                            ClassName = "Art",
                        },
                        new Class()
                        {
                            ClassId = Guid.NewGuid(),
                            ClassName = "Math",
                        },
                };
                foreach (Class c in classes)
                {
                    classesIds.Add(c.ClassId);
                }

                _context.class_table!.AddRange(classes);
                _context.SaveChanges();
            }

            if (!_context.student_table!.Any())
            {
                var students = new List<Student>()
                {
                        new Student()
                        {
                            StudentId = Guid.NewGuid(),
                            StudentName = "Majd AL Kayyal",
                            StudentDateOfBirth = new DateTime(year:1998, month:3,day:3),
                            CountryId = countriesIds[rnd.Next(classesIds.Count)],
                            ClassId = classesIds[rnd.Next(classesIds.Count)],
                        },
                        new Student()
                        {
                            StudentId = Guid.NewGuid(),
                            StudentName = "Linda Zakhama",
                            StudentDateOfBirth = new DateTime(year:2001, month:4,day:10),
                            CountryId = countriesIds[rnd.Next(classesIds.Count)],
                            ClassId = classesIds[rnd.Next(classesIds.Count)],
                        }
                };

                _context.student_table!.AddRange(students);
                _context.SaveChanges();
            }
        }
    }
}
