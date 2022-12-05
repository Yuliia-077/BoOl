using BoOl.Application.Interfaces;
using BoOl.Application.Models;
using BoOl.Application.Models.Storages;
using BoOl.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Storages
{
    public class StorageService : IStorageService
    {
        private readonly IStorageRepository _storageRepository;
        private readonly IUserRepository _userRepository;

        public StorageService(IStorageRepository storageRepository,
            IUserRepository userRepository)
        {
            _storageRepository = storageRepository;
            _userRepository = userRepository;
        }

        public async Task<IList<StorageListItemDto>> GetListItems(int currentPage, int pageSize, string searchString)
        {
            return await _storageRepository.GetListAsync(currentPage, pageSize, searchString);
        }

        public async Task<int> Count(string searchString)
        {
            return await _storageRepository.CountAsync(searchString);
        }

        public async Task<int> Create(StorageDto dto, string userEmail)
        {
            var workerId = await _userRepository.GetWorkerIdByUserEmail(userEmail);
            if(workerId == null)
            {
                throw new ArgumentNullException("Користувача не знайдено.");
            }

            var item = new Storage
            {
                Name = dto.Name,
                Manufacturer = dto.Manufacturer,
                Quantity = dto.Quantity,
                PurchasePrice = dto.PurchasePrice,
                WholesalePrice = dto.WholesalePrice,
                RetailPrice = dto.RetailPrice,
                DateOfArrival = DateTime.Now,
                ModelId = dto.ModelId,
                WorkerId = workerId.Value
            };
            await _storageRepository.AddAsync(item);
            await _storageRepository.SaveChanges();

            return item.Id;
        }

        public async Task Update(StorageDto dto)
        {
            var item = await _storageRepository.Get(dto.Id.Value);

            if (item == null)
            {
                throw new ArgumentNullException("Користувача не знайдено.");
            }

            item.Name = dto.Name;
            item.Manufacturer = dto.Manufacturer;
            item.Quantity = dto.Quantity;
            item.PurchasePrice = dto.PurchasePrice;
            item.WholesalePrice = dto.WholesalePrice;
            item.RetailPrice = dto.RetailPrice;
            item.ModelId = dto.ModelId;

            await _storageRepository.SaveChanges();
        }

        public async Task<StorageDto> GetById(int id)
        {
            return await _storageRepository.GetByIdAsync(id);
        }

        public async Task<StorageDetailsDto> GetDetails(int id)
        {
            return await _storageRepository.GetDetailsAsync(id);
        }

        public async Task Delete(int id)
        {
            await _storageRepository.DeleteAsync(id);
        }

        public async Task<IList<SelectListItem>> SelectAsync()
        {
            return await _storageRepository.SelectAsync();
        }
    }
}
