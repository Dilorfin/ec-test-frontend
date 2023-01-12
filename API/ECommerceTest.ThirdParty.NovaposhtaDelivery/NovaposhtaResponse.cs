namespace ECommerceTest.ThirdParty.Delivery;

public record NovaposhtaResponse<TData>()
{
	public bool success { get; init; }
	public TData[] data { get; init; }
	public string[] errors { get; init; }
	public string[] warnings { get; init; }
	public dynamic info { get; init; }
	public long[] messageCodes { get; init; }
	public long[] errorCodes { get; init; }
	public long[] warningCodes { get; init; }
	public long[] infoCodes { get; init; }
}

public record NovaposhtaDimensions()
{
	public long Width { get; init; }
	public long Height { get; init; }
	public long Length { get; init; }
}
public record NovaposhtaSchedule()
{
	public string Monday { get; init; }
	public string Tuesday { get; init; }
	public string Wednesday { get; init; }
	public string Thursday { get; init; }
	public string Friday { get; init; }
	public string Saturday { get; init; }
	public string Sunday { get; init; }
}

public record NovaposhtaWarehouse()
{
	public string SiteKey { get; init; }
	public string Description { get; init; }
	public string DescriptionRu { get; init; }
	public string ShortAddress { get; init; }
	public string ShortAddressRu { get; init; }
	public string Phone { get; init; }
	public string TypeOfWarehouse { get; init; }
	public string Ref { get; init; }
	public string Number { get; init; }
	public string CityRef { get; init; }
	public string CityDescription { get; init; }
	public string CityDescriptionRu { get; init; }
	public string SettlementRef { get; init; }
	public string SettlementDescription { get; init; }
	public string SettlementAreaDescription { get; init; }
	public string SettlementRegionsDescription { get; init; }
	public string SettlementTypeDescription { get; init; }
	public string SettlementTypeDescriptionRu { get; init; }
	public string Longitude { get; init; }
	public string Latitude { get; init; }
	public string PostFinance { get; init; } // Наявність каси NovaPay (1/0)
	public string BicycleParking { get; init; } // Наявність паркування біля відділення (1/0)
	public string PaymentAccess { get; init; } // Доступність оплати у відділенні (1/0)
	public string POSTerminal { get; init; } // Наявність пос-терміналу на відділенні (1/0)
	public string InternationalShipping { get; init; } // Можливість оформлення міжнародного відправлення (1/0)
	public string SelfServiceWorkplacesCount { get; init; } // Наявність робочого місця самообслуговування (1/0)
	public string TotalMaxWeightAllowed { get; init; } // Максимальна вага відправлення
	public string PlaceMaxWeightAllowed { get; init; } // Максимальна вага одного місця відправлення
	public NovaposhtaDimensions SendingLimitationsOnDimensions { get; init; }
	public NovaposhtaDimensions ReceivingLimitationsOnDimensions { get; init; }
	public NovaposhtaSchedule Reception { get; init; }
	public NovaposhtaSchedule Delivery { get; init; }
	public NovaposhtaSchedule Schedule { get; init; }
	public string DistrictCode { get; init; }// Код району
	public string WarehouseStatus { get; init; }// Статус відділення (e.g. Working)
	public string WarehouseStatusDate { get; init; }// Дата статусу відділення
	public string CategoryOfWarehouse { get; init; }// Категорія складу (???)
	public string Direct { get; init; }// ???
	public string RegionCity { get; init; }// Область/місто
	public string WarehouseForAgent { get; init; }// Приналежність відділення до франчайзингової мережі (1/0)
	public string GeneratorEnabled { get; init; }// ???
	public string MaxDeclaredCost { get; init; }// Максимально допустима оціночна вартість відправлення
	public string WorkInMobileAwis { get; init; }// ???
	public string DenyToSelect { get; init; }// Заборона вибору складу в ІД. Допустимі значення 0\1. Якщо встановлено 1, то з/на цей склад не можна створити документ
	public string CanGetMoneyTransfer { get; init; }// ???
	public string OnlyReceivingParcel { get; init; }// Ознака, що відділення працює тільки на видачу, якщо значення 1, якщо 0 - то відділення працює на приймання і на видачу
	public string PostMachineType { get; init; }// Тип поштомату. Допустимі значення: https://developers.novaposhta.ua/view/model/a0cf0f5f-8512-11ec-8ced-005056b2dbe1/method/a2322f38-8512-11ec-8ced-005056b2dbe1
	public string PostalCodeUA { get; init; }// Поштовий індекс адреси відділення (складу) Нової Пошти
	public string WarehouseIndex { get; init; } //Цифрова адреса складу НП, де дані до слеша - це індекс населеного пункту, а після номер відділення/поштомату
}
