using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazeClient;
namespace WazeDB
{

    // different types, motorcycle, bus, private car....
    public class DataServer : IDataServer
    {
        private List<Road> RecordedRoads { get;private set; }
        private Dictionary<int, Vehicle> OnlineVechicles { get; private set; }

        public DataServer()
        {
            RecordedRoads = new List<Road>();
            OnlineVechicles = new Dictionary<int, Vehicle>();
        }
        public List<Road> GetRoadsAroundLocation(int currentLocation)
        {
            var result = new List<Road>();
            foreach (var road in RecordedRoads)
            {
                if (road.IsCloseTo(currentLocation))
                {
                    result.Add(road);
                }
            }
            return result;
        }

        public List<Vehicle> GetVechicalesAroundLocation(int currentLocation)
        {
            var result = new List<Vehicle>();
            foreach (var vechicle in OnlineVechicles.Values)
            {
                if (vechicle.IsCloseTo(currentLocation))
                {
                    result.Add(vechicle);
                }
            }
            return result;
        }

        public SuggestedRoute GetSuggestedRoute(int currentLocation, int destination)
        {
            //for example run 2 bfs from the destination to the current location and check for an intersection point
            return new SuggestedRoute();
        }
        public void AddCarToServer(int carLicsenceNumber, Vehicle car)
        {
            if (!OnlineVechicles.ContainsKey(carLicsenceNumber))
            {
                OnlineVechicles.Add(carLicsenceNumber, car);
            }
        }
        public void RemoveCarFromServer (int carLicsenceNumber)
        {
            if(OnlineVechicles.ContainsKey(carLicsenceNumber))
            {
                OnlineVechicles.Remove(carLicsenceNumber);
            }
        }
    }
}
