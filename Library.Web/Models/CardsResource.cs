using System.Runtime.Serialization;

namespace Library.Web.Models
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