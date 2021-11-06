using HorseRaceBackend.Data;
using HorseRaceBackend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRaceBackend.Repositories
{
    public class BettorRepository
    {
        private readonly DataContext _dataContext;

        public BettorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Bettor>> GetBettorsAsync()
        {
            return await _dataContext.Bettors.OrderByDescending(b => b.Bet).ToListAsync();
        }

        public async Task<Bettor> GetBettorAsync(int id)
        {
            var bettor = await _dataContext.Bettors.FirstOrDefaultAsync(b => b.Id == id);
            return bettor;
        }

        public async Task<Bettor> AddBettorAsync(Bettor bettor)
        {
            _dataContext.Bettors.Add(bettor);
            await _dataContext.SaveChangesAsync();
            return bettor;
        }

        public async Task UpdateBettorAsync(Bettor bettor)
        {
            _dataContext.Bettors.Update(bettor);
            await _dataContext.SaveChangesAsync();
        }

        public async Task RemoveBettorAsync(Bettor bettor)
        {
            _dataContext.Bettors.Remove(bettor);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Bettor>> FilterByHorseId(int id)
        {
            return await _dataContext.Bettors.Where(b => b.HorseId == id).ToListAsync();
        }
    }
}
