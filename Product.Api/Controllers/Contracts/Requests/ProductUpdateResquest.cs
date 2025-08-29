﻿using System.ComponentModel.DataAnnotations;

namespace ProductManager.Api.Controllers.Contracts.Requests
{
    public class ProductUpdateResquest
    {
        [Required]
        public string Id { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
