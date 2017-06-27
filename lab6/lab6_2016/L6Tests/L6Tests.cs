using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using L6;

namespace L6Tests
{
    [TestClass]
    public class L6Tests
    {
        [TestMethod]
        public void E1_TestEquality()
        {
            Unit Zergling = new Unit("Zergling", "Spawning Pool", "Zerg");
            Unit CarbotZergling = new Unit("Zergling", "Spawning Pool", "Zerg");
            Assert.AreEqual(Zergling, CarbotZergling);
        }

        [TestMethod]
        public void E1_TestUnitName()
        {
            Unit Zergling = new Unit("Zergling", "Spawning Pool", "Zerg");
            Assert.AreEqual("Zergling", Zergling.Name);
        }

        [TestMethod]
        public void E1_TestUnitBuilding()
        {
            Unit Zergling = new Unit("Zergling", "Spawning Pool", "Zerg");
            Assert.AreEqual("Spawning Pool", Zergling.GetBuildingName());
        }

        [TestMethod]
        public void E1_TestUnitRace()
        {
            Unit Zergling = new Unit("Zergling", "Spawning Pool", "Zerg");
            Assert.AreEqual("Zerg", Zergling.GetRaceName());
        }

        [TestMethod]
        public void E1_TestUnitRaceWrong()
        {
            Unit Zergling = new Unit("Zergling", "Spawning Pool", "Zerg");
            Assert.AreNotEqual("Protoss", Zergling.GetRaceName());
        }

        [TestMethod]
        public void E1_TestUnitBuildingWrong()
        {
            Unit Zergling = new Unit("Zergling", "Spawning Pool", "Zerg");
            Assert.AreNotEqual("Zergling", Zergling.GetBuildingName());
        }

        [TestMethod]
        public void E1_TestBuildingRace()
        {
            L6.L6 l6 = new L6.L6();
            Building SpawningPool = new Building("Spawning Pool", "Zerg");
            Assert.AreEqual("Zerg", SpawningPool.GetRaceName());
        }

        [TestMethod]
        public void E1_TestBuildingRaceWrong()
        {
            L6.L6 l6 = new L6.L6();
            Building SpawningPool = new Building("Spawning Pool", "Zerg");
            Assert.AreNotEqual("Protoss", SpawningPool.GetRaceName());
        }

        [TestMethod]
        public void E2_TestAddBuilding()
        {
            L6.L6 l6 = new L6.L6();
            Building SpawningPool = new Building("Spawning Pool", "Zerg");
            l6.SetRace(new Race("Zerg"));
            Assert.AreEqual(true, l6.AddBuilding(SpawningPool));
        }

        [TestMethod]
        public void E2_TestAddBuildings()
        {
            L6.L6 l6 = new L6.L6();
            Building SpawningPool = new Building("Spawning Pool", "Zerg");
            Building RoachWarren = new Building("Roach Warren", "Zerg");
            l6.SetRace(new Race("Zerg"));
            l6.AddBuilding(SpawningPool);
            l6.AddBuilding(RoachWarren);
            Assert.AreEqual(2, l6.Buildings.Count);
        }

        [TestMethod]
        public void E2_TestAddBuildingTwice()
        {
            L6.L6 l6 = new L6.L6();
            Building SpawningPool = new Building("Spawning Pool", "Zerg");
            l6.SetRace(new Race("Zerg"));
            l6.AddBuilding(SpawningPool);
            Assert.AreEqual(false, l6.AddBuilding(SpawningPool));
        }

        [TestMethod]
        public void E2_TestAddBuildingNoRace()
        {
            L6.L6 l6 = new L6.L6();
            Building SpawningPool = new Building("Spawning Pool", "Zerg");
            Assert.AreEqual(null, l6.AddBuilding(SpawningPool));
        }

        [TestMethod]
        public void E2_TestAddBuildingWrongRace()
        {
            L6.L6 l6 = new L6.L6();
            Building SpawningPool = new Building("Spawning Pool", "Zerg");
            l6.SetRace(new Race("Protoss"));
            Assert.AreEqual(null, l6.AddBuilding(SpawningPool));
        }

        [TestMethod]
        public void E2_TestAddBuildingNoContraints()
        {
            L6.L6 l6 = new L6.L6();
            Building SpawningPool = new Building("Spawning Pool", "Zerg");
            Building Gateway = new Building("Gateway", "Protoss");
            l6.SetRace(new Race("Zerg"));
            l6.AddBuilding(SpawningPool);
            Assert.AreEqual(true, l6.AddBuildingIgnoreConstraints(Gateway));
        }

        [TestMethod]
        public void E3_TestAddUnit()
        {
            L6.L6 l6 = new L6.L6();
            Building SpawningPool = new Building("Spawning Pool", "Zerg");
            Unit Zergling = new Unit("Zergling", "Spawning Pool", "Zerg");
            l6.SetRace(new Race("Zerg"));
            l6.AddBuilding(SpawningPool);
            Assert.AreEqual(true, l6.AddUnit(Zergling));
        }

        [TestMethod]
        public void E3_TestAddUnits()
        {
            L6.L6 l6 = new L6.L6();
            Building SpawningPool = new Building("Spawning Pool", "Zerg");
            Building RoachWarren = new Building("Roach Warren", "Zerg");
            Unit Zergling = new Unit("Zergling", "Spawning Pool", "Zerg");
            Unit Roach = new Unit("Roach", "Roach Warren", "Zerg");
            l6.SetRace(new Race("Zerg"));
            l6.AddBuilding(SpawningPool);
            l6.AddBuilding(RoachWarren);
            l6.AddUnit(Zergling);
            l6.AddUnit(Roach);
            Assert.AreEqual(2, l6.Units.Count);
        }

        [TestMethod]
        public void E3_TestAddUnitTwice()
        {
            L6.L6 l6 = new L6.L6();
            Building SpawningPool = new Building("Spawning Pool", "Zerg");
            Unit Zergling = new Unit("Zergling", "Spawning Pool", "Zerg");
            l6.SetRace(new Race("Zerg"));
            l6.AddBuilding(SpawningPool);
            l6.AddUnit(Zergling);
            Assert.AreEqual(false, l6.AddUnit(Zergling));
        }

        [TestMethod]
        public void E3_TestAddUnitNoBuilding()
        {
            L6.L6 l6 = new L6.L6();
            Building SpawningPool = new Building("Spawning Pool", "Zerg");
            Unit Zergling = new Unit("Zergling", "Spawning Pool", "Zerg");
            l6.SetRace(new Race("Zerg"));
            l6.AddUnit(Zergling);
            Assert.AreEqual(null, l6.AddUnit(Zergling));
        }

        [TestMethod]
        public void E3_TestAddUnitNoRace()
        {
            L6.L6 l6 = new L6.L6();
            Building SpawningPool = new Building("Spawning Pool", "Zerg");
            Unit Zergling = new Unit("Zergling", "Spawning Pool", "Zerg");
            l6.AddUnit(Zergling);
            Assert.AreEqual(null, l6.AddUnit(Zergling));
        }

        [TestMethod]
        public void E3_TestAddUnitNullUnit()
        {
            L6.L6 l6 = new L6.L6();
            Building SpawningPool = new Building("Spawning Pool", "Zerg");
            Unit Zergling = new Unit("Zergling", "Spawning Pool", "Zerg");
            l6.SetRace(new Race("Zerg"));
            Assert.AreEqual(null, l6.AddUnit(null));
        }

        [TestMethod]
        public void E3_TestAreUnitsSameRace()
        {
            L6.L6 l6 = new L6.L6();
            Building SpawningPool = new Building("Spawning Pool", "Zerg");
            Building RoachWarren = new Building("Roach Warren", "Zerg");
            Unit Zergling = new Unit("Zergling", "Spawning Pool", "Zerg");
            Unit Roach = new Unit("Roach", "Roach Warren", "Zerg");
            l6.SetRace(new Race("Zerg"));
            l6.AddBuilding(SpawningPool);
            l6.AddBuilding(RoachWarren);
            l6.AddUnit(Zergling);
            l6.AddUnit(Roach);
            Assert.AreEqual(true, l6.AreUnitsSameRace());
        }

        [TestMethod]
        public void E3_TestAreUnitsSameRaceFalse()
        {
            L6.L6 l6 = new L6.L6();
            Building SpawningPool = new Building("Spawning Pool", "Zerg");
            Building RoachWarren = new Building("Roach Warren", "Zerg");
            Unit Zergling = new Unit("Zergling", "Spawning Pool", "Zerg");
            Unit Zealot = new Unit("Zealot", "Gateway", "Protoss");
            l6.SetRace(new Race("Zerg"));
            l6.AddBuilding(SpawningPool);
            l6.AddBuilding(RoachWarren);
            l6.AddUnit(Zergling);
            l6.AddUnitIgnoreConstraints(Zealot);
            Assert.AreEqual(false, l6.AreUnitsSameRace());
        }

        [TestMethod]
        public void E3_TestAreUnitsSameRaceEmptyUnits()
        {
            L6.L6 l6 = new L6.L6();
            Building SpawningPool = new Building("Spawning Pool", "Zerg");
            Building RoachWarren = new Building("Roach Warren", "Zerg");
            Unit Zergling = new Unit("Zergling", "Spawning Pool", "Zerg");
            Unit Roach = new Unit("Roach", "Roach Warren", "Zerg");
            l6.SetRace(new Race("Zerg"));
            l6.AddBuilding(SpawningPool);
            l6.AddBuilding(RoachWarren);
            Assert.AreEqual(null, l6.AreUnitsSameRace());
        }
    }
}
