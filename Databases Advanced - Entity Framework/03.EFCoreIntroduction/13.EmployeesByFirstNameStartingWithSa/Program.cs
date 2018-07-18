using P02_DatabaseFirst.Data;
using System.IO;
using System;
using System.Globalization;
using System.Linq;

namespace _13.EmployeesByFirstNameStartingWithSa
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                var employees = db.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Where(e => e.FirstName.StartsWith("Sa"))
                    .Select(e => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Job = e.JobTitle,
                        Salary = e.Salary
                    })
                    .ToList();

                using (StreamWriter Writer = new StreamWriter(@"..\..\..\result.txt"))
                {
                    foreach (var employee in employees)
                    {
                        Writer.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.Job} - (${employee.Salary:F2})");
                    }
                }
            }
        }
    }
}
