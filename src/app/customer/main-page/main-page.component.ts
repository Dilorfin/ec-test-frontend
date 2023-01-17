import { Component, OnInit } from '@angular/core';
import { ProductListModel } from 'src/app/services/backend-models/product.model';
import { ProductsService } from 'src/app/services/products.service';

@Component({
	selector: 'app-main-page',
	templateUrl: './main-page.component.html',
	styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit
{
	public products: ProductListModel[] = [];

	constructor(private productsService: ProductsService) { }

	ngOnInit(): void
	{
		this.productsService.getList().subscribe({
			next: (products: ProductListModel[]) =>
			{
				this.products = products;
			},
			error: (error: any) => console.error(error)
		});
	}
}
