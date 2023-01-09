import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CartService } from 'src/app/services/cart.service';
import { ProductModel, ProductsService } from 'src/app/services/products.service';

@Component({
	selector: 'app-product-detailed',
	templateUrl: './product-detailed.component.html',
	styleUrls: ['./product-detailed.component.scss']
})
export class ProductDetailedComponent
{
	public product?: ProductModel;
	private productId: string;

	public amount: number = 1;

	constructor(route: ActivatedRoute, private productsService: ProductsService,
		private cartService: CartService)
	{
		this.productId = route.snapshot.params["id"];
	}

	ngOnInit(): void
	{
		this.productsService.getDetailed(this.productId).subscribe({
			next: (products: ProductModel) =>
			{
				this.product = products;
			},
			error: (error: any) => console.error(error)
		});
	}

	addToCart()
	{
		this.cartService.add({
			amount: this.amount,
			model: this.product!
		});
	}
}
