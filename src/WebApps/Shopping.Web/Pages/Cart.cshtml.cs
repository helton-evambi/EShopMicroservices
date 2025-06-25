namespace Shopping.Web.Pages;

public class CartModel(ILogger<CartModel> logger, IBasketService basketService)
    : PageModel
{
    public ShoppingCartModel Cart { get; set; } = new ShoppingCartModel();
    public async Task<IActionResult> OnGetAsync()
    {
        Cart = await basketService.LoadUserBasket();

        return Page();
    }

    public async Task<IActionResult> OnPostRemoveItemAsync(Guid productId)
    {
        logger.LogInformation("Remove item from cart button clicked");

        Cart = await basketService.LoadUserBasket();

        // Remove the item from the cart
        Cart.Items.RemoveAll(item => item.ProductId == productId);
        // Store the updated cart
        await basketService.StoreBasket(new StoreBasketRequest(Cart));
        return RedirectToPage("Cart");
    }
}
