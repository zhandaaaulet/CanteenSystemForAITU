
using System;
using System.Collections.Generic;
using System.Text;
using CanteenSystemForAITU.Domain.Models;
using System.Threading.Tasks;
using Infrastructure.Data;
using System.Linq;

namespace CanteenSystemForAITU.Infrastructure.ProductsAdmin
{
    public class UpdateProduct
    {
        private CanteenContext _context;

        public UpdateProduct(CanteenContext context)
        {
            _context = context;
        }

        public async Task<Response> Do(Request request)
        {
            var product = _context.Items.FirstOrDefault(x => x.Id == request.Id);
            product.Name = request.Name;
            product.Description = request.Description;
            product.Value = request.Value;

            await _context.SaveChangesAsync();
            return new Response
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Value = product.Value
            };
        }

        public class Request
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
    }
    


}
