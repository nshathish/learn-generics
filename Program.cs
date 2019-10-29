using System;

namespace Generics
{
    using System.Linq;

    class Program
    {
        static void Main()
        {
            using var context = new EmployeeDb();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            using var repo = new SqlRepository<Employee>(context);
            AddEmployees(repo);
            CountEmployees(repo);
        }

        private static void AddEmployees(SqlRepository<Employee> repo)
        {
            repo.Add(new Employee { Name = "Scott" });
            repo.Add(new Employee { Name = "Nichols" });
            var result = repo.Commit();
            Console.WriteLine($"{result} employees added");
        }

        private static void CountEmployees(SqlRepository<Employee> repo)
        {
            Console.WriteLine($"Employee count: {repo.FindAll().Count()}");
        }

        
    }
}
