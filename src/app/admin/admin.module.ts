import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { SignalrExampleComponent } from './signalr-example/signalr-example.component';

@NgModule({
	declarations: [
		AdminComponent,
		SignalrExampleComponent
	],
	imports: [
		CommonModule,
		AdminRoutingModule
	]
})
export class AdminModule { }
