using System.Collections.Generic;
using BusinessLogicLayer;
using Common.Models;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Controllers
{
    /// <summary>
    /// A REST API to handle products.
    /// </summary>
    [Route("v1")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Fields

        // Logger.
        private readonly ILogger<ProductsController> logger;

        // Business logic layer.
        private readonly ProductManager productManager;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="options">The database context options.</param>
        public ProductsController(ILogger<ProductsController> logger, 
            DbContextOptions<ProductManagementSystemDBContext> options)
        {
            this.logger = logger;
            this.productManager = new ProductManager(options);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets all the products.
        /// </summary>
        /// <returns>The outcome of the process.</returns>
        [HttpGet("products")]
        public IEnumerable<Product> GetProducts()
        {
            return productManager.GetProducts();
        }

        /// <summary>
        /// Adds a product.
        /// </summary>
        /// <param name="productId">The product's data.</param>
        /// <returns>The outcome of the process.</returns>
        [HttpPost("product")]
        public ActionResult<Product> AddProduct([FromBody] ProductInput productData)
        {
            if (productData == null)
            {
                return BadRequest();
            }

            var newProduct = new Product();
            newProduct.code = 0;
            newProduct.name = productData.name;
            newProduct.price = productData.price;

            return productManager.AddProduct(newProduct);
        }

        /// <summary>
        /// Gets a product.
        /// </summary>
        /// <param name="productId">The product's id.</param>
        /// <returns>The outcome of the process.</returns>
        [HttpGet("product/{productId:int}")]
        public ActionResult<Product> GetProduct(int productId)
        {
            if (productId < 1)
            {
                return BadRequest();
            }

            var result = productManager.GetProduct(productId);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        /// <summary>
        /// Updates a product.
        /// </summary>
        /// <param name="productId">The product's id.</param>
        /// <param name="productData">The product's data.</param>
        /// <returns>The outcome of the process.</returns>
        [HttpPut("product/{productId:int}")]
        public ActionResult<Product> UpdateProduct(int productId, [FromBody] ProductInput productData)
        {
            if (productId < 1)
            {
                return BadRequest();
            }

            if (productData == null)
            {
                return BadRequest();
            }

            if (this.GetProduct(productId).Value == null)
            {
                return NotFound();
            }

            var newProduct = new Product();
            newProduct.code = 0;
            newProduct.name = productData.name;
            newProduct.price = productData.price;

            return productManager.UpdateProduct(productId, newProduct);
        }

        /// <summary>
        /// Removes a product.
        /// </summary>
        /// <param name="productId">The product's id.</param>
        /// <returns>The outcome of the process.</returns>
        [HttpDelete("product/{productId:int}")]
        public ActionResult RemoveProduct(int productId)
        {
            if (productId < 1)
            {
                return BadRequest();
            }

            if (this.GetProduct(productId).Value == null)
            {
                return NotFound();
            }

            productManager.RemoveProduct(productId);
            return Ok();
        }

        #endregion Methods
    }
}
