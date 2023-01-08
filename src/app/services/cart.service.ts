import { Injectable } from '@angular/core';
import { ProductModel } from './products.service';

//export

export type OrderedProduct = {
	amount: number;
	model: ProductModel;
}

@Injectable({
	providedIn: 'root'
})
export class CartService
{
	private products: Map<string, OrderedProduct> = new Map<string, { amount: number, model: ProductModel }>();
	constructor() { }

	add(id: string, order: OrderedProduct): void
	{
		this.products.set(id, order);
	}
	get(id: string): OrderedProduct | undefined
	{
		return this.products.get(id);
	}
	contains(id: string): boolean
	{
		return this.products.has(id);
	}

	getAll(): OrderedProduct[]
	{
		return [...this.products.values()];
	}
}
