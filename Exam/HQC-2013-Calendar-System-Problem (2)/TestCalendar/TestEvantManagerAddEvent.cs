using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using Wintellect.PowerCollections;

namespace TestCalendar
{
    [TestClass]
    public class TestEvantManagerAddEvent
    {
        [TestMethod]
        public void AddEventWithLocation()
        {
            EventManager eventManager = new EventManager();
            DateTime date = new DateTime(2012, 01, 21, 20, 00, 00);
            CalendarEvent calendarEvent = 
                new CalendarEvent(date, "party", "somewhere");
            eventManager.AddEvent(calendarEvent);
            Assert.AreEqual(1, eventManager.CalendarByDate.Count);
            Assert.IsTrue(eventManager.CalendarByDate.ContainsKey(date));
            Assert.IsTrue(eventManager.CalendarByTitle.ContainsKey("party"));
        }

        [TestMethod]
        public void AddEventWithoutLocation()
        {
            EventManager eventManager = new EventManager();
            DateTime date = new DateTime(2000, 01, 01, 00, 00, 00);
            CalendarEvent calendarEvent = new CalendarEvent(date, "party", null);
            eventManager.AddEvent(calendarEvent);
            Assert.AreEqual(1, eventManager.CalendarByDate.Count);
            Assert.IsTrue(eventManager.CalendarByDate.ContainsKey(date));
            Assert.IsTrue(eventManager.CalendarByTitle.ContainsKey("party"));
        }

        [TestMethod]
        public void AddNoEvent()
        {
            EventManager eventManager = new EventManager();
            Assert.AreEqual(0, eventManager.CalendarByDate.Count);
        }

        [TestMethod]
        public void AddEventMultiple()
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
            Assert.AreEqual(3, eventManager.CalendarByDate.Count);
            Assert.AreEqual(3, eventManager.CalendarByTitle.Count);
            Assert.IsTrue(eventManager.CalendarByTitle.ContainsKey("exam"));
            Assert.IsTrue(eventManager.CalendarByTitle.ContainsKey("party"));
            Assert.IsTrue(eventManager.CalendarByTitle.ContainsKey("sleep"));
        }

        [TestMethod]
        public void AddEventDuplicate()
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
            Assert.AreEqual(3, eventManager.CalendarByDate.Count);
            Assert.AreEqual(3, eventManager.CalendarByTitle.Count);
            Assert.IsTrue(eventManager.CalendarByTitle.ContainsKey("exam"));
            Assert.IsTrue(eventManager.CalendarByTitle.ContainsKey("party"));
            Assert.IsTrue(eventManager.CalendarByTitle.ContainsKey("sleep"));
        }
    }
}