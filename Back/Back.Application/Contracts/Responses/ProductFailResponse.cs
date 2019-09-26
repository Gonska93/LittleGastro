using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Application.Contracts.Responses
{
    public class ProductFailResponse : ProductResponseBase
    {
        /// <summary>
        /// This class contains fields with informations of failed request.
        /// </summary>
        public string Message { get; set; }
        public ProductFailResponse() : base(false) { }
    }
}
