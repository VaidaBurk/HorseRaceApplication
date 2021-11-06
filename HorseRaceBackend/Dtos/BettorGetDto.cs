namespace HorseRaceBackend.Dtos
{
    public class BettorGetDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Bet { get; set; }
        public int? HorseId { get; set; }
        public string HorseName { get; set; }
    }
}
