
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanteenSystemForAITU.Infrastructure.Product
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
            Name = x.Name,
            Description = x.Description,
            Value = $"$ {x.Value:N2}", //1100.50 => 1,100.50 => $ 1,100.50
        });
        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
        }
    }

    
}
