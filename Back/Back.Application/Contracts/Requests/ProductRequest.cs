using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Application.Contracts.Requests
{
    /// <summary>
    /// Request structure for creating or updating products.
    /// </summary>
    public class ProductRequest
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [Range(0, 1000)]
        public decimal Price { get; set; }
    }
}
