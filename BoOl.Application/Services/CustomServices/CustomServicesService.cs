using BoOl.Application.Interfaces;
using BoOl.Application.Models.CustomServices;
using BoOl.Domain;
using System;
using System.Threading.Tasks;

namespace BoOl.Application.Services.CustomServices
{
    public class CustomServicesService : ICustomServicesService
    {
        private readonly ICustomServiceRepository _customServiceRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IUserRepository _userRepository;

        public CustomServicesService(ICustomServiceRepository customServicesService,
            IServiceRepository serviceRepository,
            IUserRepository userRepository)
        {
            _customServiceRepository = customServicesService;
            _serviceRepository = serviceRepository;
            _userRepository = userRepository;
        }
        public async Task<int> Create(CustomServiceDto dto, string userEmail)
        {
            var workerId = await _userRepository.GetWorkerIdByUserEmail(userEmail);
            if (workerId == null)
            {
                throw new ArgumentNullException("Користувача не знайдено.");
            }

            var price = await _serviceRepository.GetPriceById(dto.ServiceId);

            var item = new CustomService
            {
                ExecutionDate = dto.ExecutionDate,
                IsDone = dto.IsDone,
                OrderId = dto.OrderId,
                Price = price,
                ServiceId = dto.ServiceId,
                WorkerId = workerId.Value
            };

            await _customServiceRepository.AddAsync(item);
            await _customServiceRepository.SaveChanges();
            return item.Id;
        }

        public async Task<CustomServiceDto> GetById(int id)
        {
            return await _customServiceRepository.GetByIdAsync(id);
        }
        
        public async Task<CustomServiceDetailsDto> GetDetails(int id)
        {
            return await _customServiceRepository.GetDetails(id);
        }

        public async Task Update(CustomServiceDto dto)
        {
            var item = await _customServiceRepository.Get(dto.Id.Value);
            if(item == null)
            {
                throw new ArgumentNullException("Послугудо замовлення не знайдено.");
            }

            item.IsDone = dto.IsDone;
            item.ExecutionDate = dto.ExecutionDate;
            if(item.ServiceId != dto.ServiceId)
            {
                item.ServiceId = dto.ServiceId;
                item.Price = await _serviceRepository.GetPriceById(dto.ServiceId);
            }

            await _customServiceRepository.SaveChanges();
        }

        public async Task Delete(int id)
        {
            await _customServiceRepository.DeleteAsync(id);
            await _customServiceRepository.SaveChanges();
        }
    }
}
