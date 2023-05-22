using Petshop.Domain.Core.Model;

namespace Petshop.Domain.Agreggate.EmployeeAggregate
{
    public class Employee : IAggregateRoot
    {
        private Employee()
        {
        }

        public Employee(string name, int age)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            IsActive = true;
            LastModified = DateTime.Now;
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime LastModified { get; private set; }

        public void Disable()
        {
            LastModified = DateTime.Now;
            IsActive = false;
        }
        public void Enable()
        {
            LastModified = DateTime.Now;
            IsActive = true;
        }
    }
}