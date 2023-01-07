using ECommerceTest.ThirdParty.Payment.DTOs;

namespace ECommerceTest.ThirdParty.Payment;

public interface IPaymentService
{
	Task<InvoiceDTO> CreateInvoiceAsync(Uri redirectUri, Uri callbackUri);
}
