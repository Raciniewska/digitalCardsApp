using System;

namespace Model
{
    [Serializable()]
    public class AssemblyCard
    {
        public int Id { get; set; }
        public string CardId { get; set; }
        public string EmployeeLN { get; set; }
        public string EmployeeFN { get; set; }
        public string EmployeeID { get; set; }
        private DateTime CreationDate { get; set; }
        public string KNNR { get; set; }
        public string Sort { get; set; }
        public string PrNr { get; set; }
    }
}
