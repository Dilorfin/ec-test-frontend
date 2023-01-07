using ECommerceTest.DAL.DTOs;

namespace ECommerceTest.DAL;

public interface IProductsRepository
{
	Task<IEnumerable<ProductListDTO>> GetProductsAsync(uint offset, uint count);
}
