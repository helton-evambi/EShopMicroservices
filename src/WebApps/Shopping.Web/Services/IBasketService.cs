namespace Shopping.Web.Services;

public interface IBasketService
{
    [Get("/basket-service/basket/{userName}")]
    Task<GetBasketResponse> GetBasket(string userName);

    [Post("/basket-service/basket")]
    Task<StoreBasketResponse> StoreBasket(StoreBasketRequest request);

    [Delete("/basket-service/basket/{userName}")]
    Task<DeleteBasketResponse> DeleteBasket(string userName);

    [Post("/basket-service/basket/checkout")]
    Task<CheckoutBasketResponse> CheckoutBasket(CheckoutBasketRequest request);

    public async Task<ShoppingCartModel> LoadUserBasket()
    {
        // Get Basket If Not Exists Create new Basket with Default loged in user name
        var userName = "helton"; 
        ShoppingCartModel basket;

        try
        {
            var response = await GetBasket(userName);
            basket = response.Cart;
        }
        catch (ApiException apiException) when (apiException.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            // If basket not found, create a new one
            basket = new ShoppingCartModel { UserName = userName, Items = [] };
        }

        return basket;
    }
}
