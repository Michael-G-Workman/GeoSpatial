using System;
using System.ComponentModel.DataAnnotations;

namespace GeoSpatial.ViewModels
{
    public class LocationsVM
    {
        [MaxLength(100)]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [MaxLength(50)]
        [Display(Name = "Latitude")]
        public string Latitude { get; set; }

        [MaxLength(50)]
        [Display(Name = "Longitude")]
        public string Longitude { get; set; }

        [Display(Name = "Distance To Source (Miles)")]
        public Nullable<double> DistanceToSourceMiles { get; set; }

        [Display(Name = "Distance To Source (Kilometers)")]
        public Nullable<double> DistanceToSourceKilometers { get; set; }
    }
}