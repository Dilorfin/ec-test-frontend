using ECommerceTest.DAL.DTOs;

namespace ECommerceTest.DAL;

public interface IProductsRepository
{
	Task<ProductDTO> GetProductAsync(string id);

	Task<IEnumerable<ProductDTO>> GetProductsAsync(uint offset, uint count);
}
