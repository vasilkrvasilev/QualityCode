using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Test school initialization and GetStudentNumber
[TestClass]
public class SchoolTest
{
    [TestMethod]
    public void TestSchoolInitialization()
    {
        School school = new School();
        int studentNumber = school.GetStudentNumber();
        Assert.AreEqual(10000, studentNumber,
            "The initialization of many objects of type School is not working correct");
    }

    [TestMethod]
    public void TestGetStudentNumber()
    {
        School school = new School();
        int studentNumber = 0;
        for (int count = 0; count < 100; count++)
        {
            studentNumber = school.GetStudentNumber();
        }
        Assert.AreEqual(10099, studentNumber,
            "GetStudentNumber in loop is not working correct");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestMaxGetStudentNumber()
    {
        School school = new School();
        int studentNumber = 0;
        for (int count = 10000; count < 100001; count++)
        {
            studentNumber = school.GetStudentNumber();
        }
    }
}