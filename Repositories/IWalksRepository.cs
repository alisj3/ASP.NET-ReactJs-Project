using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Repositories
{
    public interface IWalksRepository
    {
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAcending = true);
        Task<Walk> CreateAsync(Walk walk);
        Task<Walk?> GetOneAsync(Guid Id);
        Task<Walk?> UpdtaeAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
