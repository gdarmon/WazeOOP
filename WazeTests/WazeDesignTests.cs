using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WazeClient;
using WazeDB;

namespace WazeTests
{
    [TestClass]
    public class WazeDesignTests
    {
        [TestMethod]
        public void CarTest()
        {
            Gps gps = new Gps();
            Car myCar = new Car(gps);
            DataServer server = new DataServer();
            UserMap mapByLocation = new UserMap(myCar server);
            mapByLocation.SetDestination(104410);
            Assert.AreEqual(System.Drawing.Color.FromName("Purple"), mapByLocation.SuggestedRoute.RoadColor);
        }
    }
}
