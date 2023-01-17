import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
	name: 'uahCurrency'
})
export class UahCurrencyPipe implements PipeTransform
{
	transform(value: number, currencyCode: string = 'UAH', display: any = 'symbol',
		digitsInfo: string = '1.2-2', locale: string = 'en'): string | null
	{
		return `${value/100}₴`
		/*formatCurrency(
			value,
			locale,
			getCurrencySymbol(currencyCode, 'narrow'),
			currencyCode,
			digitsInfo
		);*/
	}
}
