using BoOl.Application.Interfaces;
using BoOl.Application.Models;
using BoOl.Application.Models.Positions;
using BoOl.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Positions
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task Delete(int id)
        {
            await _positionRepository.DeleteAsync(id);
            await _positionRepository.SaveChanges();
        }

        public async Task<IList<PositionListItemDto>> GetListAsync(string filter, bool isActive)
        {
            return await _positionRepository.GetListAsync(filter, isActive);
        }

        public async Task<PositionDto> GetById(int id)
        {
            return await _positionRepository.GetById(id);
        }

        public async Task<int> Create(PositionDto dto)
        {
            var item = new Position
            {
                Name = dto.Name,
                PercentageOfWork = dto.PercentageOfWork,
                Salary = dto.Salary
            };

            await _positionRepository.AddAsync(item);
            await _positionRepository.SaveChanges();

            return item.Id;
        }

        public async Task Update(PositionDto dto)
        {
            var item = await _positionRepository.Get(dto.Id.Value);

            if (item == null)
            {
                throw new ArgumentNullException("Постачання не знайдено.");
            }

            item.Name = dto.Name;
            item.PercentageOfWork = dto.PercentageOfWork;
            item.Salary = dto.Salary;

            await _positionRepository.SaveChanges();
        }

        public async Task<IList<SelectListItem>> SelectListOfPositionsAsync()
        {
            return await _positionRepository.SelectAsync();
        }
    }
}
