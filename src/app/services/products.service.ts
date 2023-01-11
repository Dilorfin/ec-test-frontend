import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductModel } from './backend-models/product.model';

// TODO: wtf???
export { ProductModel } from './backend-models/product.model';

@Injectable()
export class ProductsService
{
	constructor(private http: HttpClient) { }

	public getList(): Observable<ProductModel[]>
	{
		return this.http.get<ProductModel[]>("/api/products/list");
	}
	public getDetailed(id: string): Observable<ProductModel>
	{
		return this.http.get<ProductModel>("/api/product/" + id);
	}
}
