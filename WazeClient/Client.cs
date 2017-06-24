using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WazeClient
{
    public abstract class Vehicle
    {
        public int CurrentLocation { get; private set; } 
        protected IGps _gps;
        public Vehicle(IGps gps)
        {
            _gps = gps;
            UpdateLocation();
        }
        public void UpdateLocation()
        {
            try
            {

                CurrentLocation = _gps.GetLocation();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool IsCloseTo(int currentLocation)
        {
            //check for example if the point is up to 1 km from the current point
            return true;
        }
    }

    public class Car : Vehicle
    {
        public Car(IGps gps) :base(gps)
        {

        }
    }
    public class Road
    {
        //a road can contain all the cars you are passing by.
        //the road is usually in the color gray.
        //the road is made of points we connect together
        public List<Vehicle> Vehicles { get; private set; }
        public System.Drawing.Color RoadColor { get; set; }
        public List<Point> RoadPoints { get; set; }
        
        public Road()
        {
            Vehicles = new List<Vehicle>();
            RoadColor = System.Drawing.Color.FromName("Gray");
            RoadPoints = new List<Point>();
        }
        public bool IsCloseTo(int currentLocation)
        {
            //check for example if the point is up to 1 km from the current point
            return true;
        }
    }

    public class SuggestedRoute : Road
    {
        public SuggestedRoute()
        {
            RoadColor = System.Drawing.Color.FromName("Purple");
        }
    }


    //the map contains all the roads nearby and the suggested Route
    //Day and night colors
    public class UserMap
    {        
        public int Destination { get; set; }
        public List<Road> Roads { get; set; }
        public List<Vehicle> Vechicles { get; set; }
        public SuggestedRoute SuggestedRoute { get; set; }
        public int CurrentCarGpsLocation { get; set; }
        private IDataServer _dataServer;
        private Vehicle _currentVechicle;

        //first time you build the map you add all the car and roads near you
        public UserMap(Vehicle vehicle, IDataServer dataServer)
        {
            _currentVechicle = vehicle;
            _dataServer = dataServer;
            CurrentCarGpsLocation = _currentVechicle.CurrentLocation;
            try
            {
                Roads = _dataServer.GetRoadsAroundLocation(CurrentCarGpsLocation);
            }
            catch (Exception)
            {
                //should add here logger/error handling
                throw;
            }
            try
            {
                Vechicles = _dataServer.GetVechicalesAroundLocation(CurrentCarGpsLocation);
            }
            catch (Exception)
            {
                //should add here logger/error handling
                throw;
            }
        }

        public void UpdateLocation(int currentLocation)
        {
            //update from GPS every 2 secs...using an event..
            CurrentCarGpsLocation = _currentVechicle.CurrentLocation;
        }

        public void SetDestination(int destination)
        {
            Destination = destination;
            SuggestedRoute = _dataServer.GetSuggestedRoute(CurrentCarGpsLocation, destination);
        }
    }
}
