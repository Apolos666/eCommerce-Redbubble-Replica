using api.DTOs.Payment_DTOs.UserPaymentMethodDTOs;
using api.Models;
using api.Utilities;

namespace api.Repositories.Payment_Repositories.UserPaymentMethod;

public interface IUserPaymentMethodRepository
{
    Task<PagedResult<GetUserPaymentMethod>> GetAllUserPaymentMethods(UserPaymentMethodParameters queryParameters);
    Task<GetUserPaymentMethod> GetUserPaymentMethodById(int id);
    Task<(Models.UserPaymentMethod, GetUserPaymentMethod)> AddUserPaymentMethod(AddUserPaymentMethod addUserPaymentMethod);
}