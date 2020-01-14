using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedList;

namespace LinkedListTest
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void TestLinkedList_Add()
        {
            var list = new LinkedList<int>();

            Assert.IsTrue(list.IsEmpty == true);
            Assert.IsTrue(list.Count == 0);

            list.Add(0);

            Assert.IsTrue(list.Count == 1 && list[0] == 0);
        }

        [TestMethod]
        public void TestLinkedList_AppendFirst()
        {
            var list = new LinkedList<int>();

            list.Add(0);

            Assert.IsTrue(list.Count == 1);
            Assert.IsTrue(list[0] == 0);

            list.AppendFirst(17);

            Assert.IsTrue(list.Count == 2);
            Assert.IsTrue(list[0] == 17);
        }

        [TestMethod]
        public void TestLinkedList_foreach()
        {
            var list = new LinkedList<int>();

            var data = new[] { 1, 2, 3, 4, 5, 6, 7 };

            foreach (var item in data)
            {
                list.Add(item);
            }

            Assert.IsTrue(list.Count == 7);

            var index = 0;
            foreach (var item in list)
            {
                Assert.IsTrue(item == data[index++]);
            }

        }

        [TestMethod]
        public void TestLinkedList_Clear()
        {
            var list = new LinkedList<int>();

            var data = new[] { 1, 2, 3, 4, 5, 6, 7 };

            foreach (var item in data)
            {
                list.Add(item);
            }

            var index = 0;
            foreach (var item in list)
            {
                Assert.IsTrue(item == data[index++]);
            }

            list.Clear();

            Assert.IsTrue(list.Count == 0);

        }

        [TestMethod]
        public void TestLinkedList_Contains()
        {
            var list = new LinkedList<int>();

            var data = new[] { 1, 2, 3, 4, 5, 6, 7 };

            foreach (var item in data)
            {
                list.Add(item);
            }

            Assert.IsTrue(!list.Contains(17));
            Assert.IsTrue(list.Contains(3));

        }


        [TestMethod]
        public void TestLinkedList_IndexOf()
        {
            var list = new LinkedList<int>();

            var data = new[] { 1, 2, 3, 4, 5, 6, 7 };

            foreach (var item in data)
            {
                list.Add(item);
            }

            Assert.IsTrue(list.IndexOf(10) == -1);
            Assert.IsTrue(list.IndexOf(1) == 0);

        }

        [TestMethod]
        public void TestLinkedList_Remove()
        {
            var list = new LinkedList<int>();

            var data = new[] { 1, 2, 3, 4, 5, 6, 7 };

            foreach (var item in data)
            {
                list.Add(item);
            }

            list.Remove(2);
            Assert.IsTrue(!list.Contains(2));

        }

        [TestMethod]
        public void TestLinkedList_CopyTo()
        {
            var list = new LinkedList<int>();

            var data = new[] { 1, 2, 3, 4, 5, 6, 7 };

            foreach (var item in data)
            {
                list.Add(item);
            }

            var newData = new int[7];

            list.CopyTo(newData, 0);

            var index = 0;
            foreach (var item in list)
            {
                Assert.IsTrue(item == newData[index++]);
            }

        }

        [TestMethod]
        public void TestLinkedList_RemoveAt()
        {
            var list = new LinkedList<int>();

            var data = new[] { 1, 2, 3, 4, 5, 6, 7 };

            foreach (var item in data)
            {
                list.Add(item);
            }

            list.RemoveAt(2);
            Assert.IsTrue(!list.Contains(3));

        }

        public void TestLinkedList_Insert()
        {
            var list = new LinkedList<int>();

            list.Add(17);
            Assert.IsTrue(list.IndexOf(17) == 0);
            list.Add(31);
            Assert.IsTrue(list.IndexOf(31) == 1);
            list.Insert(1, 2);
            Assert.IsTrue(list.IndexOf(2) == 1);
            list.Add(15);
            Assert.IsTrue(list.IndexOf(15) == 3);
            list.Remove(2);

            Assert.IsTrue(list.Count == 3);
            Assert.IsTrue(list.IndexOf(17) == 0);
            Assert.IsTrue(list.IndexOf(15) == 2);
        }
    }
}
