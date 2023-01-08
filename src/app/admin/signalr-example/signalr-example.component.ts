import { Component } from '@angular/core';
import * as signalR from "@microsoft/signalr";

@Component({
	selector: 'app-signalr-example',
	templateUrl: './signalr-example.component.html',
	styleUrls: ['./signalr-example.component.scss']
})
export class SignalrExampleComponent
{
	public message: string = "";

	constructor()
	{
		const apiBaseUrl = window.location.origin + '/api';

		//.withAutomaticReconnect([])
		const connection: signalR.HubConnection = new signalR.HubConnectionBuilder()
			.configureLogging(signalR.LogLevel.Information)
			.withUrl(apiBaseUrl)
			.build();

		connection.on('testEvent', (m) => this.onEvent(m));

		connection.start()
			.catch(console.error);
	}

	onEvent(message: string): void
	{
		this.message = message;
	}
}
