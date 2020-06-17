namespace mvcproject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class mdlUploadImages : DbContext
    {
        public mdlUploadImages() : base("name=mdlUploadImages") { }

        public virtual DbSet<Upload> Uploads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Upload>()
                .Property(e => e.Ext)
                .IsUnicode(false);
        }
    }
}
