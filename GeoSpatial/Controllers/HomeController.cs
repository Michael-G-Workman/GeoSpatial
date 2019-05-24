using System.Data;
using System.Linq;
using System.Web.Mvc;
using GeoSpatial.Models;
using GeoSpatial.ViewModels;
using GeoSpatial.DAL;
using System.Data.Entity.Spatial;

namespace GeoSpatial.Controllers
{
    public class HomeController : Controller
    {

        // db context
        private GeoSpatialContext db = new GeoSpatialContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult License()
        {
            ViewBag.Message = "License Info";

            return View();
        }

        public ActionResult Locations()
        {
            ViewBag.Message = "Your locations page.";

            return View();
        }

        // POST: Home/Locations
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Locations([Bind(Include = "ID, Location, Latitude, Longitude, GeoPoint")] GeoTest geotest)
        {
            // build the location point string from latitude and longitude for the source location
            var sourceLocation = DbGeography.FromText("POINT(" + geotest.Longitude + " " + geotest.Latitude + ")");

            // linq query to get distances to source location and add to ViewModel
            var locationDistances = (from u in db.GeoTests
                    orderby u.GeoPoint.Distance(sourceLocation)
                    select new LocationsVM {
                    Location = u.Location,
                    Latitude = u.Latitude,
                    Longitude = u.Longitude,
                    DistanceToSourceMiles = (u.GeoPoint.Distance(sourceLocation) / (1609.344)),
                    DistanceToSourceKilometers = (u.GeoPoint.Distance(sourceLocation) / (1000))
                    });

           // ViewBag variable to pass data to view
           ViewBag.LocationDistances = locationDistances.ToArray();

            return View("LocationDistances",geotest);
        }
    }
}