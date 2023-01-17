import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductListModel, ProductDetailedModel } from './backend-models/product.model';

@Injectable()
export class ProductsService
{
	constructor(private http: HttpClient) { }

	public getList(): Observable<ProductListModel[]>
	{
		return this.http.get<ProductListModel[]>("/api/products/list");
	}
	public getDetailed(id: string): Observable<ProductDetailedModel>
	{
		return this.http.get<ProductDetailedModel>("/api/product/" + id);
	}
}
