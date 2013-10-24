using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;

namespace TestCalendar
{
    [TestClass]
    public class TestEventManagerDeleteEvents
    {
        [TestMethod]
        public void DeleteEvent()
        {
            EventManager eventManager = new EventManager();
            DateTime date = new DateTime(2012, 01, 21, 20, 00, 00);
            CalendarEvent calendarEvent = 
                new CalendarEvent(date, "party", "somewhere");
            eventManager.AddEvent(calendarEvent);
            int count = eventManager.DeleteEventsByTitle("party");
            Assert.AreEqual(1, count);
            Assert.AreEqual(0, eventManager.CalendarByTitle.Count);
            Assert.AreEqual(0, eventManager.CalendarByDate.Count);
        }

        [TestMethod]
        public void DeleteNoEvent()
        {
            EventManager eventManager = new EventManager();
            DateTime date = new DateTime(2000, 01, 01, 00, 00, 00);
            CalendarEvent calendarEvent = new CalendarEvent(date, "party", null);
            eventManager.AddEvent(calendarEvent);
            int count = eventManager.DeleteEventsByTitle("exam");
            Assert.AreEqual(0, count);
            Assert.AreEqual(1, eventManager.CalendarByTitle.Count);
            Assert.AreEqual(1, eventManager.CalendarByDate.Count);
            Assert.IsTrue(eventManager.CalendarByDate.ContainsKey(date));
            Assert.IsTrue(eventManager.CalendarByTitle.ContainsKey("party"));
        }

        [TestMethod]
        public void DeleteNoEventFromEmptyCatalog()
        {
            EventManager eventManager = new EventManager();
            int count = eventManager.DeleteEventsByTitle("party");
            Assert.AreEqual(0, count);
            Assert.AreEqual(0, eventManager.CalendarByTitle.Count);
            Assert.AreEqual(0, eventManager.CalendarByDate.Count);
        }

        [TestMethod]
        public void DeleteEventMultiple()
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
            int firstCount = eventManager.DeleteEventsByTitle("party");
            Assert.AreEqual(3, firstCount);
            Assert.AreEqual(2, eventManager.CalendarByTitle.Count);
            Assert.IsFalse(eventManager.CalendarByTitle.ContainsKey("party"));
            int secondCount = eventManager.DeleteEventsByTitle("party");
            Assert.AreEqual(0, secondCount);
            Assert.AreEqual(2, eventManager.CalendarByTitle.Count);
        }

        [TestMethod]
        public void DeleteEventDuplicate()
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
            int firstCount = eventManager.DeleteEventsByTitle("party");
            Assert.AreEqual(3, firstCount);
            Assert.AreEqual(2, eventManager.CalendarByTitle.Count);
            Assert.IsFalse(eventManager.CalendarByTitle.ContainsKey("party"));
            int secondCount = eventManager.DeleteEventsByTitle("party");
            Assert.AreEqual(0, secondCount);
            Assert.AreEqual(2, eventManager.CalendarByTitle.Count);
        }
    }
}
