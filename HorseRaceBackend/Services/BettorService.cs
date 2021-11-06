using AutoMapper;
using HorseRaceBackend.Dtos;
using HorseRaceBackend.Entities;
using HorseRaceBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRaceBackend.Services
{
    public class BettorService
    {
        private readonly BettorRepository _bettorRepository;
        private readonly HorseRepository _horseRepository;
        private readonly IMapper _mapper;

        public BettorService(BettorRepository bettorRepository, HorseRepository horseRepository, IMapper mapper)
        {
            _bettorRepository = bettorRepository;
            _horseRepository = horseRepository;
            _mapper = mapper;
        }

        public async Task<List<BettorForRenderingDto>> GetBettorsAsync()
        {
            List<Bettor> bettors = await _bettorRepository.GetBettorsAsync();
            List<BettorForRenderingDto> mappedBettors = new();
            List<Horse> horses = await _horseRepository.GetHorsesAsync();

            foreach (var bettor in bettors)
            {
                BettorForRenderingDto mappedBettor = new()
                {
                    Id = bettor.Id,
                    FirstName = bettor.FirstName,
                    LastName = bettor.LastName,
                    Bet = bettor.Bet,
                    HorseId = bettor.HorseId != null ? bettor.HorseId : null,
                    HorseName = bettor.HorseId != null ? horses.FirstOrDefault(h => h.Id == bettor.HorseId).Name.ToString() : ""
                };
                mappedBettors.Add(mappedBettor);
            }
            return mappedBettors;
        }

        public async Task<Bettor> GetBettorAsync(int id)
        {
            var bettor = await _bettorRepository.GetBettorAsync(id);
            if (bettor == null)
            {
                throw new ArgumentException($"Id {id} does not exist.");
            }
            return bettor;
        }

        public async Task<BettorForRenderingDto> AddBettorAsync(BettorAddDto newBettor)
        {
            Bettor bettor = _mapper.Map<Bettor>(newBettor);
            Bettor bettorWithId = await _bettorRepository.AddBettorAsync(bettor);

            Horse horse = await _horseRepository.GetHorseAsync((int)bettorWithId.HorseId);
            string horseName = horse.Name;

            BettorForRenderingDto bettorForRendering = new()
            {
                Id = bettorWithId.Id,
                FirstName = bettorWithId.FirstName,
                LastName = bettorWithId.LastName,
                Bet = bettorWithId.Bet,
                HorseId = bettorWithId.HorseId,
                HorseName = horseName
            };

            return bettorForRendering;
        }

        public async Task<BettorForRenderingDto> UpdateBettorAsync(BettorUpdateDto updatedBettor)
        {
            var bettor = await _bettorRepository.GetBettorAsync(updatedBettor.Id);
            if (bettor == null)
            {
                throw new ArgumentException($"Id {updatedBettor.Id} does not exist.");
            }

            bettor.Id = updatedBettor.Id;
            bettor.FirstName = updatedBettor.FirstName;
            bettor.LastName = updatedBettor.LastName;
            bettor.Bet = updatedBettor.Bet;
            bettor.HorseId = updatedBettor.HorseId;

            //Bettor mappedBettor = _mapper.Map<Bettor>(updatedBettor);
            await _bettorRepository.UpdateBettorAsync(bettor);

            Horse horse = await _horseRepository.GetHorseAsync((int)updatedBettor.HorseId);
            string horseName = horse.Name;

            BettorForRenderingDto bettorForRendering = new()
            {
                Id = updatedBettor.Id,
                FirstName = updatedBettor.FirstName,
                LastName = updatedBettor.LastName,
                Bet = updatedBettor.Bet,
                HorseId = updatedBettor.HorseId,
                HorseName = horseName
            };

            return bettorForRendering;
        }

        public async Task RemoveBettorAsync(int id)
        {
            var bettor = await _bettorRepository.GetBettorAsync(id);
            if (bettor == null)
            {
                throw new ArgumentException($"Id {id} does not exist.");
            }

            await _bettorRepository.RemoveBettorAsync(bettor);
        }

        public async Task<List<BettorForRenderingDto>> FilterByHorseId(int id)
        {
            if (id != 0)
            {
                List<Bettor> filteredBettors = await _bettorRepository.FilterByHorseId(id);
                List<BettorForRenderingDto> mappedFilteredBettors = new();
                Horse horse = await _horseRepository.GetHorseAsync(id);
                string horseName = horse.Name;

                foreach (var bettor in filteredBettors)
                {
                    BettorForRenderingDto mappedBettor = new()
                    {
                        Id = bettor.Id,
                        FirstName = bettor.FirstName,
                        LastName = bettor.LastName,
                        Bet = bettor.Bet,
                        HorseId = bettor.HorseId,
                        HorseName = horseName
                    };
                    mappedFilteredBettors.Add(mappedBettor);
                }
                return mappedFilteredBettors;
            }
            return await GetBettorsAsync();
        }


    }
}
