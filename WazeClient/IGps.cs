using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WazeClient
{
    public interface IGps
    {
        int GetLocation();
    }
    public class Gps : IGps
    {        
        private Random random = null;
        public Gps()
        {
            random = new Random();
        }       
        public int GetLocation()
        {
            int result = -1;
            try
            {
                result = random.Next(1000000);
            }
            catch (Exception)
            {
                throw new Exception("there was an error locating GPS info");
            }
            return result;
        }
    }
}