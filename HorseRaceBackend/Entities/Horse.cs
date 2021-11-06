using System.Collections.Generic;

namespace HorseRaceBackend.Entities
{
    public class Horse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Runs { get; set; } = 0;
        public int? Wins { get; set; } = 0;
        public string About { get; set; }
        public List<Bettor> Bettors { get; set; }
    }
}
