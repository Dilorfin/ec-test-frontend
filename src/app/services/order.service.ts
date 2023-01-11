import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OrderModel, OrderPlaceResultModel } from './backend-models/order.model';

@Injectable({
	providedIn: 'root'
})
export class OrderService
{
	constructor(private http: HttpClient) { }

	public placeOrder(order: OrderModel): Observable<OrderPlaceResultModel>
	{
		return this.http.post<OrderPlaceResultModel>('/api/order/place', order);
	}
}
