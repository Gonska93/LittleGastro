using Back.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Application.Contracts.Responses
{
    /// <summary>
    /// This class contains fields with informations of succeed request.
    /// </summary>
    public class ProductSuccessResponse : ProductResponseBase
    {
        public string Message { get; set; }
        public IEnumerable<Product> Content { get; set; }

        public ProductSuccessResponse() : base(true) { }
    }
}
