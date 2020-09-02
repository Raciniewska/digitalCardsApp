using System.Runtime.Serialization;

namespace AssemblyCardsSystem.Web.Models
{
    [DataContract]
    public class LibraryResource
    {
        [DataMember(Name="id")]
        public int Id { get; set; }
        [DataMember(Name="book")]
        public Book Book { get; set; }
    }
}