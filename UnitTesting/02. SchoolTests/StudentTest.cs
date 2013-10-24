using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

// Test student initialization and correct initialization of StudentNumber
[TestClass]
public class StudentTest
{
    [TestMethod]
    public void TestNewSchoolStudentInitialization()
    {
        School school = new School();
        Student student = new Student("John", school);
        Assert.AreEqual(10000, student.StudentNumber,
            "The initialization of new object of type Student is not working correct");
    }

    [TestMethod]
    public void TestStudentInitialization()
    {
        School school = new School();
        List<Student> list = new List<Student>();
        for (int count = 0; count < 100; count++)
        {
            Student student = new Student(count.ToString(), school);
            list.Add(student);
        }

        Assert.AreEqual(10099, list[99].StudentNumber,
            "The initialization of many objects of type Student is not working correct");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestFullSchoolStudentInitialization()
    {
        School school = new School();
        List<Student> list = new List<Student>();
        for (int count = 10000; count < 100001; count++)
        {
            Student student = new Student(count.ToString(), school);
            list.Add(student);
        }
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestNullStudentInitialization()
    {
        School school = new School();
        Student student = new Student(null, school);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestEmptyStudentInitialization()
    {
        School school = new School();
        Student student = new Student(string.Empty, school);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestStudentInitializationNullSchool()
    {
        Student student = new Student("John", null);
    }
}