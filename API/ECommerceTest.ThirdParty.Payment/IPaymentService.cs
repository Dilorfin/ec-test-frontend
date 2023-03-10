using ECommerceTest.ThirdParty.Payment.DTOs;

namespace ECommerceTest.ThirdParty.Payment;

public interface IPaymentService
{
	Task<InvoiceResultDTO> CreateInvoiceAsync(InvoiceCreateDTO invoiceCreateDTO);
}
