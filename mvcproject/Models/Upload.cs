namespace mvcproject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Upload")]
    public partial class Upload
    {
        [Key]
        public Guid GuidID { get; set; }
        [Required]
        [StringLength(5)]
        public string Ext { get; set; }
        public DateTime Date { get; set; }
    }
}
