using api.Data;
using api.DTOs.Payment_DTOs.UserPaymentMethodDTOs;
using api.Extensions;
using api.Models;
using api.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Payment_Repositories.UserPaymentMethod;

public class UserPaymentMethodRepository : IUserPaymentMethodRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UserPaymentMethodRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<PagedResult<GetUserPaymentMethod>> GetAllUserPaymentMethods(
        UserPaymentMethodParameters queryParameters)
    {
        var userPaymentMethodQuery = _context.UserPaymentMethods.AsQueryable();
        
        var getUserPaymentMethodPagedResults = await userPaymentMethodQuery
            .CreatePagedResultsAsync<Models.UserPaymentMethod, GetUserPaymentMethod>(_mapper.ConfigurationProvider, queryParameters.PageNumber, queryParameters.PageSize);

        return getUserPaymentMethodPagedResults;
    }

    public async Task<GetUserPaymentMethod> GetUserPaymentMethodById(int id)
    {
        var userPaymentMethod = await _context.UserPaymentMethods.FirstOrDefaultAsync(upm => upm.Id == id);
        
        if (userPaymentMethod is null)
            return null;
        
        var getUserPaymentMethod = _mapper.Map<GetUserPaymentMethod>(userPaymentMethod);
        return getUserPaymentMethod;
    }

    public async Task<(Models.UserPaymentMethod, GetUserPaymentMethod)> AddUserPaymentMethod(AddUserPaymentMethod addUserPaymentMethod)
    {
        var userPaymentMethod = _mapper.Map<Models.UserPaymentMethod>(addUserPaymentMethod);
        var savedUserPaymentMethod = await _context.UserPaymentMethods.AddAsync(userPaymentMethod);
        await _context.SaveChangesAsync();
        var getUserPaymentMethod = _mapper.Map<GetUserPaymentMethod>(savedUserPaymentMethod.Entity);
        return (savedUserPaymentMethod.Entity, getUserPaymentMethod);
    }
}