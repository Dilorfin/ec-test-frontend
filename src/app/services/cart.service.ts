import { Injectable } from '@angular/core';
import { ProductModel } from './backend-models/product.model';

export type OrderedProduct = {
	amount: number;
	model: ProductModel;
}

@Injectable({
	providedIn: 'root'
})
export class CartService
{
	private readonly localStorageKey: string = "shopping-cart";

	private subscribers: ((value: OrderedProduct[]) => void)[] = [];
	private products: OrderedProduct[] = [];

	constructor()
	{
		const stored = localStorage.getItem(this.localStorageKey);
		if (stored)
		{
			this.products = JSON.parse(stored);
		}
		this.subscribe(() =>
		{
			localStorage.setItem(this.localStorageKey, JSON.stringify(this.products));
		});
	}

	public add(order: OrderedProduct): void
	{
		this.products.push(order);
		this.publishEvent();
	}

	public remove(index: number): void
	{
		this.products.splice(index, 1);
		this.publishEvent();
	}
	public clear(): void
	{
		this.products = [];
		this.publishEvent();
	}

	public getAll(): OrderedProduct[]
	{
		return [...this.products.values()];
	}

	public subscribe(next: (value: OrderedProduct[]) => void): number
	{
		const oldLength: number = this.subscribers.length;
		this.subscribers.push(next);
		return oldLength;
	}
	public unsubscribe(index: number): void
	{
		this.subscribers.splice(index, 1);
	}

	private publishEvent(): void
	{
		const currentProducts: OrderedProduct[] = this.getAll();
		this.subscribers.forEach(func =>
		{
			try
			{
				func(currentProducts);
			}
			catch (error)
			{
				console.error(error);
			}
		});
	}
}
