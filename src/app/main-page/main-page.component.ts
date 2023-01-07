import { Component } from '@angular/core';

@Component({
	selector: 'app-main-page',
	templateUrl: './main-page.component.html',
	styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent
{
	public products : any[] = [
		{
			title: "Special Item",
			price: "$20.00",
			discountPrice: "$18.00",
			imageUrl: "https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
		},
		{
			title: "Sale Item",
			price: "$50.00",
			discountPrice: "$25.00",
			imageUrl: "https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
		}
	]
}
