using NUnit.Framework;
using System.Diagnostics;
using System.Reflection;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Factory factory;

        [SetUp]
        public void Setup()
        {
            factory = new Factory("Divite", 3);
        }

        [Test]
        public void ConstructorWorksCorrectly()
        {
            Assert.AreEqual(factory.Name, "Divite");
            Assert.AreEqual(factory.Capacity, 3);
        }

        [Test]
        public void RobotAddingWorksCorrectly()
        {
            string text = factory.ProduceRobot("Viliyan", 10000, 5000);
            Assert.AreEqual(factory.Robots.Count, 1);
            Assert.AreEqual(text, $"Produced --> Robot model: Viliyan IS: 5000, Price: 10000.00");

            factory.ProduceRobot("Viliyan2", 10000, 5001);
            factory.ProduceRobot("Viliyan3", 10000, 5002);
            Assert.AreEqual(factory.Robots.Count, 3);

            string text1 = factory.ProduceRobot("Ivan", 10000, 5003);
            Assert.AreEqual(text1, "The factory is unable to produce more robots for this production day!");
        }

        [Test]
        public void SupplementAddingWorksCorrectly()
        {
            string text = factory.ProduceSupplement("JO", 3000);
            Assert.AreEqual(factory.Supplements.Count, 1);
            Assert.AreEqual(text, $"Supplement: JO IS: 3000");

            string text1 = factory.ProduceSupplement("R2D2", 4000);
            Assert.AreEqual(factory.Supplements.Count, 2);
            Assert.AreEqual(text1, $"Supplement: R2D2 IS: 4000");

        }

        [Test]
        public void UpgradeRobotsWorksCorrectly()
        {
            Robot robot1 = new Robot("Viliyan", 10000, 4321);

            Supplement supplement1 = new Supplement("Bagata", 4321);
            Supplement supplement2 = new Supplement("GoShow", 3333);
            Supplement supplement3 = new Supplement("InJetro", 4321);

            bool isValid1 = factory.UpgradeRobot(robot1, supplement1); //true
            bool isValid2 = factory.UpgradeRobot(robot1, supplement1);//false
            bool isValid3 = factory.UpgradeRobot(robot1, supplement2); // false
            bool isValid4 = factory.UpgradeRobot(robot1, supplement3); //true

            Assert.AreEqual(isValid1, true);
            Assert.AreEqual(isValid2, false);
            Assert.AreEqual(isValid3, false);
            Assert.AreEqual(isValid4, true);
        }

        [Test]
        public void SellingRobotsWorksCorrectly()
        {
            //Robot viliyan = new Robot("Viliyan", 9000, 100);
            //Robot ivan = new Robot("Ivan", 7000, 101);
            //Robot rostislav = new Robot("Rostislav", 5000, 102);
            //Robot ivaylo = new Robot("Ivaylo", 3000, 103);
            //Robot denislav = new Robot("Denislav", 1000, 104);

            factory.ProduceRobot("Viliyan", 9000, 100);
            factory.ProduceRobot("Ivan", 7000, 101);
            factory.ProduceRobot("Rostislav", 5000, 102);
            factory.ProduceRobot("Ivaylo", 3000, 103);
            factory.ProduceRobot("Denislav", 1000, 104);

            Robot selledRobot1 = factory.SellRobot(6000);
            Assert.AreEqual(selledRobot1.ToString(), $"Robot model: Rostislav IS: 102, Price: 5000.00");

            Robot selledRobot2 = factory.SellRobot(10000);
            Assert.AreEqual(selledRobot2.ToString(), $"Robot model: Viliyan IS: 100, Price: 9000.00");

            Robot selledRobot3 = factory.SellRobot(500);
            Assert.AreEqual(selledRobot3, null);
        }


        [TearDown]
        public void TearDown()
        {
            factory = null;
        }
    }
}