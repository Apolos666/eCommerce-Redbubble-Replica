using api.DTOs.PaymentTypeDTOs;

namespace api.Repositories.PaymentType;

public interface IPaymentTypeRepository
{
    Task<List<Models.PaymentType>> GetAllPaymentTypes();
    Task<Models.PaymentType> GetPaymentTypeById(int id);
    Task<Models.PaymentType> AddPaymentType(AddPaymentType addPaymentType);
}