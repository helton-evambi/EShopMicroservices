namespace Shopping.Web.Pages
{
    public class IndexModel(ICatalogService catalogService, ILogger<IndexModel> logger)
        : PageModel
    {
        public IEnumerable<ProductModel> ProductList { get; set; } = new List<ProductModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            logger.LogInformation("Index page visited.");
            var response = await catalogService.GetProducts();
            ProductList = response.Products;
            return Page();
        }
    }
}
