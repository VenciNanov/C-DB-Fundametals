using P02_DatabaseFirst.Data;
using System;
using System.IO;
using System.Linq;

namespace _03.EmployeesFullInformation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var employees = db.Employees
                    .Select(e => new
                    {
                        e.EmployeeId,
                        e.FirstName,
                        e.LastName,
                        e.MiddleName,
                        e.JobTitle,
                        e.Salary
                    })
                    .OrderBy(e => e.EmployeeId)
                    .ToList();


                using (StreamWriter writer = new StreamWriter(@"..\..\..\result.txt"))
                {
                    foreach (var employee in employees)
                    {
                        writer.WriteLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
                    }
                }
            }
        }
    }
}
