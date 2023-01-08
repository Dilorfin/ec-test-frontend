import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignalrExampleComponent } from './signalr-example.component';

describe('SignalrExampleComponent', () =>
{
	let component: SignalrExampleComponent;
	let fixture: ComponentFixture<SignalrExampleComponent>;

	beforeEach(async () =>
	{
		await TestBed.configureTestingModule({
			declarations: [SignalrExampleComponent]
		})
			.compileComponents();

		fixture = TestBed.createComponent(SignalrExampleComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () =>
	{
		expect(component).toBeTruthy();
	});
});
