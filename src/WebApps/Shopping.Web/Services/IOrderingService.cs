using Shopping.Web.Models.Ordering;

namespace Shopping.Web.Services;

public interface IOrderingService
{
    [Get("/ordering-service/orders?pageIndex={pagaIndex}&pageSize={pageSize}\"")]
    Task<GetOrdersResponse> GetOrders(int? pageNumber = 1, int? pageSize = 10);

    [Get("/ordering-service/orders/name/{orederName}")]
    Task<GetOrdersByNameResponse> GetOrdersByName(string orederName);

    [Get("/ordering-service/orders/customer/{customerId}")]
    Task<GetOrdersByCustomerResponse> GetOrdersByCustomer(Guid customerId);

    
}
