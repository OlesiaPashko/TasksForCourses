using NUnit.Framework;

namespace Tests
{
    using NUnit.Framework;
    using BinaryTree;
    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void CompareTo_StudentWithLowerTestResult_Returned1()
        {
            //arrange
            Student student1 = new Student("firstName", "lastName",
                "parrentName", "testName", 11, new System.DateTime(2019, 10, 10));
            Student student2 = new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10));
            //act
            int result = student1.CompareTo(student2);
            //assert
            Assert.AreEqual(1, result);
        }
        [Test]
        public void CompareTo_StudentWithHigherTestResult_ReturnedMinus1()
        {
            //arrange
            Student student1 = new Student("firstName", "lastName",
                "parrentName", "testName", 11, new System.DateTime(2019, 10, 10));
            Student student2 = new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10));
            //act
            int result = student2.CompareTo(student1);
            //assert
            Assert.AreEqual(-1, result);
        }
        [Test]
        public void CompareTo_StudentWithNull_Returned1()
        {
            //arrange
            Student student1 = new Student("firstName", "lastName",
                "parrentName", "testName", 11, new System.DateTime(2019, 10, 10));
            Student student2 = null;
            //act
            int result = student1.CompareTo(student2);
            //assert
            Assert.AreEqual(1, result);
        }
        [Test]
        public void Equals_StudentWithTheSameStudent_ReturnedTrue()
        {
            //arrange
            Student student1 = new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10));
            Student student2 = new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10));
            //act
            bool result = student2.Equals(student1);
            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_StudentWithNotTheSameStudent_ReturnedFalse()
        {
            //arrange
            Student student1 = new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10));
            Student student2 = new Student("firstName", "lastName",
                "parrentName", "testName", 11, new System.DateTime(2019, 10, 10));
            //act
            bool result = student2.Equals(student1);
            //assert
            Assert.IsFalse(result);
        }

    }
}


