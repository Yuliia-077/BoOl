using BoOl.Application.Interfaces;
using BoOl.Application.Models;
using BoOl.Application.Models.Workers;
using BoOl.Domain;
using BoOl.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Persistence.Repositories
{
    //отримання даних з бд по таблиці клієнт
    public class WorkerRepository: BaseRepository, IWorkerRepository
    {
        public WorkerRepository(IOptions<DatabaseOptions> databaseOptions, BoOlContext context) : base(databaseOptions, context) { }

        
        public async Task AddAsync(Worker item)
        {
            await Create<Worker>(item);
        }

        public async Task<bool> Exist(int id)
        {
            return await DbContext.Workers.Where(x => x.Id == id).AnyAsync();
        }

        public async Task<bool> ExistWithPhone(string phone, int? id = null)
        {
            return await DbContext.Workers.Where(x => x.PhoneNumber == phone && x.Id != id).AnyAsync();
        }

        public async Task<bool> ExistForPositionId(int positionId)
        {
            return await DbContext.Workers.AnyAsync(x => x.PositionId == positionId);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await Get(id);
            if(item != null)
            {
                DbContext.Workers.Remove(item);
            }
        }

        public async Task<WorkerDto> GetByIdAsync(int id)
        {
            var item = await DbContext.Workers.SingleOrDefaultAsync(c => c.Id == id);

            if (item == null)
            {
                return null;
            }

            return new WorkerDto
            {
                Id = item.Id,
                LastName = item.LastName,
                FirstName = item.FirstName,
                MiddleName = item.MiddleName,
                PhoneNumber = item.PhoneNumber,
                DateOfBirth = item.DateOfBirth,
                Address = item.Address,
                Education = item.Education,
                DateOfEmployment = item.DateOfEmployment,
                DateOfQuit = item.DateOfQuit
            };
        }

        public Task<Worker> Get(int id)
        {
            return Get<Worker>(id);
        }

        public async Task<WorkerDetailsDto> GetDetails(int id)
        {
            return await DbContext.Workers
                .Where(x => x.Id == id)
                .Select(item => new WorkerDetailsDto
                {
                    Id = item.Id,
                    LastName = item.LastName,
                    FirstName = item.FirstName,
                    MiddleName = item.MiddleName,
                    PhoneNumber = item.PhoneNumber,
                    DateOfBirth = item.DateOfBirth,
                    Address = item.Address,
                    Education = item.Education,
                    DateOfEmployment = item.DateOfEmployment,
                    DateOfQuit = item.DateOfQuit,
                    IsActive = item.IsActive,
                    PositionId = item.PositionId,
                    PositionName = item.Position.Name,
                    Salary = item.Position.Salary,
                    PercentageOfWork = item.Position.PercentageOfWork,
                    Email = item.User.Email
                })
                .SingleOrDefaultAsync();
        }
    }
}
