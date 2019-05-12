using System;
using System.Collections.Generic;
using GeoSpatial.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GeoSpatial.DAL
{
    public class GeoSpatialContext : DbContext
    {

        public GeoSpatialContext() : base("GeoSpatialContext")
        {
        }

        public DbSet<GeoTest> GeoTests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
