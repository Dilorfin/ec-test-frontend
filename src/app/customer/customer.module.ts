import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { CustomerRoutingModule } from './customer-routing.module';
import { AboutUsComponent } from './about-us/about-us.component';
import { MainPageComponent } from './main-page/main-page.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ProductDetailedComponent } from './product-detailed/product-detailed.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { WishlistComponent } from './wishlist/wishlist.component';
import { CustomerComponent } from './customer.component';
import { ProductsService } from '../services/products.service';
import { CartService } from '../services/cart.service';
import { OrderService } from '../services/order.service';
import { CheckoutComponent } from './checkout/checkout.component';
import { OrderInfoComponent } from './order-info/order-info.component';
import { OrderListComponent } from './order-list/order-list.component';
import { NovaposhtaService } from '../services/novaposhta.service';
import { SharedModule } from '../shared/shared.module';

@NgModule({
	declarations: [
		ProductDetailedComponent,
		MainPageComponent,
		ProductsListComponent,
		NotFoundComponent,
		AboutUsComponent,
		ShoppingCartComponent,
		WishlistComponent,
		CustomerComponent,
		CheckoutComponent,
		OrderInfoComponent,
		OrderListComponent
	],
	imports: [
		SharedModule,
		CommonModule,
		FormsModule,
		HttpClientModule,
		CustomerRoutingModule
	],
	providers: [
		CartService,
		OrderService,
		ProductsService,
		NovaposhtaService
	],
	bootstrap: [CustomerComponent]
})
export class CustomerModule { }
