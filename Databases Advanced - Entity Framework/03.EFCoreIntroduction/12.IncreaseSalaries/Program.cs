using P02_DatabaseFirst.Data;
using System.IO;
using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

namespace _12.IncreaseSalaries
{
    class Program
    {
        static void Main(string[] args)
        {
            var departmentsSalariesToBeIncrease = new List<string> { "Engineering", "Tool Design", "Marketing", "Information Services" };
            using (SoftUniContext db = new SoftUniContext())
            {
                var employees = db.Employees
                    .Where(e => departmentsSalariesToBeIncrease.Contains(e.Department.Name))
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList();

                employees.ForEach(e => e.Salary *= 1.12m);

                db.SaveChanges();

                using (StreamWriter Writer = new StreamWriter(@"..\..\..\result.txt"))
                {
                    foreach (var employee in employees)
                    {
                        Writer.WriteLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
                    }
                }
            }
        }
    }
}
