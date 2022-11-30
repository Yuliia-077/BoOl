using BoOl.Application.Models;
using BoOl.Domain;
using BoOl.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Repository
{
    //отримання даних з бд по таблиці посади
    public class PositionRepository: IRepository<Position>
    {
        private BoOlContext _context;

        public PositionRepository(BoOlContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Position t)
        {
            await _context.Positions.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Position position = await GetByIdAsync(id);
            if (position != null)
            {
                _context.Positions.Remove(position);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Position>> GetAllAsync(int? id)
        {
            return await _context.Positions.Include(p => p.Workers).OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Position> GetByIdAsync(int id)
        {
            return await _context.Positions.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Position t)
        {
            if (t != null)
            {
                _context.Positions.Update(t);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> CountAsync(int? id)
        {
            return await _context.Positions.CountAsync();
        }

        public async Task<IEnumerable<SelectedModel>> SelectAsync(int? id)
        {
            var positionsList = await _context.Positions.Select(
               x => new { Value = x.Id, Text = x.Name }).ToListAsync();
            List<SelectedModel> models = new List<SelectedModel>();

            foreach (var item in positionsList)
            {
                models.Add(new SelectedModel(item.Value, item.Text));
            }
            return models;
        }
    }
}
