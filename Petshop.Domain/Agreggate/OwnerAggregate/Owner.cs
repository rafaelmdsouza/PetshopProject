namespace Petshop.Domain.Agreggate.OwnerAggregate
{
    public class Owner
    {
        private Owner() {}
        public Owner(string name, int age, string email, string phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            Email = email;
            Phone = phone;
            IsActive = true;
            RegistrationDate = DateTime.Now;
            LastModified = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public ICollection<Pet>? Pets => _petList;
        private List<Pet> _petList = new List<Pet>();
        public bool IsActive { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime LastModified { get; private set; }

        public void RegisterPet(Pet pet)
        {
            LastModified = DateTime.Now;
            _petList.Add(pet);
        }

        public void RemovePet(Guid id)
        {
            var pet = _petList.Find(p => p.Id == id);
            _petList.Remove(pet);

            LastModified = DateTime.Now;
        }

        public void Update(string name, string phone, string email, int age)
        {
            Name = name;
            Age = age;
            Email = email;
            Phone = phone;
            LastModified = DateTime.Now;
        }

        public void Disable()
        {
            IsActive = false;
            LastModified = DateTime.Now;
        }

        public void Enable()
        {
            IsActive = true;
            LastModified = DateTime.Now;
        }

    }
}