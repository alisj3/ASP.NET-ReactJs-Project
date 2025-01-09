using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Repositories
{
    public class SQLWalksRepository : IWalksRepository
    {
        private readonly NZWalksDbContext _context;
        public SQLWalksRepository(NZWalksDbContext _context) 
        {
            this._context = _context;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _context.AddAsync(walk);
            await _context.SaveChangesAsync();
            
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingDomain = _context.Walks.Find(id);

            if (existingDomain == null)
            {
                return null;
            }

            _context.Walks.Remove(existingDomain);

            await _context.SaveChangesAsync();

            return existingDomain;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAcending = true)
        {
            var walks = _context.Walks.Include(x => x.Difficulty).Include(x => x.Region).AsQueryable();

            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            //Sorting
            if(string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAcending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAcending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            return await walks.ToListAsync();
        }

        public async Task<Walk?> GetOneAsync(Guid Id)
        {
            return await _context.Walks.FindAsync(Id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existing_walk = await _context.Walks.FindAsync(id);

            if (existing_walk != null)
            {
                return null;
            }

            existing_walk.Name = walk.Name;
            existing_walk.Description = walk.Description;
            existing_walk.LengthInKm = walk.LengthInKm;
            existing_walk.WalkImageUrl = walk.WalkImageUrl;
            existing_walk.DifficultyId = walk.DifficultyId;
            existing_walk.RegionId = walk.RegionId;

            await _context.SaveChangesAsync();

            return existing_walk;
        }

        public Task<Walk?> UpdtaeAsync(Guid id, Walk walk)
        {
            throw new NotImplementedException();
        }
    }
}
