import { Component } from '@angular/core';
import { CartService, OrderedProduct } from 'src/app/services/cart.service';
import { OrderService } from 'src/app/services/order.service';

@Component({
	selector: 'app-shopping-cart',
	templateUrl: './shopping-cart.component.html',
	styleUrls: ['./shopping-cart.component.scss']
})
export class ShoppingCartComponent
{
	public products: OrderedProduct[];

	constructor(private cartService: CartService, private orderService: OrderService)
	{
		this.products = this.cartService.getAll();
		this.cartService.subscribe(p => this.updateProducts(p));
	}

	public checkout()
	{
		this.orderService.placeOrder(this.cartService.getAll()).subscribe({
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

	public removeFromCart(id: number)
	{
		this.cartService.remove(id);
	}

	private updateProducts(products: OrderedProduct[]): void
	{
		this.products = products;
	}
}
