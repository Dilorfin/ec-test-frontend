import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from './main-page/main-page.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ProductDetailedComponent } from './product-detailed/product-detailed.component';
import { ProductsListComponent } from './products-list/products-list.component';

const routes: Routes = [
	{ path: '', component: MainPageComponent },
	{ path: 'products-list', component: ProductsListComponent },
	{ path: 'product/:id', component: ProductDetailedComponent },
	{ path: '**', component: NotFoundComponent }
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule { }
