using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Index() =>
            View(await _dbContext.Products.ToListAsync());

        [HttpGet]
        public async Task<ActionResult<Product>> EditProduct(int id) =>
            View(await _dbContext.Products.FirstOrDefaultAsync(product => product.Id == id));

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            _dbContext.Entry(await _dbContext.Products
                .FirstOrDefaultAsync(dbProduct => dbProduct.Id == product.Id))
                .CurrentValues.SetValues(product);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> CreateProduct()
        {
            return View("CreateProduct");
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}