using BoOl.Application.Interfaces;
using BoOl.Application.Models.Workers;
using BoOl.Domain;
using System;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Workers
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IStorageRepository _storageRepository;
        private readonly ICustomServiceRepository _customServiceRepository;
        private readonly IUserRepository _userRepository;

        public WorkerService(IWorkerRepository workerRepository,
            IOrderRepository orderRepository,
            IStorageRepository storageRepository,
            ICustomServiceRepository customServiceRepository,
            IUserRepository userRepository)
        {
            _workerRepository = workerRepository;
            _orderRepository = orderRepository;
            _customServiceRepository = customServiceRepository;
            _storageRepository = storageRepository;
            _userRepository = userRepository;
        }

        public async Task<int> Create(WorkerDto dto)
        {
            var item = new Worker
            {
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                PhoneNumber = dto.PhoneNumber,
                DateOfBirth = dto.DateOfBirth,
                Address = dto.Address,
                Education = dto.Education,
                DateOfEmployment = dto.DateOfEmployment,
                DateOfQuit = dto.DateOfQuit,
                PositionId = dto.PositionId,
                IsActive = true
            };
            await _workerRepository.AddAsync(item);
            await _workerRepository.SaveChanges();

            return item.Id;
        }

        public async Task<WorkerDto> GetById(int id)
        {
            return await _workerRepository.GetByIdAsync(id);
        }

        public async Task Update(WorkerDto dto)
        {
            var item = await _workerRepository.Get(dto.Id.Value);

            if (item == null)
            {
                throw new ArgumentNullException("Співробітника не знайдено.");
            }

            item.Address = dto.Address;
            item.DateOfBirth = dto.DateOfBirth;
            item.FirstName = dto.FirstName;
            item.LastName = dto.LastName;
            item.MiddleName = dto.MiddleName;
            item.PhoneNumber = dto.PhoneNumber;
            item.Education = dto.Education;
            item.DateOfEmployment = dto.DateOfEmployment;
            item.DateOfQuit = dto.DateOfQuit;
            item.PositionId = dto.PositionId;

            await _workerRepository.SaveChanges();
        }

        public async Task<WorkerDetailsDto> GetDetails(int id, int orderCurrentPage, int storageCurrentPage, int customServicesCurrentPage, int pageSize)
        {
            var item = await _workerRepository.GetDetails(id);

            if (item == null)
            {
                throw new ArgumentNullException("Співробітника не знайдено.");
            }

            item.CountOfStorages = await _storageRepository.CountAsync(null, id);
            if(item.CountOfStorages > 0)
            {
                item.Storages = await _storageRepository.GetListAsync(storageCurrentPage, pageSize, null, id);
            }
            
            item.CountOfOrders = await _orderRepository.Count(null, workerId: id);
            if(item.CountOfOrders > 0)
            {
                item.Orders = await _orderRepository.GetListAsync(orderCurrentPage, pageSize, null, workerId: id);
            }

            item.CountOfCustomServices = await _customServiceRepository.CountByWorkerId(id);
            if (item.CountOfCustomServices > 0)
            {
                item.CustomServices = await _customServiceRepository.GetListAsync(customServicesCurrentPage, pageSize, workerId: id);
            }

            return item;
        }

        public async Task Delete(int id)
        {
            if (await _userRepository.ExistAccount(id))
            {
                await _userRepository.DeleteAccount(id);
            }

            if (await _customServiceRepository.ExistByWorkerId(id)
                || await _orderRepository.ExistForWorkerId(id)
                || await _storageRepository.ExistForWorkerId(id))
            {
                var item = await _workerRepository.Get(id);
                item.IsActive = false;
            }
            else
            {
                await _workerRepository.DeleteAsync(id);
            }

            await _workerRepository.SaveChanges();
        }
    }
}
