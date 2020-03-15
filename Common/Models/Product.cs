using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    /// <summary>
    /// The data transfer object for a product.
    /// </summary>
    public class Product
    {
        #region Properties

        /// <summary>
        /// The code or id for the product.
        /// </summary>
        [Key]
        [Column("product code")]
        [JsonProperty("product code")]
        public int code { get; set; }

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
