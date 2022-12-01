using BoOl.Application.Interfaces;
using BoOl.Application.Models.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Services
{
    public class StorageValidation : IStorageValidation
    {
        private readonly IStorageRepository _storageRepository;
        private readonly IModelRepository _modelRepository;
        private readonly IPartRepository _partRepository;
        private List<string> _errors;

        public StorageValidation(IStorageRepository storageRepository,
            IModelRepository modelRepository,
            IPartRepository partRepository)
        {
            _errors = new List<string>();
            _storageRepository = storageRepository;
            _modelRepository = modelRepository;
            _partRepository = partRepository;
        }

        public async Task<string> ValidationForCreateOrUpdate(StorageDto dto)
        {
            if(dto.Id.HasValue && !await _storageRepository.Exist(dto.Id.Value))
            {
                _errors.Add($"Постачання з id = {dto.Id} не знайдено.");
            }

            if(! await _modelRepository.ExistAsync(dto.ModelId))
            {
                _errors.Add($"Модель з id = {dto.ModelId} не знайдено.");
            }

            if (await _storageRepository.IsUnique(dto))
            {
                _errors.Add("Постачання вже існує в системі.");
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
            else if(!await _storageRepository.Exist(id))
            {
                _errors.Add($"Постачання з id = {id} не знайдено.");
            }
            else if(await _partRepository.ExistWithStorageId(id))
            {
                _errors.Add("Запчастини з даного постачання використовуються в замовленнях на ремонт.");
            }

            if (_errors.Count() > 0)
            {
                return string.Join(Environment.NewLine, _errors);
            }

            return null;
        }
    }
}
