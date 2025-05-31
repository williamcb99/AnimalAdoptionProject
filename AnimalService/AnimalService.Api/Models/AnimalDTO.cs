namespace AnimalService.Api.Models
{
    public class AnimalDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int AgeInYears { get; set; }
    }
}
