using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppWithSQL.Models;
using WebAppWithSQL.Services;

namespace WebAppWithSQL.Pages
{
    public class IndexModel : PageModel
    {
       public List<Product> _products= new List<Product>();

        public void OnGet()
        {
            ProductService _service = new ProductService();
            _products=_service.GetProducts();
        }
    }
}