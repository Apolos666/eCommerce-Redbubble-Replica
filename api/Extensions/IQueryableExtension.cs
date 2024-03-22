using api.Utilities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace api.Extensions;

public static class IQueryableExtension
{
    public static async Task<PagedResult<TResult>> CreatePagedResultsAsync<TSource, TResult>(this IQueryable<TSource> source, IConfigurationProvider autoMapperConfigurationProvider, int pageNumber, int pageSize)
    {
        var skipAmount = (pageNumber - 1) * pageSize;

        var projection = source
            .Skip(skipAmount)
            .Take(pageSize)
            .ProjectTo<TResult>(autoMapperConfigurationProvider);
        
        var totalCount = await source.CountAsync();
        var items = await projection.ToListAsync();
        
        return new PagedResult<TResult>(items, totalCount, pageNumber, pageSize);
    }
}