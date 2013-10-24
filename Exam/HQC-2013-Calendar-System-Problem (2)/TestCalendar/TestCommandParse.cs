using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;

namespace TestCalendar
{
    [TestClass]
    public class TestCommandParse
    {
        [TestMethod]
        public void ParseAddEventWithLocation()
        {
            string commandText = "AddEvent 2012-01-21T20:00:00 | party | somewhere";
            string[] commandParameters = 
                new string[] { "2012-01-21T20:00:00", "party", "somewhere" };
            Command command = Command.Parse(commandText);
            Assert.AreEqual("AddEvent", command.Name);
            Assert.AreEqual(3, command.Parameters.Length);
            CollectionAssert.AreEqual(commandParameters, command.Parameters);
        }

        [TestMethod]
        public void ParseAddEventWithoutLocation()
        {
            string commandText = "AddEvent 2012-12-21T10:59:59 | exam";
            string[] commandParameters = 
                new string[] { "2012-12-21T10:59:59", "exam" };
            Command command = Command.Parse(commandText);
            Assert.AreEqual("AddEvent", command.Name);
            Assert.AreEqual(2, command.Parameters.Length);
            CollectionAssert.AreEqual(commandParameters, command.Parameters);
        }

        [TestMethod]
        public void ParseDeleteEvent()
        {
            string commandText = "DeleteEvents exam";
            string[] commandParameters = new string[] { "exam" };
            Command command = Command.Parse(commandText);
            Assert.AreEqual("DeleteEvents", command.Name);
            Assert.AreEqual(1, command.Parameters.Length);
            CollectionAssert.AreEqual(commandParameters, command.Parameters);
        }

        [TestMethod]
        public void ParseListEvent()
        {
            string commandText = "ListEvents 2012-01-21T20:00:00 | 5";
            string[] commandParameters = 
                new string[] { "2012-01-21T20:00:00", "5" };
            Command command = Command.Parse(commandText);
            Assert.AreEqual("ListEvents", command.Name);
            Assert.AreEqual(2, command.Parameters.Length);
            CollectionAssert.AreEqual(commandParameters, command.Parameters);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParseInvalidCommand()
        {
            string commandText = "ListEvents2012-01-21T20:00:005";
            Command command = Command.Parse(commandText);
        }
    }
}
