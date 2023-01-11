import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AboutUsComponent } from './about-us/about-us.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { CustomerComponent } from './customer.component';
import { MainPageComponent } from './main-page/main-page.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { OrderInfoComponent } from './order-info/order-info.component';
import { OrderListComponent } from './order-list/order-list.component';
import { ProductDetailedComponent } from './product-detailed/product-detailed.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { WishlistComponent } from './wishlist/wishlist.component';

const routes: Routes = [
	{
		path: '',
		component: CustomerComponent,
		children: [
			{ path: 'about-us', component: AboutUsComponent },
			{ path: 'shopping-cart', component: ShoppingCartComponent },
			{ path: 'checkout', component: CheckoutComponent },
			{ path: 'products-list', component: ProductsListComponent },
			{ path: 'product/:id', component: ProductDetailedComponent },
			{ path: 'orders-list', component: OrderListComponent },
			{ path: 'order/:id', component: OrderInfoComponent },
			{ path: 'wishlist', component: WishlistComponent },
			{ path: '', component: MainPageComponent },
			{ path: '**', component: NotFoundComponent }
		]
	}
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class CustomerRoutingModule { }
