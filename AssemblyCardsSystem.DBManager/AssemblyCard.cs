using System;

namespace AssemblyCardsSystem.DBManager
{
    public class AssemblyCard
    {
        public int Id { get; set; }
        public string EmployeeLN { get; set; }
        public string EmployeeFN { get; set; }
        public string EmployeeID { get; set; }
        public DateTime CreationDate { get; set; }
        public string KNNR { get; set; }
        public string Sort { get; set; }
        public string PrNr { get; set; }
    }
}