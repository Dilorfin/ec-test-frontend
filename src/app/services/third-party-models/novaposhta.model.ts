export type NovaposhtaResponse<TData> = {
	success: boolean,
	data: TData[],
	errors: string[],
	warnings: string[],
	info: string[],
	messageCodes: number[],
	errorCodes: number[],
	warningCodes: number[],
	infoCodes: number[]
}

export type NovaposhtaDimensions = {
	Width: number,
	Height: number,
	Length: number
}
export type NovaposhtaSchedule = {
	Monday: string,
	Tuesday: string,
	Wednesday: string,
	Thursday: string,
	Friday: string,
	Saturday: string,
	Sunday: string
}

export type NovaposhtaWarehouse = {
	SiteKey: string,
	Description: string,
	DescriptionRu: string,
	ShortAddress: string,
	ShortAddressRu: string,
	Phone: string,
	TypeOfWarehouse: string,
	Ref: string,
	Number: string,
	CityRef: string,
	CityDescription: string,
	CityDescriptionRu: string,
	SettlementRef: string,
	SettlementDescription: string,
	SettlementAreaDescription: string,
	SettlementRegionsDescription: string,
	SettlementTypeDescription: "місто" | "село",
	SettlementTypeDescriptionRu: "город" | "село",
	Longitude: string,
	Latitude: string,
	PostFinance: string, // Наявність каси NovaPay (1/0)
	BicycleParking: string, // Наявність паркування біля відділення (1/0)
	PaymentAccess: string, // Доступність оплати у відділенні (1/0)
	POSTerminal: string, // Наявність пос-терміналу на відділенні (1/0)
	InternationalShipping: string, // Можливість оформлення міжнародного відправлення (1/0)
	SelfServiceWorkplacesCount: string, // Наявність робочого місця самообслуговування (1/0)
	TotalMaxWeightAllowed: string, // Максимальна вага відправлення
	PlaceMaxWeightAllowed: string, // Максимальна вага одного місця відправлення
	SendingLimitationsOnDimensions: NovaposhtaDimensions,
	ReceivingLimitationsOnDimensions: NovaposhtaDimensions,
	Reception: NovaposhtaSchedule,
	Delivery: NovaposhtaSchedule,
	Schedule: NovaposhtaSchedule,
	DistrictCode: string, // Код району
	WarehouseStatus: string, // Статус відділення (e.g. Working)
	WarehouseStatusDate: string, // Дата статусу відділення
	CategoryOfWarehouse: string, // Категорія складу (???)
	Direct: string, // ???
	RegionCity: string, // Область/місто
	WarehouseForAgent: string, // Приналежність відділення до франчайзингової мережі (1/0)
	GeneratorEnabled: string, // ???
	MaxDeclaredCost: string, // Максимально допустима оціночна вартість відправлення
	WorkInMobileAwis: string, // ???
	DenyToSelect: string, // Заборона вибору складу в ІД. Допустимі значення 0\1. Якщо встановлено 1, то з/на цей склад не можна створити документ
	CanGetMoneyTransfer: string, // ???
	OnlyReceivingParcel: string, // Ознака, що відділення працює тільки на видачу, якщо значення 1, якщо 0 - то відділення працює на приймання і на видачу
	PostMachineType: string, // Тип поштомату. Допустимі значення: https://developers.novaposhta.ua/view/model/a0cf0f5f-8512-11ec-8ced-005056b2dbe1/method/a2322f38-8512-11ec-8ced-005056b2dbe1
	PostalCodeUA: string, // Поштовий індекс адреси відділення (складу) Нової Пошти
	WarehouseIndex: string // Цифрова адреса складу НП, де дані до слеша - це індекс населеного пункту, а після номер відділення/поштомату
}
