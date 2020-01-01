using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BinaryTree;

namespace BinaryTree.Tests
{
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
        public void CompareTo_StudentWithLowerTestResult_Returned2()
        {
            //arrange
            //act
            //assert
            Assert.Pass();
        }
        /*[Test]
        public void CompareTo_StudentWithLowerTestResult_Returned1()
        {
            //arrange
            //act
            //assert
            Assert.Pass();
        }
        [Test]
        public void CompareTo_StudentWithLowerTestResult_Returned1()
        {
            //arrange
            //act
            //assert
            Assert.Pass();
        }*/
    }
}


