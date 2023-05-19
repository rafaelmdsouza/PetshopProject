namespace Petshop.Domain.Agreggate.OwnerAggregate
{
    public class PetHistory
    {
        private PetHistory()
        {
        }
        public PetHistory(string? reason, string message, Guid petId, Guid? employeeId)
        {
            HistoryDate = DateTime.Now;
            Reason = reason;
            Message = message;
            EmployeeId = employeeId;
            PetId = petId;
        }
        public DateTime HistoryDate { get; private set; }
        public string? Reason { get; private set; }
        public string Message { get; private set;}
        public Guid? EmployeeId { get; private set; }
        public Guid PetId { get; private set; }
    }
}