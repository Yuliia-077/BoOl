using BoOl.Application.Interfaces;
using BoOl.Application.Models.Parts;
using BoOl.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Parts
{
    public class PartValidation : IPartValidation
    {
        private readonly ICustomServiceRepository _customServiceRepository;
        private readonly IStorageRepository _storageRepository;
        private readonly IPartRepository _partRepository;

        private List<string> _errors;

        public PartValidation(ICustomServiceRepository customServiceRepository,
            IStorageRepository storageRepository,
            IPartRepository partRepository)
        {
            _errors = new List<string>();
            _customServiceRepository = customServiceRepository;
            _storageRepository = storageRepository;
            _partRepository = partRepository;
        }

        public async Task<string> ValidationForCreateOrUpdate(PartDto dto)
        {
            if (dto.Id != null && !await _partRepository.Exist(dto.Id.Value))
            {
                _errors.Add($"Запчастину з id = {dto.Id} не знайдено.");
            }
            else
            {
                if(await _partRepository.ExistWithSerailNumber(dto.SerialNumber, dto.Id))
                {
                    _errors.Add($"Запчастину з серійним номером = {dto.SerialNumber} вже існує.");
                }
                if (!await _customServiceRepository.Exist(dto.CustomServiceId))
                {
                    _errors.Add($"Послуга до замовлення з id = {dto.Id} не знайдено.");
                }
                else if(await _customServiceRepository.IsDone(dto.CustomServiceId))
                {
                    _errors.Add($"Не можна додати запчастину до зробленої послуги.");
                }

                if (!await _storageRepository.Exist(dto.StorageId))
                {
                    _errors.Add($"Постачання з id = {dto.StorageId} не знайдено.");
                }
                else
                {
                    var modelId = await _storageRepository.GetModuleId(dto.StorageId);
                    if(!await _customServiceRepository.ExistServiceForModule(dto.CustomServiceId, modelId))
                    {
                        _errors.Add($"Модель техніки в постачанні з замовленні не однакова.");
                    }
                }
                
            } 

            if (_errors.Count() > 0)
            {
                return string.Join(Environment.NewLine, _errors.Select(x => x));
            }

            return null;
        }
    }
}
