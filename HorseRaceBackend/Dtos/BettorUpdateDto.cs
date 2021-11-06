namespace HorseRaceBackend.Dtos
{
    public class BettorUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Bet { get; set; }
        public int? HorseId { get; set; }
    }
}
