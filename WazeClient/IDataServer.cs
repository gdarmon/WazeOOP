using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WazeClient
{
    public interface IDataServer
    {
        List<Road> GetRoadsAroundLocation(int CurrentLocation);
        List<Vehicle> GetVechicalesAroundLocation(int CurrentLocation);
        SuggestedRoute GetSuggestedRoute(int CurrentLocation, int destination);
    }
}
