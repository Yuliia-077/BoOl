using BoOl.Application.Interfaces;
using BoOl.Application.Models.CustomServices;
using BoOl.Application.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.CustomServices
{
    public class CustomServiceValidation : ICustomServiceValidation
    {
        private readonly ICustomServiceRepository _customServiceRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IServiceRepository _serviceRepository;

        private List<string> _errors;

        public CustomServiceValidation(ICustomServiceRepository customServiceRepository,
            IServiceRepository serviceRepository,
            IOrderRepository orderRepository)
        {
            _errors = new List<string>();
            _customServiceRepository = customServiceRepository;
            _orderRepository = orderRepository;
            _serviceRepository = serviceRepository;
        }

        public async Task<string> ValidationForCreateOrUpdate(CustomServiceDto dto)
        {
            if (dto.Id != null && !await _customServiceRepository.Exist(dto.Id.Value))
            {
                _errors.Add($"Послуга до замовлення з id = {dto.Id} не знайдено.");
            }
            else
            {
                if(!await _orderRepository.Exist(dto.OrderId))
                {
                    _errors.Add($"Замовлення з id = {dto.OrderId} не знайдено.");
                }
                else
                {
                    var order = await _orderRepository.GetById(dto.OrderId);
                    if(order.Status == Status.Complete)
                    {
                        _errors.Add($"Замовлення завершено, тому до нього не може бути додана послуга.");
                    }
                    if(order.DateOfAdmission >= dto.ExecutionDate)
                    {
                        _errors.Add($"Дата виконання не може бути меншою, ніж дата прийому замовлення.");
                    }
                }

                if(!await _serviceRepository.Exist(dto.ServiceId))
                {
                    _errors.Add($"Послуга з id = {dto.ServiceId} не знайдено.");
                }
            } 

            if (_errors.Count() > 0)
            {
                return string.Join("\n", _errors.Select(x => x));
            }

            return null;
        }
    }
}
