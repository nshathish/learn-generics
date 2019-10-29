namespace Generics
{
    using System;

    public interface IEntity
    {
        bool IsValid();
    }

    public abstract class Person
    {
        protected string PersonType;

        public string Name { get; set; }
        public string Type => PersonType;
    }

    public class Employee : Person, IEntity
    {
        public Employee() => PersonType = "Employee";

        public int Id { get; set; }
        
        public virtual void DoWork() => Console.WriteLine("Doing work...");

        public bool IsValid() => true;
    }

    public class Manager : Employee
    {
        public Manager() => PersonType = "Manager";

        public override void DoWork() => Console.WriteLine("Managing Employees...");
    }


}