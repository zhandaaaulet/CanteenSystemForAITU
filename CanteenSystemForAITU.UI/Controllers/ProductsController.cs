using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CanteenSystemForAITU.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectForAITUCanteen.DataTransfer.DTO;
using ProjectForAITUCanteen.Domain.Models;
using ProjectForAITUCanteen.Domain.Repositories;

namespace CanteenSystemForAITU.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            var productToReturn = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return products != null ? (IActionResult)Ok(productToReturn) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            var productToSend = _mapper.Map<ProductDTO>(product);
            return product != null ? (IActionResult)Ok(productToSend) : NoContent();
        }

        [HttpGet("cheapest")]
        public async Task<IActionResult> GetCheapestProduct()
        {
            var product = await _productRepository.GetProductWithMinimumPrice();
            var productToSend = _mapper.Map<ProductDTO>(product);
            return product != null ? (IActionResult)Ok(productToSend) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateDTO createDto)
        {
            var product = new Item()
            {
                Id = Guid.NewGuid(),
                Name = createDto.Name,
                Price = createDto.Price,
                IsBad = createDto.IsBad
            };
            await _productRepository.AddAsync(product);
            return Ok(product.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            await _productRepository.DeleteAsync(product);
            return Ok("Removed successfully!");
        }
    }
}
