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
            QueryEmployees(repo);
            DumpPeople(repo);
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

        private static void QueryEmployees(SqlRepository<Employee> repo)
        {
            var employee = repo.FindById(1);
            Console.WriteLine($"Name: {employee.Name}");
        }

        private static void DumpPeople(IReadonlyRepository<Person> repo)
        {
            throw new NotImplementedException();
        }

    }
}
