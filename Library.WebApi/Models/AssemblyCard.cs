using System;

namespace Library.WebApi.Models
{
    public class AssemblyCard
    {
        public string EmployeeLN { get; set; }
        public string EmployeeFN { get; set; }
        public string EmployeeID { get; set; }
        private DateTime CreationDate { get; set; }
        public string KNNR { get; set; }
        public string Sort { get; set; }
        public string PrNr { get; set; }
    }
}