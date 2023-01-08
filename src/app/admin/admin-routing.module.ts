import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { SignalrExampleComponent } from './signalr-example/signalr-example.component';

const routes: Routes = [{
	path: '',
	component: AdminComponent,
	children: [
		{ path: 'signalr-example', component: SignalrExampleComponent }
	]
}];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class AdminRoutingModule { }
