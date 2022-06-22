namespace ssttrek.Entities
{
    public class Contact: BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
        public string ContactInformation { get; set; } //lokasyon
    }
}
