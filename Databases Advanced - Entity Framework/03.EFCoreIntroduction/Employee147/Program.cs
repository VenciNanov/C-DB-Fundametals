using P02_DatabaseFirst.Data;
using System.IO;
using System;
using System.Globalization;
using System.Linq;

namespace Employee147
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                var employee = db.Employees
                    .Where(e => e.EmployeeId == 147)
                    .Select(e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        Job = e.JobTitle,
                        Project = e.EmployeesProjects.Select(ep => new
                        {
                            ep.Project.Name
                        })
                    })
                    .SingleOrDefault();

                using (StreamWriter Writer = new StreamWriter(@"..\..\..\result.txt"))
                {
                    Writer.WriteLine($"{employee.Name} - {employee.Job}");

                    foreach (var project in employee.Project.OrderBy(p=>p.Name))
                    {
                        Writer.WriteLine($"{project.Name}");
                    }
                }
            }
        }
    }
}
