﻿namespace AssemblyCardsSystem.WebApi.Models
{
    public class CardToSend
    {

        public string destinationEmail { get; set; }
        public string EmployeeLN { get; set; }
        public string EmployeeFN { get; set; }
        public string EmployeeID { get; set; }
        public string KNNR { get; set; }
        public string Sort { get; set; }
        public string PrNr { get; set; }
    }
}
