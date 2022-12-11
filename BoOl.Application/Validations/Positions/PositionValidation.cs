using BoOl.Application.Interfaces;
using BoOl.Application.Models.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Positions
{
    public class PositionValidation : IPositionValidation
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IWorkerRepository _workerRepository;
        private List<string> _errors;

        public PositionValidation(IPositionRepository positionRepository,
            IWorkerRepository workerRepository)
        {
            _errors = new List<string>();
            _positionRepository = positionRepository;
            _workerRepository = workerRepository;
        }

        public async Task<string> ValidationForCreateOrUpdate(PositionDto dto)
        {
            if(dto.Id != null && !await _positionRepository.Exist(dto.Id.Value))
            {
                _errors.Add($"Посаду з id = {dto.Id} не знайдено.");
            }

            if (await _positionRepository.ExistByName(dto.Name, dto.Id))
            {
                _errors.Add("Посада з даним ім'ям вже існує в системі.");
            }

            if (_errors.Count() > 0)
            {
                return string.Join(Environment.NewLine, _errors);
            }

            return null;
        }

        public async Task<string> ValidationForDelete(int id)
        {
            if (!await _positionRepository.Exist(id))
            {
                _errors.Add($"Модель з id = {id} не знайдено.");
            }
            else if (await _workerRepository.ExistForPositionId(id))
            {
                _errors.Add($"Є працівники, які прив'язані до даної посади.");
            }
           
            if (_errors.Count() > 0)
            {
                return string.Join(Environment.NewLine, _errors);
            }

            return null;
        }
    }
}
