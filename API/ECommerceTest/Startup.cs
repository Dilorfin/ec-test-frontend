using AutoMapper;
using ECommerceTest.BLL;
using ECommerceTest.DAL.DTOs;
using ECommerceTest.DAL.IRepositories;
using ECommerceTest.DAL.Repositories;
using ECommerceTest.Models;
using ECommerceTest.Models.Order;
using ECommerceTest.ThirdParty.Payment;
using ECommerceTest.ThirdParty.Payment.DTOs;
using ECommerceTest.ThirdParty.Payment.Monobank;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(ECommerceTest.Startup))]

namespace ECommerceTest
{
	public class Startup : FunctionsStartup
	{
		public override void Configure(IFunctionsHostBuilder builder)
		{
			/*builder.Services.AddSingleton<IMyService>((s) => {
				return new MyService();
			});*/
			
			builder.Services.AddScoped<IPaymentService, MonobankPaymentService>();
			builder.Services.AddScoped<IOrderService, OrderService>();

			builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
			builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();

			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<InvoiceResultDTO, InvoiceResultModel>(); 
				cfg.CreateMap<ProductDTO, ProductListModel>(); 
				cfg.CreateMap<ProductDTO, ProductDetailedModel>();

				cfg.CreateMap<OrderCreateModel, OrderCreateDTO>()
					.ReverseMap();
				cfg.CreateMap<OrderProductModel, OrderProductDTO>()
					.ReverseMap();

				cfg.CreateMap<OrderDeliveryModel, OrderDeliveryDTO>()
					.ForMember(dst => dst.type, opt => opt.MapFrom(src => Enum.Parse<OrderDeliveryType>(src.type)));
				cfg.CreateMap<OrderPaymentModel, OrderPaymentDTO>()
					.ForMember(dst => dst.type, opt => opt.MapFrom(src => Enum.Parse<OrderPaymentType>(src.type)));

				cfg.CreateMap<OrderDeliveryDTO, OrderDeliveryModel>()
					.ForMember(dst => dst.type, opt => opt.MapFrom(src => src.type.ToString()));
				cfg.CreateMap<OrderPaymentDTO, OrderPaymentModel>()
					.ForMember(dst => dst.type, opt => opt.MapFrom(src => src.type.ToString()));
			});
			builder.Services.AddSingleton(mapperConfig.CreateMapper());
		}
	}
}
