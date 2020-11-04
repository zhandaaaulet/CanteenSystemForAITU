using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Infrastructure.Data;
using CanteenSystemForAITU.Infrastructure.Product;

namespace CanteenSystemForAITU.UI.Pages
{
    public class IndexModel : PageModel
    {
        private CanteenContext _ctx;

        public IndexModel(CanteenContext ctx)
        {
            _ctx = ctx;
        }
       
       

        public IEnumerable<GetProducts.ProductViewModel> Products { get; set; }
        

        public void OnGet()
        {
            Products = new GetProducts(_ctx).Do();
        }

       
    }
}
