using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementSystem.Models
{
    /// <summary>
    /// The input data for a product.
    /// </summary>
    public class ProductInput
    {
        #region Properties

        /// <summary>
        /// The product's name.
        /// </summary>
        [Required]
        [Column("name")]
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// The product's price.
        /// </summary>
        [Required]
        [Column("price")]
        [JsonProperty("price")]
        public decimal price { get; set; }

        #endregion Properties
    }
}
