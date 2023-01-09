import { Component } from '@angular/core';
import { CartService, OrderedProduct } from '../services/cart.service';

@Component({
	selector: 'app-customer',
	templateUrl: './customer.component.html',
	styleUrls: ['./customer.component.scss']
})
export class CustomerComponent
{
	public cartCount: number = 0;

	constructor(private cartService: CartService)
	{
		this.cartService.subscribe(p => this.updateCartCount(p));
		this.updateCartCount(this.cartService.getAll());
	}

	updateCartCount(products: OrderedProduct[]): void
	{
		this.cartCount = products.length;
	}
}
