namespace ProjetVeloBackEnd.Services.Contracts.DTO.Down
{
    public class PlaceRegisterDtoDown
    {
        public required string City { get; set; }

        public required string PostalCode { get; set; }

        public required string Adress { get; set; }

        public string Name { get; set; }

        public required string Longitude { get; set; }

        public required string Latitude { get; set; }

        public required string Altitude { get; set; }
    }
}
