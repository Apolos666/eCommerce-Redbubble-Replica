using api.DTOs.ShippingMethodDTOs;

namespace api.Repositories.ShippingMethod;

public interface IShippingMethodRepository 
{
    Task<List<GetShippingMethod>> GetShippingMethods();
    Task<GetShippingMethod> GetShippingMethod(int id);
    Task<(Models.ShippingMethod ,GetShippingMethod)> AddShippingMethod(AddShippingMethod addShippingMethod);
}