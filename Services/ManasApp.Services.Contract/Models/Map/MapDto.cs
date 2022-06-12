namespace ManasApp.Services.Contract.Models.Map
{
    public class MapDto : BaseDto
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
