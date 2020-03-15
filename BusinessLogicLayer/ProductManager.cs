using Common.Models;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer
{
    /// <summary>
    /// The business logic to handle products.
    /// </summary>
    public class ProductManager
    {
        #region Fields

        // The database context to the ProductManagementSystem database.
        private readonly ProductManagementSystemDBContext productManagementSystemDBContext;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="options">The database context options.</param>
        public ProductManager(DbContextOptions<ProductManagementSystemDBContext> options)
        {
            this.productManagementSystemDBContext = new ProductManagementSystemDBContext(options);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets all the products.
        /// </summary>
        /// <returns>The outcome of the process.</returns>
        public IEnumerable<Product> GetProducts()
        {
            return productManagementSystemDBContext.Products.AsEnumerable();
        }

        /// <summary>
        /// Adds a product.
        /// </summary>
        /// <param name="productId">The product's data.</param>
        /// <returns>The outcome of the process.</returns>
        public Product AddProduct(Product productData)
        {
            productManagementSystemDBContext.Products.Add(productData);
            productManagementSystemDBContext.SaveChanges();

            return productData;
        }

        /// <summary>
        /// Gets a product.
        /// </summary>
        /// <param name="productId">The product's id.</param>
        /// <returns>The outcome of the process.</returns>
        public Product GetProduct(int productId)
        {
            return productManagementSystemDBContext.Products.FirstOrDefault(x => x.code == productId);
        }

        /// <summary>
        /// Updates a product.
        /// </summary>
        /// <param name="productId">The product's id.</param>
        /// <param name="productData">The product's data.</param>
        /// <returns>The outcome of the process.</returns>
        public Product UpdateProduct(int productId, Product productData)
        {
            var product = productManagementSystemDBContext.Products.FirstOrDefault(x => x.code == productId);

            if (product == null)
            {
                return null;
            }

            product.name = productData.name;
            product.price = productData.price;
            productManagementSystemDBContext.SaveChanges();

            return product;
        }

        /// <summary>
        /// Removes a product.
        /// </summary>
        /// <param name="productId">The product's id.</param>
        /// <returns>The outcome of the process.</returns>
        public void RemoveProduct(int productId)
        {
            var product = productManagementSystemDBContext.Products.FirstOrDefault(x => x.code == productId);
            productManagementSystemDBContext.Products.Remove(product);
            productManagementSystemDBContext.SaveChanges();
        }

        #endregion Methods
    }
}
