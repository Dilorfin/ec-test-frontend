import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { UahCurrencyPipe } from './pipes/uah-currency.pipe';

@NgModule({
	declarations: [
		LoginComponent,
		UahCurrencyPipe
	],
	imports: [
		CommonModule
	],
	exports: [
		LoginComponent,
		UahCurrencyPipe
	]
})
export class SharedModule { }
