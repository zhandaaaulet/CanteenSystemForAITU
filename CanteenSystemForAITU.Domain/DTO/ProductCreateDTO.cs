using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectForAITUCanteen.DataTransfer.DTO
{
    public class ProductCreateDTO
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsBad { get; set; }
    }
}
