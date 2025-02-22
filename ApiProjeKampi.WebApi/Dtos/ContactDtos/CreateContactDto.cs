namespace ApiProjeKampi.WebApi.Dtos.ContactDtos
{
    public class CreateContactDto
    {
     
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string MapLocation { get; set; }
        public string Adress { get; set; }
        public string OpeningHours { get; set; }
    }
}
