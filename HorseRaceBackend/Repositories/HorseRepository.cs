using HorseRaceBackend.Data;
using HorseRaceBackend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRaceBackend.Repositories
{
    public class HorseRepository
    {
        private readonly DataContext _dataContext;

        public HorseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Horse>> GetHorsesAsync()
        {
            return await _dataContext.Horses.OrderBy(h => h.Name).ToListAsync();
        }

        public async Task<Horse> GetHorseAsync(int id)
        {
            var horse = await _dataContext.Horses.FirstOrDefaultAsync(h => h.Id == id);
            return horse;
        }

        public async Task<Horse> AddHorseAsync(Horse horse)
        {
            _dataContext.Horses.Add(horse);
            await _dataContext.SaveChangesAsync();
            return horse;
        }

        public async Task UpdateHorseAsync(Horse horse)
        {
            _dataContext.Horses.Update(horse);
            await _dataContext.SaveChangesAsync();
        }

        public async Task RemoveHorseAsync(Horse horse)
        {
            _dataContext.Horses.Remove(horse);
            await _dataContext.SaveChangesAsync();
        }
    }
}
