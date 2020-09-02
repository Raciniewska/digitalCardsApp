using System;
using System.Runtime.Serialization;
using System.Globalization;

namespace AssemblyCardsSystem.Web.Models
{
    [DataContract(Name = "assemblyCard")]
    public class AssemblyCard
    {
        [DataMember(Name = "employeeLN")]
        public string EmployeeLN { get; set; }
        [DataMember(Name = "employeeFN")]
        public string EmployeeFN { get; set; }
        [DataMember(Name = "employeeID")]
        public string EmployeeID { get; set; }
        [DataMember(Name = "creationDate")]
        private string jsonCreationDate { get; set; }
        [IgnoreDataMember]
        public DateTime CreationDate => DateTime.ParseExact(jsonCreationDate, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
        [DataMember(Name = "knnr")]
        public string KNNR { get; set; }
        [DataMember(Name = "sort")]
        public string Sort { get; set; }
        [DataMember(Name = "prnr")]
        public string PrNr { get; set; }
    }
}