namespace Assign2part3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Description")]
    public partial class Description
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DescId { get; set; }

        public int Game { get; set; }

        [Column("Description")]
        [StringLength(250)]
        public string Description1 { get; set; }

        [StringLength(50)]
        public string Protagonist { get; set; }

        public int Price { get; set; }

        public int Rating { get; set; }

        public virtual Game Game1 { get; set; }

        public static object AsQueryable()
        {
            throw new NotImplementedException();
        }
    }
}
