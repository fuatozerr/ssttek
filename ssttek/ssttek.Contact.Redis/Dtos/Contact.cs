namespace ssttek.Contact.Redis.Dtos
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
        public string ContactInformation { get; set; } //lokasyon
    }
}
