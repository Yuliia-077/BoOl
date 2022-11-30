using BoOl.Application.Interfaces;
using BoOl.Application.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Models
{
    public class ModelValidation : IModelValidation
    {
        private readonly IModelRepository _modelRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStorageRepository _storageRepository;
        private List<string> _errors;

        public ModelValidation(IModelRepository modelRepository,
            IStorageRepository storageRepository,
            IProductRepository productRepository)
        {
            _errors = new List<string>();
            _modelRepository = modelRepository;
            _productRepository = productRepository;
            _storageRepository = storageRepository;
        }

        public async Task<string> ValidationForCreateOrUpdate(ModelDto dto)
        {
            if(dto.Id != null && !await _modelRepository.ExistAsync(dto.Id.Value))
            {
                _errors.Add($"Модель з id = {dto.Id} не знайдено.");
            }

            if (await _modelRepository.ExistWithManufacturerAndName(dto.Manufacturer, dto.Type, dto.Id))
            {
                _errors.Add("Модель з даним ім'ям і виробником вже існує в системі.");
            }

            if (_errors.Count() > 0)
            {
                return string.Join(Environment.NewLine, _errors);
            }

            return null;
        }

        public async Task<string> ValidationForDelete(int id)
        {
            if (!await _modelRepository.ExistAsync(id))
            {
                _errors.Add($"Модель з id = {id} не знайдено.");
            }
            if (await _storageRepository.ExistItemsWithModelsInStorage(id))
            {
                _errors.Add($"На складі є запчастини, які прив'язані до цієї моделі, видаліть спершу їх.");
            }
            if (await _productRepository.ExistItemsWithModel(id))
            {
                _errors.Add($"Є техніка, що прив'язана до даної моделі, видаліть спершу її.");
            }

            if (_errors.Count() > 0)
            {
                return string.Join(Environment.NewLine, _errors);
            }

            return null;
        }
    }
}
