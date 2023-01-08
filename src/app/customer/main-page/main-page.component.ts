import { Component, OnInit } from '@angular/core';

import { ProductModel, ProductsService } from 'src/app/services/products.service';

@Component({
	selector: 'app-main-page',
	templateUrl: './main-page.component.html',
	styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit
{
	public products: ProductModel[] = [];

	constructor(private productsService: ProductsService) { }

	ngOnInit(): void
	{
		this.productsService.getList().subscribe({
			next: (products: ProductModel[]) =>
			{
				this.products = products;
			},
			error: (error: any) => console.error(error)
		});
	}

	/*public products: any[] = [
		{
			id: "0",
			title: "Special Item",
			price: "$20.00",
			discountPrice: "$18.00",
			imageUrl: "https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
		},
		{
			id: "1",
			title: "Sale Item",
			price: "$50.00",
			discountPrice: "$25.00",
			imageUrl: "https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
		},
		{
			id: "42",
			title: "Fancy Product",
			price: "$40.00 - $80.00",
			discountPrice: "",
			imageUrl: "https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
		},
		{
			id: "3",
			title: "Special Item",
			price: "$20.00",
			discountPrice: "$18.00",
			imageUrl: "https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
		},
		{
			id: "5",
			title: "Sale Item",
			price: "$50.00",
			discountPrice: "$25.00",
			imageUrl: "https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
		},
		{
			id: "7",
			title: "Fancy Product",
			price: "$40.00 - $80.00",
			discountPrice: "",
			imageUrl: "https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
		},
		{
			id: "17",
			title: "Sale Item",
			price: "$50.00",
			discountPrice: "$25.00",
			imageUrl: "https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
		},
		{
			id: "141",
			title: "Fancy Product",
			price: "$40.00 - $80.00",
			discountPrice: "",
			imageUrl: "https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
		}
	];*/

}
