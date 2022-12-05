using BoOl.Application.Interfaces;
using BoOl.Application.Models.Parts;
using BoOl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Parts
{
    public class PartService : IPartService
    {
        private readonly IPartRepository _partRepository;
        private readonly IStorageRepository _storageRepository;

        public PartService(IPartRepository partRepository,
            IStorageRepository storageRepository)
        {
            _partRepository = partRepository;
            _storageRepository = storageRepository;
        }

        public async Task<int> Count(int customServiceId)
        {
            return await _partRepository.Count(customServiceId);
        }

        public async Task Delete(int id)
        {
            await _partRepository.DeleteAsync(id);
            await _partRepository.SaveChanges();
        }

        public async Task DeleteWithReturnToStorage(int id)
        {
            var storageId = await _partRepository.GetStorageId(id);

            var item = await _storageRepository.Get(storageId);
            item.Quantity++;
            await _storageRepository.SaveChanges();

            await Delete(id);
        }

        public async Task<IList<PartDto>> GetListAsync(int customServiceId, int currentPage, int pageSize)
        {
            return await _partRepository.GetListAsync(customServiceId, currentPage, pageSize);
        }

        public async Task<int> Create(PartDto dto)
        {
            var item = new Part
            {
                Id = dto.Id,
                IsInjured = dto.IsInjured,
                SerialNumber = dto.SerialNumber,
                StorageId = dto.StorageId,
                CustomServiceId = dto.CustomServiceId
            };

            await _partRepository.AddAsync(item);
            var storage = await _storageRepository.Get(dto.StorageId);
            storage.Quantity--;
            await _storageRepository.SaveChanges();

            return item.Id;
        }
    }
}
