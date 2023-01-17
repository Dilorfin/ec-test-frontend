import { UahCurrencyPipe } from './uah-currency.pipe';

describe('UahCurrencyPipe', () =>
{
	it('create an instance', () =>
	{
		const pipe = new UahCurrencyPipe();
		expect(pipe).toBeTruthy();
	});
});
