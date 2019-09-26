using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Application.Contracts.Responses
{
    public abstract class ProductResponseBase
    {
        /// <summary>
        /// This class is a base class for responses of product operations requests.
        /// </summary>
        public bool HasSucceed { get; set; }

        public ProductResponseBase(bool succeed) { HasSucceed = succeed; }
    }
}
