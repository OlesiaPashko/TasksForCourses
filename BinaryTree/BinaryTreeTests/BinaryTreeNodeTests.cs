using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeTests
{
    using NUnit.Framework;
    using BinaryTree;
    [TestFixture]
    class BinaryTreeNodeTests
    {
        [Test]
        public void Add_Null_ThrowNullReferenceError()
        {
            //arrange
            BinaryTreeNode<Student> node = new BinaryTreeNode<Student>(new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10)));
            //act + assert
            Assert.Throws(Is.TypeOf<NullReferenceException>()
                 .And.Message.EqualTo("Can not add null as tree element"),
                 delegate { node.Add(null); });
        }

        [Test]
        public void Add_AddedStudentWithLowerTestResult_NodeAddedToLeft()
        {
            //arrange
            BinaryTreeNode<Student> node = new BinaryTreeNode<Student>(new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10)));
            Student valueToAdd = new Student("firstName", "lastName",
                "parrentName", "testName", 7, new System.DateTime(2019, 10, 10));
            //act
            node.Add(valueToAdd);
            //assert
            Assert.AreEqual(node.LeftNode.Data, valueToAdd);
        }

        [Test]
        public void Add_AddedStudentWithHigherTestResult_NodeAddedToLeft()
        {
            //arrange
            BinaryTreeNode<Student> node = new BinaryTreeNode<Student>(new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10)));
            Student valueToAdd = new Student("firstName", "lastName",
                "parrentName", "testName", 13, new System.DateTime(2019, 10, 10));
            //act
            node.Add(valueToAdd);
            //assert
            Assert.AreEqual(node.RightNode.Data, valueToAdd);
        }

        [Test]
        public void Remove_Null_NullReferenceException()
        {
            //arrange
            BinaryTreeNode<Student> node = new BinaryTreeNode<Student>(new Student("firstName", "lastName",
               "parrentName", "testName", 10, new System.DateTime(2019, 10, 10)));
            //act + assert
            Assert.Throws(Is.TypeOf<NullReferenceException>()
                 .And.Message.EqualTo("Can not remove null as tree element"),
                 delegate { node.Remove(null); });
        }
        [Test]
        public void Remove_RightLeave_ReferenceToRightNodeIsNull()
        {
            //arrange
            BinaryTreeNode<Student> node = new BinaryTreeNode<Student>(new Student("firstName", "lastName",
               "parrentName", "testName", 10, new System.DateTime(2019, 10, 10)));
            Student value = new Student("firstName", "lastName",
                "parrentName", "testName", 13, new System.DateTime(2019, 10, 10));
            node.Add(value);
            //act 
            node.Remove(value);
            //assert
            Assert.IsNull(node.RightNode);
        }
        [Test]
        public void Remove_LeftLeave_ReferenceToLeftNodeIsNull()
        {
            //arrange
            BinaryTreeNode<Student> node = new BinaryTreeNode<Student>(new Student("firstName", "lastName",
               "parrentName", "testName", 10, new System.DateTime(2019, 10, 10)));
            Student value = new Student("firstName", "lastName",
                "parrentName", "testName", 3, new System.DateTime(2019, 10, 10));
            node.Add(value);
            //act 
            node.Remove(value);
            //assert
            Assert.IsNull(node.LeftNode);
        }



        [Test]
        public void Remove_LeftNodeWithTwoChilds_ReferenceToLeftNodeIsReferenceToItsLeftChild()
        {
            //arrange
            BinaryTreeNode<Student> node = new BinaryTreeNode<Student>(new Student("firstName", "lastName",
               "parrentName", "testName", 10, new System.DateTime(2019, 10, 10)));
            Student leftNode = new Student("firstName", "lastName",
                "parrentName", "testName", 3, new System.DateTime(2019, 10, 10));
            Student leftNodeLeftChild = new Student("firstName", "lastName",
                "parrentName", "testName", 1, new System.DateTime(2019, 10, 10));
            Student leftNodeRightChild = new Student("firstName", "lastName",
                "parrentName", "testName", 5, new System.DateTime(2019, 10, 10));
            node.Add(leftNode);
            node.Add(leftNodeLeftChild);
            node.Add(leftNodeRightChild);
            var leftNodeLeftChildReference = node.LeftNode.LeftNode;
            //act 
            node.Remove(leftNode);
            //assert
            Assert.AreEqual(leftNodeLeftChildReference, node.LeftNode);
        }

        [Test]
        public void Remove_LeftNodeWithTwoChildsWhenLeftChildHasLeftChildAndWhenRightChildIsNotLeave_ReferenceToLeftNodeIsReferenceToItsLeftChild()
        {
            //arrange
            BinaryTreeNode<Student> node = new BinaryTreeNode<Student>(new Student("firstName", "lastName",
               "parrentName", "testName", 10, new System.DateTime(2019, 10, 10)));
            Student leftNode = new Student("firstName", "lastName",
                "parrentName", "testName", 3, new System.DateTime(2019, 10, 10));
            Student leftNodeLeftChild = new Student("firstName", "lastName",
                "parrentName", "testName", 1, new System.DateTime(2019, 10, 10));
            Student leftNodeRightChild = new Student("firstName", "lastName",
                "parrentName", "testName", 5, new System.DateTime(2019, 10, 10));
            Student leftNodeRightChildRightClild = new Student("firstName", "lastName",
                "parrentName", "testName", 6, new System.DateTime(2019, 10, 10));
            Student leftNodeLeftChildRightChild = new Student("firstName", "lastName",
                "parrentName", "testName", 2, new System.DateTime(2019, 10, 10));
            node.Add(leftNode);
            node.Add(leftNodeLeftChild);
            node.Add(leftNodeRightChild);
            node.Add(leftNodeLeftChildRightChild);
            var leftNodeLeftChildReference = node.LeftNode.LeftNode;
            //act 
            node.Remove(leftNode);
            //assert
            Assert.AreEqual(leftNodeLeftChildReference, node.LeftNode);
        }

        [Test]
        public void Find_Null_ThrowsArgumentNullException()
        {
            //arrange
            BinaryTreeNode<Student> node = new BinaryTreeNode<Student>(new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10)));
            //act + assert
            Assert.Throws(Is.TypeOf<NullReferenceException>()
                 .And.Message.EqualTo("Value cannot be null."),
                 delegate { node.Find(null); });
        }

        [Test]
        public void Find_RootElement_True()
        {
            //arrange
            Student nodeData = new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10));
            BinaryTreeNode<Student> node = new BinaryTreeNode<Student>(nodeData);
            //act
            bool isFound = node.Find(nodeData);
            //assert
            Assert.IsTrue(isFound);
        }

        [Test]
        public void Find_NotElementOfNodeTree_False()
        {
            //arrange
            Student nodeData = new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10));
            BinaryTreeNode<Student> node = new BinaryTreeNode<Student>(nodeData);
            Student otherData = new Student("firstName", "lastName",
                "parrentName", "testName", 11, new System.DateTime(2019, 10, 10));
            //act
            bool isFound = node.Find(otherData);
            //assert
            Assert.IsFalse(isFound);
        }

        [Test]
        public void Find_LeftNode_True()
        {
            //arrange
            Student nodeData = new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10));
            BinaryTreeNode<Student> node = new BinaryTreeNode<Student>(nodeData);
            Student leftData = new Student("firstName", "lastName",
                "parrentName", "testName", 7, new System.DateTime(2019, 10, 10));
            node.Add(leftData);
            //act
            bool isFound = node.Find(leftData);
            //assert
            Assert.IsTrue(isFound);
        }

        [Test]
        public void Find_RightNode_True()
        {
            //arrange
            Student nodeData = new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10));
            BinaryTreeNode<Student> node = new BinaryTreeNode<Student>(nodeData);
            Student rightData = new Student("firstName", "lastName",
                "parrentName", "testName", 14, new System.DateTime(2019, 10, 10));
            node.Add(rightData);
            //act
            bool isFound = node.Find(rightData);
            //assert
            Assert.IsTrue(isFound);
        }

        [Test]
        public void Equals_EqualElements_True()
        {
            //arrange
            Student nodeData = new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10));
            BinaryTreeNode<Student> node = new BinaryTreeNode<Student>(nodeData);
            BinaryTreeNode<Student> node2 = new BinaryTreeNode<Student>(nodeData);
            //act
            bool isEqual = node.Equals(node2);
            //assert
            Assert.IsTrue(isEqual);
        }

        [Test]
        public void Equals_NotEqualElements_False()
        {
            //arrange
            Student nodeData = new Student("firstName", "lastName",
                "parrentName", "testName", 10, new System.DateTime(2019, 10, 10));
            BinaryTreeNode<Student> node = new BinaryTreeNode<Student>(nodeData);
            BinaryTreeNode<Student> node2 = new BinaryTreeNode<Student>(nodeData);
            //act
            bool isEqual = node.Equals(node2);
            //assert
            Assert.IsTrue(isEqual);
        }
    }
}
