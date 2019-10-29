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
            AddManagers(repo);
            CountEmployees(repo);
            QueryEmployees(repo);
            DumpPeople(repo);
        }
        
        private static void AddEmployees(IRepository<Employee> repo)
        {
            repo.Add(new Employee { Name = "Scott" });
            repo.Add(new Employee { Name = "Nichols" });
            var result = repo.Commit();
            Console.WriteLine($"{result} employees added");
        }

        private static void AddManagers(IWriteonlyRepository<Manager> repo)
        {
            repo.Add(new Manager{Name =  "James Denton"});
            repo.Commit();
        }

        private static void CountEmployees(IRepository<Employee> repo)
        {
            Console.WriteLine($"Employee count: {repo.FindAll().Count()}");
        }

        private static void QueryEmployees(IRepository<Employee> repo)
        {
            var employee = repo.FindById(1);
            Console.WriteLine($"Name: {employee.Name}");
        }

        private static void DumpPeople(IReadonlyRepository<Person> repo)
        {
            var employees = repo.FindAll();
            foreach (var employee in employees)
                Console.WriteLine($"Name: {employee.Name}- Position: {employee.Type}");
        }

    }
}
