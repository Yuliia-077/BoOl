using BoOl.Application.Interfaces;
using BoOl.Application.Models.Services;
using BoOl.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IList<ServiceListItemDto>> GetListItems(int currentPage, int pageSize, string searchString)
        {
            return await _serviceRepository.GetListAsync(currentPage, pageSize, searchString);
        }

        public async Task<int> Count(string searchString)
        {
            return await _serviceRepository.CountAsync(searchString);
        }

        public async Task<int> Create(ServiceDto dto)
        {
            var item = new Service
            {
                Name = dto.Name,
                Price = dto.Price
            };
            await _serviceRepository.AddAsync(item);
            await _serviceRepository.SaveChanges();

            return item.Id;
        }

        public async Task<ServiceDto> GetById(int id)
        {
            return await _serviceRepository.GetByIdAsync(id);
        }

        public async Task Update(ServiceDto dto)
        {
            var item = await _serviceRepository.Get(dto.Id.Value);

            if (item == null)
            {
                throw new ArgumentNullException($"Послуга з id = {dto.Id} не знайдено.");
            }

            item.Name = dto.Name;
            item.Price = dto.Price;

            await _serviceRepository.SaveChanges();
        }

        public async Task Delete(int id)
        {
            await _serviceRepository.DeleteAsync(id);
            await _serviceRepository.SaveChanges();
        }

        public async Task<IList<ServiceListItemDto>> MostPopularServices(int pageSize)
        {
            return await _serviceRepository.MostPopularServices(pageSize);
        }
    }
}
