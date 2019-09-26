using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Application.Entities
{
    /// <summary>
    /// Product entity with proper validation.
    /// </summary>
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is Product)
            {
                var product = obj as Product;

                return product.Name.Equals(this.Name) && product.Price == this.Price;
            }

            return false;
        }
    }
}
