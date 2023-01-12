import { TestBed } from '@angular/core/testing';

import { NovaposhtaService } from './novaposhta.service';

describe('NovaposhtaService', () =>
{
	let service: NovaposhtaService;

	beforeEach(() =>
	{
		TestBed.configureTestingModule({});
		service = TestBed.inject(NovaposhtaService);
	});

	it('should be created', () =>
	{
		expect(service).toBeTruthy();
	});
});
