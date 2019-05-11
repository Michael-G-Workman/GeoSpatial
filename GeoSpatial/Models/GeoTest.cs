using System;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoSpatial.Models
{
    [Table("GeoTest", Schema = "dbo")]
    public class GeoTest
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(100)]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [MaxLength(50)]
        [Display(Name = "Latitude")]
        public string Latitude { get; set; }

        [MaxLength(50)]
        [Display(Name = "Longitude")]
        public string Longitude { get; set; }

        [Display(Name = "GeoPoint")]
        public DbGeography GeoPoint { get; set; }

    }
}