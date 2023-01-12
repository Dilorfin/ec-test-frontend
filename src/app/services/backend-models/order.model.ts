export enum OrderPaymentType { Cash, Card };
export enum OrderDeliveryType { Pickup, NovaPoshta, UkrPoshta };

export type OrderPaymentModel = { type: OrderPaymentType };
export type OrderDeliveryModel = {
	type: OrderDeliveryType,
	destination?: string
};

export type OrderProductModel = {
	id: string,
	amount: number
};
export type OrderModel = {
	payment: OrderPaymentModel,
	delivery: OrderDeliveryModel,
	products: OrderProductModel[]
};

export type OrderPlaceResultModel = {
	orderId: string,
	invoice: {
		id: string,
		url: string
	}
};
