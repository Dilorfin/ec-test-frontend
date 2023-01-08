import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductDetailedComponent } from './product-detailed.component';

describe('ProductDetailedComponent', () =>
{
	let component: ProductDetailedComponent;
	let fixture: ComponentFixture<ProductDetailedComponent>;

	beforeEach(async () =>
	{
		await TestBed.configureTestingModule({
			declarations: [ProductDetailedComponent]
		})
			.compileComponents();

		fixture = TestBed.createComponent(ProductDetailedComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () =>
	{
		expect(component).toBeTruthy();
	});
});
