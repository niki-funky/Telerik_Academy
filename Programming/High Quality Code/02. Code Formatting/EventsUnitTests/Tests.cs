namespace EventsUnitTests
{
    using System;
    using Events;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestEventConstructor()
        {
            Event game = new Event(new DateTime(2013, 04, 17, 18, 0, 0), "Football Game", "Stadium");
            Assert.IsTrue(game.Location == "Stadium");
        }

        [TestMethod]
        public void TestEventCompareTo()
        {
            Event game = new Event(new DateTime(2013, 10, 10, 15, 50, 0), "Volley", "Beach");
            Event lecture = new Event(new DateTime(2013, 06, 01, 21, 20, 0), "JS", "Telerik");

            Assert.AreEqual(true, game.CompareTo(lecture) > 0);
        }

        [TestMethod]
        public void TestAddEvent()
        {
            EventHolder eventHolder = new EventHolder();
            eventHolder.AddEvent(new DateTime(2013, 06, 01, 21, 20, 0), "JS", "Telerik");

            Assert.AreEqual("Event added" + Environment.NewLine, Messages.Output);
        }

        [TestMethod]
        public void TestDeleteEvents()
        {
            EventHolder eventHolder = new EventHolder();
            eventHolder.AddEvent(new DateTime(2013, 04, 17, 18, 0, 0), "Football Game", "Stadium");
            eventHolder.DeleteEvents("Football Game");
            Assert.AreEqual(true, Messages.Output.EndsWith("1 events deleted" + Environment.NewLine));
        }
    }
}