using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForAITUCanteen.DataTransfer.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
