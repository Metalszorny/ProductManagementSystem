using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models
{
    /// <summary>
    /// The database context for the ProductManagementSystem database.
    /// </summary>
    public partial class ProductManagementSystemDBContext : DbContext
    {
        #region Properties

        /// <summary>
        /// Gets or sets the value the products data table.
        /// </summary>
        /// <value>
        /// The new value for the products data table.
        /// </value>
        public virtual DbSet<Product> Products { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductManagementSystemDBContext"/> class.
        /// </summary>
        public ProductManagementSystemDBContext()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductManagementSystemDBContext"/> class.
        /// </summary>
        /// <param name="options">The database context options.</param>
        public ProductManagementSystemDBContext(DbContextOptions<ProductManagementSystemDBContext> options)
            : base(options)
        { }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Set fluent API for the ORM.
        /// </summary>
        /// <param name="modelBuilder">The module builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.code);
                entity.Property(e => e.code).HasColumnName("Code");

                entity.Property(e => e.name).HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(int.MaxValue)
                    .IsUnicode(true);

                entity.Property(d => d.price).HasColumnName("Price")
                    .IsRequired();
            });
        }

        #endregion Methods
    }
}
