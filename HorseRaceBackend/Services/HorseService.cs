using AutoMapper;
using HorseRaceBackend.Dtos;
using HorseRaceBackend.Entities;
using HorseRaceBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorseRaceBackend.Services
{
    public class HorseService
    {
        private readonly HorseRepository _horseRepository;
        private readonly IMapper _mapper;

        public HorseService(HorseRepository horseRepository, IMapper mapper)
        {
            _horseRepository = horseRepository;
            _mapper = mapper;
        }

        public async Task<List<Horse>> GetHorsesAsync()
        {
            return await _horseRepository.GetHorsesAsync();
        }

        public async Task<Horse> GetHorseAsync(int id)
        {
            var horse = await _horseRepository.GetHorseAsync(id);
            if (horse == null)
            {
                throw new ArgumentException($"Id {id} does not exist.");
            }
            return horse;
        }

        public async Task<Horse> AddHorseAsync(HorseAddDto newHorse)
        {
            if (newHorse.Wins > newHorse.Runs)
            {
                throw new ArgumentException("More wins than runs");
            }
            Horse horse = _mapper.Map<Horse>(newHorse);
            Horse horseWithId = await _horseRepository.AddHorseAsync(horse);
            return horseWithId;
        }

        public async Task UpdateHorseAsync(HorseUpdateDto updatedHorse)
        {
            Horse horse = await _horseRepository.GetHorseAsync(updatedHorse.Id);

            if (horse == null)
            {
                throw new ArgumentNullException($"Id {updatedHorse.Id} does not exist.");
            }
            if (updatedHorse.Wins > updatedHorse.Runs)
            {
                throw new ArgumentException("More wins than runs");
            }

            horse.Id = updatedHorse.Id;
            horse.Name = updatedHorse.Name;
            horse.Runs = updatedHorse.Runs;
            horse.Wins = updatedHorse.Wins;
            horse.About = updatedHorse.About;

            await _horseRepository.UpdateHorseAsync(horse);
        }

        public async Task RemoveHorseAsync(int id)
        {
            Horse horse = await _horseRepository.GetHorseAsync(id);

            if (horse == null)
            {
                throw new ArgumentException("Id does not exist.");
            }

            await _horseRepository.RemoveHorseAsync(horse);
        }
    }
}
