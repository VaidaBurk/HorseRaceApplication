using AutoMapper;
using HorseRaceBackend.Dtos;
using HorseRaceBackend.Entities;
using HorseRaceBackend.Repositories;
using System.Collections.Generic;
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

        public async Task<List<Bettor>> GetBettorsAsync()
        {
            List<Bettor> bettors = await _bettorRepository.GetBettorsAsync();
            List<BettorGetDto> mappedBettors = new();
        }


    }
}
