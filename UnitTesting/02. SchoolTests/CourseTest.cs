using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Test course initialization, AddStudent and RemoveStudent
[TestClass]
public class CourseTest
{
    [TestMethod]
    public void TestCourseInitialization()
    {
        Course course = new Course();
        Assert.AreEqual(0, course.ListOfStudents.Count,
            "The initialization of new object of type Course is not working correct");
    }

    [TestMethod]
    public void TestAddStudent()
    {
        School school = new School();
        Course course = new Course();
        Student student = new Student("John", school);
        course.AddStudent(student);
        Assert.AreEqual(1, course.ListOfStudents.Count,
            "AddStudent is not working correct");
        Assert.AreEqual("John", course.ListOfStudents[0].Name,
            "AddStudent is not working correct");
    }

    [TestMethod]
    public void TestAddStudent30()
    {
        School school = new School();
        Course course = new Course();
        for (int count = 0; count < 30; count++)
        {
            Student student = new Student(count.ToString(), school);
            course.AddStudent(student);
        }
        Assert.AreEqual(30, course.ListOfStudents.Count,
            "AddStudent is not working correct");
        Assert.AreEqual("29", course.ListOfStudents[29].Name,
            "AddStudent is not working correct");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestAddStudentMoreThen30()
    {
        School school = new School();
        Course course = new Course();
        for (int count = 0; count < 31; count++)
        {
            Student student = new Student(count.ToString(), school);
            course.AddStudent(student);
        }
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestAddNullStudent()
    {
        Course course = new Course();
        course.AddStudent(null);
    }

    [TestMethod]
    public void TestRemoveStudent()
    {
        School school = new School();
        Course course = new Course();
        Student student = new Student("John", school);
        course.AddStudent(student);
        course.RemoveStudent(student);
        Assert.AreEqual(0, course.ListOfStudents.Count,
            "RemoveStudent is not working correct");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestRemoveStudentFromEmptyCourse()
    {
        School school = new School();
        Course course = new Course();
        course.RemoveStudent(new Student("John", school));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TesRemoveNullStudent()
    {
        Course course = new Course();
        course.RemoveStudent(null);
    }
}