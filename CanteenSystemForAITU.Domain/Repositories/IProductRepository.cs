using CanteenSystemForAITU.Domain.Models;
using Domain.Repositories;
using ProjectForAITUCanteen.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForAITUCanteen.Domain.Repositories
{
    public interface IProductRepository : IEntityRepository<Item>
    {
        Task<Item> GetProductWithMinimumPrice();
    }
}
