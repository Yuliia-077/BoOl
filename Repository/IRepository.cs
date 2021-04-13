using BoOl.Models;
using BoOl.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Repository
{
    interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync(int? id);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T t);
        Task UpdateAsync(T t);
        Task DeleteAsync(int id);
        Task<int> CountAsync(int? id);
        Task<IEnumerable<SelectedModel>> SelectAsync();
    }
}
