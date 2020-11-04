﻿
using System;
using System.Collections.Generic;
using System.Text;
using CanteenSystemForAITU.Domain.Models;
using System.Threading.Tasks;
using Infrastructure.Data;


namespace CanteenSystemForAITU.Infrastructure.ProductsAdmin
{
    public class CreateProduct
    {
        private readonly CanteenContext _context;

        public CreateProduct(CanteenContext context)
        {
            _context = context;
        }

        public async Task<Response> Do(Request request)
        {
            var product = new Domain.Models.Product
            {

                Name = request.Name,
                Description = request.Description,
                Value = request.Value
            };
            _context.Items.Add(product);

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
