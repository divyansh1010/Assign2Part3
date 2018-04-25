namespace Assign2part3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Game()
        {
            Descriptions = new HashSet<Description>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GameId { get; set; }

        [Column("Game")]
        [StringLength(50)]
        [Required]
        public string Game1 { get; set; }

        public int ReleaseDate { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string Developer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Description> Descriptions { get; set; }
    }
}
