using BoOl.Application.Interfaces;
using BoOl.Application.Models.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Workers
{
    public class WorkerValidation : IWorkerValidation
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IPositionRepository _positionRepository;
        private List<string> _errors;

        public WorkerValidation(IWorkerRepository workerRepository,
            IPositionRepository positionRepository)
        {
            _errors = new List<string>();
            _workerRepository = workerRepository;
            _positionRepository = positionRepository;
        }

        public async Task<string> ValidationForCreateOrUpdate(WorkerDto dto)
        {
            if (dto.Id.HasValue && !await _workerRepository.Exist(dto.Id.Value))
            {
                _errors.Add($"Співробітник з id = {dto.Id} не знайдено.");
            }

            if (await _workerRepository.ExistWithPhone(dto.PhoneNumber, dto.Id))
            {
                _errors.Add($"Співробітник з номером телефону = {dto.PhoneNumber} вже існує в системі.");
            }

            if(!await _positionRepository.Exist(dto.PositionId))
            {
                _errors.Add($"Посада не існує в системі.");
            }    

            if (_errors.Count() > 0)
            {
                return string.Join(Environment.NewLine, _errors);
            }

            return null;
        }

        public async Task<string> ValidationForDelete(int id)
        {
            if(id == default)
            {
                _errors.Add("Id не забезпечене.");
            }
            else if(!await _workerRepository.Exist(id))
            {
                _errors.Add($"Клієнта з id = {id} не знайдено.");
            }

            if (_errors.Count() > 0)
            {
                return string.Join(Environment.NewLine, _errors);
            }

            return null;
        }
    }
}
