
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanteenSystemForAITU.Infrastructure.ProductsAdmin
{
    public class GetProducts
    {
        private CanteenContext _ctx;

        public GetProducts(CanteenContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ProductViewModel> Do() => _ctx.Items.ToList().Select(x => new ProductViewModel

        {
            Id = x.Id,
            Name = x.Name, 
            /*Value = x.Value,*/
            
        });
        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            /*public decimal Value { get; set; }*/
            
        }
    }

    
}
