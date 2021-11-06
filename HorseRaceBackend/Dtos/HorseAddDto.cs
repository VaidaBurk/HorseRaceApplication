namespace HorseRaceBackend.Dtos
{
    public class HorseAddDto
    {
        public string Name { get; set; }
        public int? Runs { get; set; } = 0;
        public int? Wins { get; set; } = 0;
        public string About { get; set; }
    }
}
