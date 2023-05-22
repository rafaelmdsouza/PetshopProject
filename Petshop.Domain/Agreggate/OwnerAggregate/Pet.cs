namespace Petshop.Domain.Agreggate.OwnerAggregate
{
    public class Pet
    {
        private Pet()
        {
        }
        public Pet(Guid ownerId, string name, int age, PetType type)
        {
            Id = Guid.NewGuid();
            OwnerId = ownerId;
            Name = name;
            Age = age;
            Type = type;
            IsVaccinated = false;

            _history.Add(new PetHistory(null, "New pet added", Id, null));
        }
        public Guid Id { get; private set; }
        public Guid OwnerId { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public PetType Type { get; private set; }
        public ICollection<PetHistory>? History => _history;
        private List<PetHistory> _history = new List<PetHistory>();
        public bool IsVaccinated { get; private set; }

        public void Grooming(Guid groomedBy)
        {
            _history.Add(new PetHistory(null, "Pet groomed", Id, groomedBy));
        }

        public void Vaccinate(Guid vaccinatedBy, string reason)
        {
            IsVaccinated = true;
            _history.Add(new PetHistory(reason, "Pet vacinated", Id, vaccinatedBy));
        }
    }
}