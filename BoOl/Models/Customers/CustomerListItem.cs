using BoOl.Application.Models.Customers;

namespace BoOl.Models.Customers
{
    public class CustomerListItem
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static CustomerListItem AsViewModel(this CustomerListItemDto dto)
        {
            return new CustomerListItem
            {
                Id = dto.Id,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email
            };
        }
    }
}
