using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Academy.Data.Repositories
{
    public interface ICinemaRepository
    {
        Task<IEnumerable<Item>> GetAll();
        Task<Item> Get(int id);
        Task<Item> Create(Item cinema);
        Task<Item> Put(Item cinema);
        Task Delete(Item cinema);
    }
    public class ItemRepository : ICinemaRepository
    {
        private readonly AcademyContext _FobumCinemaContext;

        public ItemRepository(AcademyContext fobumCinemaContext)
        {
            _FobumCinemaContext = fobumCinemaContext;
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _FobumCinemaContext.Item.ToListAsync();
        }

        public async Task<Item> Get(int id)
        {
            return await _FobumCinemaContext.Item.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Item> Create(Item cinema)
        {
            _FobumCinemaContext.Item.Add(cinema);
            await _FobumCinemaContext.SaveChangesAsync();

            return cinema;
        }

        public async Task<Item> Put(Item cinema)
        {
            _FobumCinemaContext.Item.Update(cinema);
            await _FobumCinemaContext.SaveChangesAsync();

            return cinema;
        }

        public async Task Delete(Item cinema)
        {
            _FobumCinemaContext.Item.Remove(cinema);
            await _FobumCinemaContext.SaveChangesAsync();
        }
    }
}
