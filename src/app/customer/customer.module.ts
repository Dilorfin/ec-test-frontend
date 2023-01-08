import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerRoutingModule } from './customer-routing.module';
import { AboutUsComponent } from './about-us/about-us.component';
import { MainPageComponent } from './main-page/main-page.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ProductDetailedComponent } from './product-detailed/product-detailed.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { WishlistComponent } from './wishlist/wishlist.component';
import { CustomerComponent } from './customer.component';

@NgModule({
	declarations: [
		ProductDetailedComponent,
		MainPageComponent,
		ProductsListComponent,
		NotFoundComponent,
		AboutUsComponent,
		ShoppingCartComponent,
		WishlistComponent,
		CustomerComponent
	],
	imports: [
		CommonModule,
		CustomerRoutingModule
	],
	bootstrap: [CustomerComponent]
})
export class CustomerModule { }
