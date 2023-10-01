using NabucoBank.Accounts.Application.DTOs.Responses;
using NabucoBank.Accounts.Application.DTOs.Requests;

namespace NabucoBank.Accounts.Application.Interfaces
{
    public interface IBillPaymentApi
    {
        Task<BillPaymentResponseDto> CreateBillPaymentAsync(BillPaymentRequestDto request);
    }
}
