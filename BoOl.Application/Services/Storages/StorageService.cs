using BoOl.Application.Interfaces;
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

        public StorageService(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }

        public async Task<IList<StorageListItemDto>> GetListItems(int currentPage, int pageSize, string searchString)
        {
            return await _storageRepository.GetListAsync(currentPage, pageSize, searchString);
        }

        public async Task<int> Count(string searchString)
        {
            return await _storageRepository.CountAsync(searchString);
        }

        public async Task<int> Create(StorageDto dto)
        {
            var item = new Storage
            {
                //LastName = dto.LastName,
                //FirstName = dto.FirstName,
                //MiddleName = dto.MiddleName,
                //PhoneNumber = dto.PhoneNumber,
                //DateOfBirth = dto.DateOfBirth,
                //Address = dto.Address,
                //Email = dto.Email,
                //Discount = dto.Discount
            };
            await _storageRepository.AddAsync(item);
            await _storageRepository.SaveChanges();

            return item.Id;
        }

        public async Task<StorageDto> GetById(int id)
        {
            return await _storageRepository.GetByIdAsync(id);
        }

        public async Task Update(StorageDto dto)
        {
            var item = await _storageRepository.Get(dto.Id);

            if (item == null)
            {
                throw new ArgumentNullException("Користувача не знайдено.");
            }

            //item.Address = dto.Address;
            //item.DateOfBirth = dto.DateOfBirth;
            //item.Discount = dto.Discount;
            //item.Email = dto.Email;
            //item.FirstName = dto.FirstName;
            //item.LastName = dto.LastName;
            //item.MiddleName = dto.MiddleName;
            //item.PhoneNumber = dto.PhoneNumber;

            await _storageRepository.SaveChanges();
        }
    }
}
