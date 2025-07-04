namespace Shopping.Web.Pages;

public class OrderListModel(IOrderingService orderingService, ILogger<OrderListModel> logger)
    : PageModel
{
    public IEnumerable<OrderModel> Orders { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync()
    {
        // assemption customerId is passed in from the logged-in user context
        var customerId = new Guid("58c49479-ec65-4de2-86e7-033c546291aa");

        var response = await orderingService.GetOrdersByCustomer(customerId);
        Orders = response.Orders;

        return Page();
    }
}
