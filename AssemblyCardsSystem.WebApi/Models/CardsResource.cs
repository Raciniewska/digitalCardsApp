namespace AssemblyCardsSystem.WebApi.Models
{
    using AssemblyCard = Model.AssemblyCard;

    public class CardsResource
    {
        public string Id { get; set; }
        public AssemblyCard AssemblyCard { get; set; }
    }
}