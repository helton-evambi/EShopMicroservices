namespace Shopping.Web.Pages;

public class ProductDetailModel
    (ICatalogService catalogService, IBasketService basketService, ILogger<ProductDetailModel> logger)
    : PageModel

{
    public ProductModel Product { get; set; } = default!;

    [BindProperty]
    public int Quantity { get; set; } = default;

    [BindProperty]
    public string Color { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid productId)
    {
        var response = await catalogService.GetProduct(productId);
        Product = response.Product;

        return Page();
    }

    public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
    {
        logger.LogInformation("Add to cart button clicked");
        var productResponse = await catalogService.GetProduct(productId);

        var basket = await basketService.LoadUserBasket();

        basket.Items.Add(new ShoppingCartItemModel
        {
            ProductId = productResponse.Product.Id,
            ProductName = productResponse.Product.Name,
            Quantity = Quantity,
            Color = Color,
            Price = productResponse.Product.Price
        });

        await basketService.StoreBasket(new StoreBasketRequest(basket));

        return RedirectToPage("Cart");

    }
}
