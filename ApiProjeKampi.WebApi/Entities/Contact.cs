namespace ApiProjeKampi.WebApi.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string MapLocation { get; set; }
        public string Adress { get; set; }
        public string OpeningHours { get; set; }
    }
}
