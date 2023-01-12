import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { OrderModel, OrderProductModel, OrderPaymentType, OrderDeliveryType } from 'src/app/services/backend-models/order.model';

import { CartService, OrderedProduct } from 'src/app/services/cart.service';
import { NovaposhtaService } from 'src/app/services/novaposhta.service';
import { OrderService } from 'src/app/services/order.service';
import { NovaposhtaWarehouse } from 'src/app/services/third-party-models/novaposhta.model';

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
	public total: number;

	public novaposhtaWarehouses: NovaposhtaWarehouse[] = [];
	public novaposhtaWarehouse?: NovaposhtaWarehouse;

	constructor(private router: Router, private cartService: CartService,
		private orderService: OrderService, private novaposhtaService: NovaposhtaService)
	{
		this.products = this.cartService.getAll();

		if (this.products.length <= 0)
		{
			this.router.navigate(['shopping-cart']);
		}

		this.total = this.products.map((product) => product.amount * product.model.price).reduce((a, b) => a + b);
		this.order = {
			delivery: {
				type: OrderDeliveryType.Pickup,
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

		if(this.order.delivery.type == OrderDeliveryType.NovaPoshta && this.novaposhtaWarehouse)
		{
			this.order.delivery.destination = this.novaposhtaWarehouse.WarehouseIndex;
		}
		else
		{
			this.order.delivery.destination = undefined;
		}
	}

	public placeOrder()
	{
		this.orderService.placeOrder(this.order).subscribe({
			next: res =>
			{
				this.cartService.clear();

				if (res.invoice && res.invoice.url)
				{
					window.location.href = res.invoice.url;
				}
				else
				{
					this.router.navigate(['order/' + res.orderId]);
				}
			},
			error: error =>
			{
				console.error(error);
			}
		});
	}

	public novaposhtaSearchForWarehouse(event: Event)
	{
		const inputValue = (event.target as HTMLInputElement).value;

		if (!inputValue || inputValue.length < 3)
		{
			this.novaposhtaWarehouses = [];
			return;
		}

		this.novaposhtaService.getWarehouses(inputValue).subscribe({
			next: value =>
			{
				if (value.errors && value.errors.length > 0)
				{
					console.error(value.errors);
				}
				this.novaposhtaWarehouses = value.data;
			}
		})
	}
	public novaposhtaChooseWarehouse(warehouse: NovaposhtaWarehouse)
	{
		this.novaposhtaWarehouse = warehouse;
		this.order.delivery.destination = this.novaposhtaWarehouse.WarehouseIndex;
	}
}
