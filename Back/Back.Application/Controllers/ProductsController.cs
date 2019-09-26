using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Back.Application.Data;
using Back.Application.Data.Repositories;
using Back.Application.Contracts.Responses;
using Back.Application.Contracts.Requests;
using Back.Application.Entities;
using Back.Application.Exceptions;

namespace Back.Application.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        /// <summary>
        /// Handles request with GET method under '/api/products' path.
        /// </summary>
        /// <returns>Response with structure as follows: 
        ///     <list type="Product">All products existing in the database</list>
        ///     <para type="string">Message with result</para>
        ///     <para type="bool">Status of requested operation</para>
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetAll();

            if(products == null)
            {
                return BadRequest(new ProductFailResponse
                {
                    Message = ResponseMessages.Unknown
                });
            }


            return Ok(new ProductSuccessResponse
            {
                Message = ResponseMessages.SucceedRequest,
                Content = products
            });
        }

        /// <summary>
        /// Handles request with GET method under '/api/products/{id}' path.
        /// </summary>
        /// <param name="id">id of product which will be deleted.</param>
        /// <returns>Response with structure as follows: 
        ///     <list type="Product">Product with specified id</list>
        ///     <para type="string">Message with result</para>
        ///     <para type="bool">Status of requested operation</para>
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {

            var product = await _productRepository.GetById(id);

            if(product != null)
            {
                return Ok(new ProductSuccessResponse
                {
                    Message = ResponseMessages.SucceedRequest,
                    Content = new Product[] { product } // Must be collection of products
                });
            }

            return BadRequest(new ProductFailResponse
            {
                Message =  ResponseMessages.NotExist
            });
        }

        /// <summary>
        /// Handles request with PUT method under '/api/products/{id}' path.
        /// </summary>
        /// <param name="id">id of product which will be updated. Must pass the attached product id</param>
        /// <param name="product">product object which with updated name/price</param>
        /// <returns>Response with structure as follows: 
        ///     <list type="Product">Empty list</list>
        ///     <para type="string">Message with result</para>
        ///     <para type="bool">Status of requested operation</para>
        /// </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest(new ProductFailResponse
                {
                    Message =  ResponseMessages.IncorrectId
                });
            }

            try
            {
                await _productRepository.Update(product);

                return Ok(new ProductSuccessResponse
                {
                    Message = ResponseMessages.SuccessfullyModified
                });
            }
            catch(DbEntityOperationException ex)
            {
                return BadRequest(new ProductFailResponse
                {
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Handles request with POST method under '/api/products/' path.
        /// </summary>
        /// <param name="product">object with two fields: name and price of new product to be saved in the database.</param>
        /// <returns>Response with structure as follows: 
        ///     <list type="Product">Empty list</list>
        ///     <para type="string">Message with result</para>
        ///     <para type="bool">Status of requested operation</para>
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequest product)
        {
            try
            {
                await _productRepository.Create(new Product
                {
                    Name = product.Name,
                    Price = product.Price
                });

                return Ok(new ProductSuccessResponse
                {
                    Message = ResponseMessages.SuccessfullyAdded
                });
            }
            catch(DbEntityOperationException ex)
            {
                return BadRequest(new ProductFailResponse
                {
                    Message = ex.Message
                });
            }
            catch(IllegalNameException ex)
            {
                return BadRequest(new ProductFailResponse
                {
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Handles request with DELETE method under '/api/products/{id}' path.
        /// </summary>
        /// <param name="id">Integer: id of product to delete.</param>
        /// <returns>Response with structure as follows: 
        ///     <list type="Product">Empty list</list>
        ///     <para type="string">Message with result</para>
        ///     <para type="bool">Status of requested operation</para>
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productRepository.Delete(id);

                return Ok(new ProductSuccessResponse
                {
                    Message = ResponseMessages.SuccessfullyDeleted
                });
            }
            catch(DbEntityOperationException ex)
            {
                return BadRequest(new ProductFailResponse
                {
                    Message = ex.Message
                });
            }
            catch(KeyNotFoundException ex)
            {
                return BadRequest(new ProductFailResponse
                {
                    Message = ex.Message
                });
            }
        }
    }
}
