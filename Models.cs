namespace Generics
{
    using System;

    public interface IEntity
    {
        bool IsValid();
    }

    public abstract class Person
    {
        public string Name { get; set; }
    }

    public class Employee : Person, IEntity
    {
        public int Id { get; set; }
        
        public virtual void DoWork() => Console.WriteLine("Doing work...");

        public bool IsValid() => true;
    }

    public class Manager : Employee
    {
        public override void DoWork() => Console.WriteLine("Managing Employees...");
    }


}