import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OrderedProduct } from './cart.service';

type OrderPaymentModel = { type: number };
type OrderDeliveryModel = { type: number };

type OrderProductModel = {
	id: string,
	amount: number
};
type OrderModel = {
	payment: OrderPaymentModel,
	delivery: OrderDeliveryModel,
	products: OrderProductModel[]
};

export type OrderPlaceResult = {
	orderId: string,
	invoice: {
		id: string,
		url: string
	}
};

@Injectable({
	providedIn: 'root'
})
export class OrderService
{
	constructor(private http: HttpClient) { }

	public placeOrder(cart: OrderedProduct[]): Observable<OrderPlaceResult>
	{
		let order: OrderModel = {
			delivery: {
				type: 0
			},
			payment: {
				type: 1
			},
			products: cart.map<OrderProductModel>((op: OrderedProduct) =>
			{
				return {
					id: op.model.id,
					amount: op.amount
				}
			})
		};

		return this.http.post<OrderPlaceResult>('/api/order/place', order);
	}

}
