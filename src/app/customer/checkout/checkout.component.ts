import { Component } from '@angular/core';
import { OrderModel, OrderProductModel, OrderPaymentType, OrderDeliveryType } from 'src/app/services/backend-models/order.model';

import { CartService, OrderedProduct } from 'src/app/services/cart.service';
import { OrderService } from 'src/app/services/order.service';

@Component({
	selector: 'app-checkout',
	templateUrl: './checkout.component.html',
	styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent
{
	public readonly OrderPaymentType = OrderPaymentType;
	public readonly OrderDeliveryType = OrderDeliveryType;
	
	public products: OrderedProduct[];
	public order: OrderModel;
	
	constructor(private cartService: CartService, private orderService: OrderService)
	{
		// TODO: check if it's working on returning to page
		this.products = this.cartService.getAll();

		this.order = {
			delivery: {
				type: OrderDeliveryType.Pickup
			},
			payment: {
				type: OrderPaymentType.Card
			},
			products: this.products.map<OrderProductModel>((op: OrderedProduct) =>
			{
				return {
					id: op.model.id,
					amount: op.amount
				}
			})
		};
	}

	public choosePaymentType(paymentType: OrderPaymentType)
	{
		this.order.payment.type = paymentType;
	}

	public chooseDeliveryType(deliveryType: OrderDeliveryType)
	{
		this.order.delivery.type = deliveryType;
	}

	public checkout()
	{
		this.orderService.placeOrder(this.order).subscribe({
			next: res =>
			{
				this.cartService.clear();
				console.log(res);
				if (res.invoice.url)
				{
					window.location.href = res.invoice.url;
				}
			},
			error: error =>
			{
				console.error(error);
			}
		});
	}
}
