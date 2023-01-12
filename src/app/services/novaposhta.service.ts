import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NovaposhtaResponse, NovaposhtaWarehouse } from './third-party-models/novaposhta.model';

@Injectable()
export class NovaposhtaService
{
	private readonly apiUrl = "https://api.novaposhta.ua/v2.0/json/";
	constructor(private http: HttpClient) { }

	public getWarehouses(searchString: string): Observable<NovaposhtaResponse<NovaposhtaWarehouse>>
	{
		const searchModel = {
			modelName: "Address",
			calledMethod: "getWarehouses",
			methodProperties: {
				FindByString: searchString,
				Limit: 10
			}
		}

		return this.http.post<NovaposhtaResponse<NovaposhtaWarehouse>>(this.apiUrl, searchModel);
	}
}
