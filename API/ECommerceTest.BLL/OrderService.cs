using ECommerceTest.DAL.DTOs;
using ECommerceTest.DAL.IRepositories;
using ECommerceTest.ThirdParty.Payment;
using ECommerceTest.ThirdParty.Payment.DTOs;

namespace ECommerceTest.BLL;

public class OrderService : IOrderService
{
	private readonly IOrdersRepository _ordersRepository;
	private readonly IPaymentService _paymentService;

	public OrderService(IOrdersRepository ordersRepository, IPaymentService paymentService)
	{
		_ordersRepository = ordersRepository;
		_paymentService = paymentService;
	}

	public async Task<bool> ValidateOrder(OrderCreateDTO order)
	{
		return true;
	}

	public async Task<OrderCreateResultDTO> CreateOrder(OrderCreateDTO order)
	{
		if (!await ValidateOrder(order))
			return new OrderCreateResultDTO(null, null);

		Guid? orderId = await _ordersRepository.Create(order);
		if (!orderId.HasValue)
			return new OrderCreateResultDTO(null, null);

		InvoiceResultDTO invoice = null;
		switch (order.payment.type)
		{
			case OrderPaymentType.Card:
				invoice = await _paymentService.CreateInvoiceAsync(new InvoiceCreateDTO());
				break;
			case OrderPaymentType.Cash:
				break;
		}

		return new OrderCreateResultDTO(orderId, invoice);
	}
}
