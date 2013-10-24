using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;

namespace TestCalendar
{
    [TestClass]
    public class TestEventManagerListEvents
    {
        [TestMethod]
        public void ListEventOne()
        {
            EventManager eventManager = new EventManager();
            DateTime date = new DateTime(2012, 01, 21, 20, 00, 00);
            CalendarEvent calendarEvent = new CalendarEvent(date, "party", "somewhere");
            eventManager.AddEvent(calendarEvent);
            IEnumerable<CalendarEvent> list = eventManager.ListEvents(date, 1);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(date, list.First().Date);
            Assert.AreEqual("party", list.First().Title);
            Assert.AreEqual("somewhere", list.First().Location);
        }

        [TestMethod]
        public void ListNoEventLaterDate()
        {
            EventManager eventManager = new EventManager();
            DateTime date = new DateTime(2000, 01, 01, 00, 00, 00);
            DateTime otherDate = new DateTime(2010, 01, 01, 00, 00, 00);
            CalendarEvent calendarEvent = new CalendarEvent(date, "party", null);
            eventManager.AddEvent(calendarEvent);
            IEnumerable<CalendarEvent> list = eventManager.ListEvents(otherDate, 1);
            Assert.AreEqual(0, list.Count());
            Assert.AreEqual(1, eventManager.CalendarByTitle.Count);
            Assert.AreEqual(1, eventManager.CalendarByDate.Count);
            Assert.IsTrue(eventManager.CalendarByDate.ContainsKey(date));
            Assert.IsTrue(eventManager.CalendarByTitle.ContainsKey("party"));
        }

        [TestMethod]
        public void ListEventEarlierDate()
        {
            EventManager eventManager = new EventManager();
            DateTime date = new DateTime(2010, 01, 01, 00, 00, 00);
            DateTime otherDate = new DateTime(2005, 01, 01, 00, 00, 00);
            CalendarEvent calendarEvent = new CalendarEvent(date, "party", null);
            eventManager.AddEvent(calendarEvent);
            IEnumerable<CalendarEvent> list = eventManager.ListEvents(otherDate, 1);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(1, eventManager.CalendarByTitle.Count);
            Assert.AreEqual(1, eventManager.CalendarByDate.Count);
            Assert.IsTrue(eventManager.CalendarByDate.ContainsKey(date));
            Assert.IsTrue(eventManager.CalendarByTitle.ContainsKey("party"));
        }

        [TestMethod]
        public void ListEventFromEmptyCatalog()
        {
            EventManager eventManager = new EventManager();
            DateTime date = new DateTime(2000, 01, 01, 00, 00, 00);
            IEnumerable<CalendarEvent> list = eventManager.ListEvents(date, 1);
            Assert.AreEqual(0, list.Count());
            Assert.AreEqual(0, eventManager.CalendarByTitle.Count);
            Assert.AreEqual(0, eventManager.CalendarByDate.Count);
        }

        [TestMethod]
        public void ListEventAsAsked()
        {
            EventManager eventManager = new EventManager();
            DateTime dateOne = new DateTime(2000, 01, 01, 00, 00, 00);
            DateTime dateTwo = new DateTime(2010, 12, 31, 23, 59, 59);
            DateTime dateThree = new DateTime(2019, 05, 16, 13, 30, 00);
            CalendarEvent calendarEventOne = 
                new CalendarEvent(dateOne, "party", "somewhere");
            CalendarEvent calendarEventTwo = 
                new CalendarEvent(dateTwo, "exam", "somewhere");
            CalendarEvent calendarEventThree = 
                new CalendarEvent(dateThree, "party", "club");
            CalendarEvent calendarEventFour = 
                new CalendarEvent(dateOne, "exam", "academy");
            CalendarEvent calendarEventFive = 
                new CalendarEvent(dateTwo, "sleep", null);
            CalendarEvent calendarEventSix = 
                new CalendarEvent(dateThree, "sleep", null);
            CalendarEvent calendarEventSeven = 
                new CalendarEvent(dateTwo, "party", null);
            eventManager.AddEvent(calendarEventOne);
            eventManager.AddEvent(calendarEventTwo);
            eventManager.AddEvent(calendarEventThree);
            eventManager.AddEvent(calendarEventFour);
            eventManager.AddEvent(calendarEventFive);
            eventManager.AddEvent(calendarEventSix);
            eventManager.AddEvent(calendarEventSeven);
            IEnumerable<CalendarEvent> list = eventManager.ListEvents(dateOne, 5);
            Assert.AreEqual(5, list.Count());
        }

        [TestMethod]
        public void ListEventLessThenAsked()
        {
            EventManager eventManager = new EventManager();
            DateTime dateOne = new DateTime(2000, 01, 01, 00, 00, 00);
            DateTime dateTwo = new DateTime(2010, 12, 31, 23, 59, 59);
            DateTime dateThree = new DateTime(2019, 05, 16, 13, 30, 00);
            CalendarEvent calendarEventOne = 
                new CalendarEvent(dateOne, "party", "somewhere");
            CalendarEvent calendarEventTwo = 
                new CalendarEvent(dateTwo, "exam", "somewhere");
            CalendarEvent calendarEventThree = 
                new CalendarEvent(dateThree, "party", "club");
            CalendarEvent calendarEventFour = 
                new CalendarEvent(dateOne, "exam", "academy");
            CalendarEvent calendarEventFive = 
                new CalendarEvent(dateTwo, "sleep", null);
            CalendarEvent calendarEventSix = 
                new CalendarEvent(dateThree, "sleep", null);
            CalendarEvent calendarEventSeven = 
                new CalendarEvent(dateTwo, "party", null);
            eventManager.AddEvent(calendarEventOne);
            eventManager.AddEvent(calendarEventTwo);
            eventManager.AddEvent(calendarEventThree);
            eventManager.AddEvent(calendarEventFour);
            eventManager.AddEvent(calendarEventFive);
            eventManager.AddEvent(calendarEventSix);
            eventManager.AddEvent(calendarEventSeven);
            IEnumerable<CalendarEvent> list = eventManager.ListEvents(dateThree, 5);
            Assert.AreEqual(2, list.Count());
        }

        [TestMethod]
        public void ListEventDuplicate()
        {
            EventManager eventManager = new EventManager();
            DateTime dateOne = new DateTime(2000, 01, 01, 00, 00, 00);
            DateTime dateTwo = new DateTime(2010, 12, 31, 23, 59, 59);
            DateTime dateThree = new DateTime(2019, 05, 16, 13, 30, 00);
            CalendarEvent calendarEventOne = 
                new CalendarEvent(dateOne, "party", "somewhere");
            CalendarEvent calendarEventTwo = 
                new CalendarEvent(dateTwo, "exam", "academy");
            CalendarEvent calendarEventThree = 
                new CalendarEvent(dateThree, "sleep", null);
            CalendarEvent calendarEventFour = 
                new CalendarEvent(dateTwo, "party", null);
            eventManager.AddEvent(calendarEventOne);
            eventManager.AddEvent(calendarEventTwo);
            eventManager.AddEvent(calendarEventThree);
            eventManager.AddEvent(calendarEventFour);
            eventManager.AddEvent(calendarEventTwo);
            eventManager.AddEvent(calendarEventTwo);
            eventManager.AddEvent(calendarEventOne);
            IEnumerable<CalendarEvent> list = eventManager.ListEvents(dateTwo, 5);
            Assert.AreEqual(5, list.Count());
        }

        [TestMethod]
        public void ListEventCheckOrder()
        {
            EventManager eventManager = new EventManager();
            DateTime dateOne = new DateTime(2000, 01, 01, 00, 00, 00);
            DateTime dateTwo = new DateTime(2010, 12, 31, 23, 59, 59);
            DateTime dateThree = new DateTime(2019, 05, 16, 13, 30, 00);
            CalendarEvent calendarEventOne = 
                new CalendarEvent(dateOne, "party", "somewhere");
            CalendarEvent calendarEventTwo = 
                new CalendarEvent(dateTwo, "exam", "somewhere");
            CalendarEvent calendarEventThree = 
                new CalendarEvent(dateThree, "party", "club");
            CalendarEvent calendarEventFour = 
                new CalendarEvent(dateOne, "exam", "academy");
            CalendarEvent calendarEventFive = 
                new CalendarEvent(dateTwo, "sleep", null);
            CalendarEvent calendarEventSix = 
                new CalendarEvent(dateThree, "party", null);
            CalendarEvent calendarEventSeven = 
                new CalendarEvent(dateTwo, "party", null);
            eventManager.AddEvent(calendarEventOne);
            eventManager.AddEvent(calendarEventTwo);
            eventManager.AddEvent(calendarEventThree);
            eventManager.AddEvent(calendarEventFour);
            eventManager.AddEvent(calendarEventFive);
            eventManager.AddEvent(calendarEventSix);
            eventManager.AddEvent(calendarEventSeven);
            IEnumerable<CalendarEvent> list = eventManager.ListEvents(dateTwo, 5);
            Assert.AreEqual(5, list.Count());

            string expected = calendarEventTwo.ToString() + "\n" +
                calendarEventSeven.ToString() + "\n" + 
                calendarEventFive.ToString() + "\n" +
                calendarEventSix.ToString() + "\n" + 
                calendarEventThree.ToString();
            string actual = list.First().ToString() + "\n" +
                list.Skip(1).First().ToString() + "\n" +
                list.Skip(2).First().ToString() + "\n" +
                list.Skip(3).First().ToString() + "\n" +
                list.Skip(4).First().ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
