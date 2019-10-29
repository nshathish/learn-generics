namespace Generics
{
    using System;

    public abstract class Person
    {
        public string Name { get; set; }
    }

    public class Employee : Person
    {
        public int Id { get; set; }


        public virtual void DoWork() => Console.WriteLine("Doing work...");
    }

    public class Manager : Employee
    {
        public override void DoWork() => Console.WriteLine("Managing Employees...");
    }


}