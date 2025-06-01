namespace AnimalService.Api.Interface
{
    public interface IAnimalData
    {
        public string Type { get; }
        public string Name { get; }
        public int AgeInYears { get; }
    }
}
