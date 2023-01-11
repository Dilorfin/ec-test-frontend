import { Component } from '@angular/core';
import { CartService, OrderedProduct } from 'src/app/services/cart.service';

@Component({
	selector: 'app-shopping-cart',
	templateUrl: './shopping-cart.component.html',
	styleUrls: ['./shopping-cart.component.scss']
})
export class ShoppingCartComponent
{
	public products: OrderedProduct[];

	constructor(private cartService: CartService)
	{
		this.products = this.cartService.getAll();
		this.cartService.subscribe(p => this.updateProducts(p));
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
