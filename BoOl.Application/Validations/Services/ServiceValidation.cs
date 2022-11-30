using BoOl.Application.Interfaces;
using BoOl.Application.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Services
{
    public class ServiceValidation : IServiceValidation
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ICustomServiceRepository _customServiceRepository;
        private List<string> _errors;

        public ServiceValidation(IServiceRepository serviceRepository,
            ICustomServiceRepository customServiceRepository)
        {
            _errors = new List<string>();
            _customServiceRepository = customServiceRepository;
            _serviceRepository = serviceRepository;
        }

        public async Task<string> ValidationForCreateOrUpdate(ServiceDto dto)
        {
            if(dto.Id.HasValue && !await _serviceRepository.Exist(dto.Id.Value))
            {
                _errors.Add($"Послугу з id = {dto.Id} не знайдено.");
            }

            if (await _serviceRepository.ExistWithName(dto.Name, dto.Id))
            {
                _errors.Add("Послуга з даним ім'ям вже існує в системі.");
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

            if(!await _serviceRepository.Exist(id))
            {
                _errors.Add($"Послуга з id = {id} не існує.");
            }

            if(await _customServiceRepository.ExistWithServiceId(id))
            {
                _errors.Add($"Дана послуга використовується у замовленнях, тому не може бути видалена.");
            }

            if (_errors.Count() > 0)
            {
                return string.Join(Environment.NewLine, _errors);
            }

            return null;
        }
    }
}
