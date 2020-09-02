using System.Runtime.Serialization;

namespace AssemblyCardsSystem.Web.Models
{
    [DataContract]
    public class CardsResource
    {
        [DataMember(Name="id")]
        public string Id { get; set; }
        [DataMember(Name="assemblyCard")]
        public AssemblyCard AssemblyCard { get; set; }
    }
}