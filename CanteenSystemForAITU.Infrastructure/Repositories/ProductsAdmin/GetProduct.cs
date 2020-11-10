
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanteenSystemForAITU.Infrastructure.ProductsAdmin
{
    public class GetProduct
    {
        private CanteenContext _ctx;

        public GetProduct(CanteenContext ctx)
        {
            _ctx = ctx;
        }

        public ProductViewModel Do(int id) => _ctx.Items.Where(x => x.Id == id).Select(x => new ProductViewModel

        {
            Name = x.Name,
            Description = x.Description,
            /*Value = x.Value */
        }).FirstOrDefault();

    }

    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        /*public decimal Value { get; set; }*/
    }
}
