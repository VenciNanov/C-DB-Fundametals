using P02_DatabaseFirst.Data;
using System.IO;
using System;
using System.Globalization;
using System.Linq;
namespace _14.DeleteProjectById
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                var projectToDelete = db.Projects.FirstOrDefault(p => p.ProjectId == 2);

                db.RemoveRange(db.EmployeesProjects
                    .Where(ep => ep.ProjectId == 2));
                db.Remove(projectToDelete);
                db.SaveChanges();

                using (StreamWriter Writer = new StreamWriter(@"..\..\..\result.txt"))
                {
                    foreach (var project in db.Projects.Take(10))
                    {
                        Writer.WriteLine($"{project.Name}");
                    }
                }
            }
        }
    }
}
