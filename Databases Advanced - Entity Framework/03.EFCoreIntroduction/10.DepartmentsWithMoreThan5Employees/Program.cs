using P02_DatabaseFirst.Data;
using System.IO;
using System;
using System.Globalization;
using System.Linq;

namespace _10.DepartmentsWithMoreThan5Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                var departments = db.Departments
                    .Where(d => d.Employees.Count > 5)
                    .OrderBy(d => d.Employees.Count)
                    .ThenBy(d => d.Name)
                    .Select(d => new
                    {
                        DepartmentName = d.Name,
                        ManagerName = $"{d.Manager.FirstName} {d.Manager.LastName}",
                        Employees = d.Employees.Select(e => new
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Job = e.JobTitle
                        })
                    })
                    .ToList();

                using(StreamWriter Writer = new StreamWriter(@"..\..\..\result.txt"))
                {
                    foreach (var department in departments)
                    {
                        Writer.WriteLine($"{department.DepartmentName} - {department.ManagerName}");
                        foreach (var employee in department.Employees.OrderBy(e=>e.FirstName).ThenBy(e=>e.LastName))
                        {
                            Writer.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.Job}");
                        }
                        Writer.WriteLine("----------");
                    }
                }
            }
        }
    }
}
