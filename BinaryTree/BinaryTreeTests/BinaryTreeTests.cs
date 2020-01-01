using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using BinaryTree;

namespace BinaryTreeTests
{
    [TestFixture]
    class BinaryTreeTests
    {
        [Test]
        public void Add_ElementToEmptyTree_ElementAddedAsRoot()
        {
            //arrange
            BinaryTree<int> bt = new BinaryTree<int>();
            //act
            bt.Add(3);
            //assert
            Assert.AreEqual(3, bt.Root.Data);
        }

        [Test]
        public void Add_ElementToNotEmptyTree_ElementAddedAfterRoot()
        {
            //arrange
            BinaryTree<int> bt = new BinaryTree<int>();
            //act
            bt.Add(3);
            bt.Add(4);
            //assert
            Assert.AreEqual(4, bt.Root.RightNode.Data);
        }

        [Test]
        public void Remove_ElementFromEmptyTree_ThrowException()
        {
            //arrange
            BinaryTree<Student> bt = new BinaryTree<Student>();
            //act + assert
            Assert.Throws(Is.TypeOf<NullReferenceException>()
                 .And.Message.EqualTo("Can not remove from empty tree"),
                 delegate { bt.Remove(null); });
        }

        [Test]
        public void Remove_ElementFromNotEmptyTree_ElementRemoved()
        {
            //arrange
            BinaryTree<double> bt = new BinaryTree<double>();
            bt.Add(3.5);
            bt.Add(5.6);
            bool isNullElementBeforeRemoving = bt.Root.RightNode == null;
            //act
            bt.Remove(3.5);
            //assert
            Assert.Multiple(() =>
            {
                Assert.IsNull(bt.Root.RightNode);
                Assert.IsFalse(isNullElementBeforeRemoving);
            });
        }

        [Test]

        public void Find_Null_ThrowException()
        {
            //arrange
            BinaryTree<Student> bt = new BinaryTree<Student>();
            bt.Add(new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10)));
            //act + assert
            Assert.Throws(Is.TypeOf<NullReferenceException>()
                 .And.Message.EqualTo("Can not take null as argument to find"),
                 delegate { bt.Find(null); });
        }

        [Test]
        public void Find_Element_True()
        {
            //arrange
            BinaryTree<Student> bt = new BinaryTree<Student>();
            bt.Add(new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10)));
            //act + assert
            Assert.Throws(Is.TypeOf<NullReferenceException>()
                 .And.Message.EqualTo("Can not take null as argument to find"),
                 delegate { bt.Find(null); });
        }

        [Test]

        public void Find_Element_False()
        {
            //arrange
            BinaryTree<Student> bt = new BinaryTree<Student>();
            bt.Add(new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10)));
            //act + assert
            Assert.Throws(Is.TypeOf<NullReferenceException>()
                 .And.Message.EqualTo("Can not take null as argument to find"),
                 delegate { bt.Find(null); });
        }
    }
}
