
using System;
using System.Collections.Generic;
using System.Text;
using CanteenSystemForAITU.Domain.Models;
using System.Threading.Tasks;
using System.Linq;
using Infrastructure.Data;

namespace CanteenSystemForAITU.Infrastructure.ProductsAdmin
{
    public class DeleteProduct
    {
        private CanteenContext _context;

        public DeleteProduct(CanteenContext context)
        {
            _context = context;
        }

        public async Task<bool> Do(int id)
        {
            var Product = _context.Items.FirstOrDefault(x => x.Id == id);
            _context.Items.Remove(Product);
            await _context.SaveChangesAsync();
            return true;
        }

      
    }
   


}
