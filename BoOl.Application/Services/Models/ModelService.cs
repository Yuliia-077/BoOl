using BoOl.Application.Interfaces;
using BoOl.Application.Models;
using BoOl.Application.Models.Models;
using BoOl.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Models
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task<IList<ModelListItemDto>> GetListItems(int currentPage, int pageSize, string searchString)
        {
            return await _modelRepository.GetListAsync(currentPage, pageSize, searchString);
        }

        public async Task<int> Count(string searchString)
        {
            return await _modelRepository.CountAsync(searchString);
        }

        public async Task<int> Create(ModelDto dto)
        {
            var item = new Model
            {
                Manufacturer = dto.Manufacturer,
                Type = dto.Type
            };
            await _modelRepository.AddAsync(item);
            await _modelRepository.SaveChanges();

            return item.Id;
        }

        public async Task<ModelDto> GetById(int id)
        {
            return await _modelRepository.GetByIdAsync(id);
        }

        public async Task Update(ModelDto dto)
        {
            var item = await _modelRepository.Get(dto.Id.Value);

            if (item == null)
            {
                throw new ArgumentNullException($"Модель з id = {dto.Id} не знайдено.");
            }

            item.Manufacturer = dto.Manufacturer;
            item.Type = dto.Type;

            await _modelRepository.SaveChanges();
        }

        public async Task Delete(int id)
        {
            await _modelRepository.DeleteAsync(id);
            await _modelRepository.SaveChanges();
        }

        public async Task<IEnumerable<SelectListItem>> SelectListOfModelsAsync()
        {
            return await _modelRepository.SelectListOfModelsAsync();
        }
    }
}
