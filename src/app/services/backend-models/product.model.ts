export type ProductReviewModel = {
	id: string,
	date: string,
	userId: string,
	text: string
};

export type ProductDetailedModel = {
	id: string,
	title: string,
	imageUrl: string,
	price: number,
	description: string,
	amount: number,
	reviews: ProductReviewModel[]
};

export type ProductListModel = {
	id: string,
	title: string,
	imageUrl: string,
	price: number
};
