using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab0;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void Add()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(3, 30);
            BinarySearchTree<string> tree2 = new BinarySearchTree<string>();
            tree2.Add(3, "leaf");
            BinarySearchTree<char> tree3 = new BinarySearchTree<char>();
            tree3.Add(3, 'c');
        }

        [TestMethod]
        public void AddInt()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            Random rand = new Random();
            int random = 0;
            for (int i = 0; i < 50; i++)
            {
                random = rand.Next();
                tree.Add(i, random);
                Assert.AreEqual(random, tree.Search(i));
            }
        }

        [TestMethod]
        public void HeightZero()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(0, 0);
            Assert.AreEqual(0, tree.Height);

            tree = new BinarySearchTree<int>();
            Assert.AreEqual(0, tree.Height);
        }

        [TestMethod]
        public void HeightInt()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            Random rand = new Random();
            int random = 0;
            for (int i = 0; i < 50; i++)
            {
                random = rand.Next();
                tree.Add(i, random);
            }
            Assert.AreEqual(49, tree.Height);
        }

        [TestMethod]
        public void HeightInt2()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            Random rand = new Random();
            int random = 0;
            random = rand.Next();
            tree.Add(8, random);
            random = rand.Next();
            tree.Add(10, random);
            random = rand.Next();
            tree.Add(6, random);
            random = rand.Next();
            tree.Add(5, random);
            random = rand.Next();
            tree.Add(22, random);
            random = rand.Next();
            tree.Add(26, random);
            random = rand.Next();
            tree.Add(7, random);
            random = rand.Next();
            random = rand.Next();
            tree.Add(23, random);
            Assert.AreEqual(4, tree.Height);
        }

        [TestMethod]
        public void AddString()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            Random rand = new Random();
            string random = "";
            for (int i = 0; i < 50; i++)
            {
                random = rand.Next().ToString();
                tree.Add(i, random);
                Assert.AreEqual(random, tree.Search(i));
            }
        }

        [TestMethod]
        public void HeightString()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            Random rand = new Random();
            string random = "";
            for (int i = 0; i < 50; i++)
            {
                random = rand.Next().ToString();
                tree.Add(i, random);
            }
            Assert.AreEqual(49, tree.Height);
        }

        [TestMethod]
        public void AddChar()
        {
            BinarySearchTree<char> tree = new BinarySearchTree<char>();
            char random = ' ';
            for (int i = 0; i < 50; i++)
            {
                random = (char)i;
                tree.Add(i, random);
                Assert.AreEqual(random, tree.Search(i));
            }
        }

        [TestMethod]
        public void HeightChar()
        {
            BinarySearchTree<char> tree = new BinarySearchTree<char>();
            char random = ' ';
            for (int i = 0; i < 50; i++)
            {
                random = (char)i;
                tree.Add(i, random);
            }
            Assert.AreEqual(49, tree.Height);
        }

        [TestMethod]
        public void ParentInt()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            for (int i = 0; i < 50; i++)
            {
                tree.Add(i, i + 1);
            }
            for (int i = 2; i < 49; i++)
            {
                Assert.AreEqual(tree.Search(i), tree.GetNode(i + 1).Parent.Value);
            }
        }

        [TestMethod]
        public void ParentInt2()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(8, 9);
            tree.Add(10, 11);
            tree.Add(6, 7);
            tree.Add(5, 6);
            tree.Add(22, 23);
            tree.Add(26, 27);
            tree.Add(7, 8);
            tree.Add(23, 24);
            Assert.AreEqual(tree.Search(8), tree.GetNode(10).Parent.Value);
            Assert.AreEqual(tree.Search(8), tree.GetNode(6).Parent.Value);
            Assert.AreEqual(tree.Search(6), tree.GetNode(5).Parent.Value);
            Assert.AreEqual(tree.Search(10), tree.GetNode(22).Parent.Value);
            Assert.AreEqual(tree.Search(22), tree.GetNode(26).Parent.Value);
            Assert.AreEqual(tree.Search(6), tree.GetNode(7).Parent.Value);
            Assert.AreEqual(tree.Search(26), tree.GetNode(23).Parent.Value);
            Assert.AreEqual(9, tree.GetNode(10).Parent.Value);
            Assert.AreEqual(9, tree.GetNode(6).Parent.Value);
            Assert.AreEqual(7, tree.GetNode(5).Parent.Value);
            Assert.AreEqual(11, tree.GetNode(22).Parent.Value);
            Assert.AreEqual(23, tree.GetNode(26).Parent.Value);
            Assert.AreEqual(7, tree.GetNode(7).Parent.Value);
            Assert.AreEqual(27, tree.GetNode(23).Parent.Value);
        }

        [TestMethod]
        public void RemoveIntWHeightAndParent()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            for (int i = 0; i < 50; i++)
            {
                tree.Add(i, i + 1);
            }
            tree.Remove(20);
            Assert.AreEqual(48, tree.Height);
            Assert.AreEqual(20, tree.GetNode(21).Parent.Value);
        }

        [TestMethod]
        public void RemoveIntWHeightAndParent2()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            for (int i = 0; i < 50; i++)
            {
                tree.Add(i, i + 1);
            }
            tree.Remove(20);
            tree.Remove(4);
            tree.Remove(40);
            Assert.AreEqual(46, tree.Height);
            Assert.AreEqual(20, tree.GetNode(21).Parent.Value);
            Assert.AreEqual(4, tree.GetNode(5).Parent.Value);
            Assert.AreEqual(40, tree.GetNode(41).Parent.Value);
        }

        [TestMethod]
        public void RemoveIntWHeightAndParent3()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(8, 9);
            tree.Add(10, 11);
            tree.Add(6, 7);
            tree.Add(5, 6);
            tree.Add(22, 23);
            tree.Add(26, 27);
            tree.Add(7, 8);
            tree.Add(23, 24);
            tree.Remove(10);
            Assert.AreEqual(3, tree.Height);
            Assert.AreEqual(9, tree.GetNode(22).Parent.Value);
            Assert.AreEqual(23, tree.GetNode(8).Right.Value);
        }

        [TestMethod]
        public void RemoveRoot1()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(8, 9);
            tree.Add(10, 11);
            tree.Add(6, 7);
            tree.Add(5, 6);
            tree.Add(22, 23);
            tree.Add(26, 27);
            tree.Add(7, 8);
            tree.Add(23, 24);
            tree.Remove(8);
            Assert.AreEqual(3, tree.Height);
            Assert.IsNull(tree.GetNode(8));
        }

        [TestMethod]
        public void RemoveRoot2()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(8, 9);
            tree.Add(10, 11);
            tree.Add(6, 7);
            tree.Add(5, 6);
            tree.Add(22, 23);
            tree.Add(26, 27);
            tree.Add(7, 8);
            tree.Add(23, 24);
            tree.Remove(8);
            tree.Remove(10);
            Assert.AreEqual(2, tree.Height);
            Assert.IsNull(tree.GetNode(10));
        }

        [TestMethod]
        public void RemoveRoot3()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(8, 9);
            tree.Add(10, 11);
            tree.Add(6, 7);
            tree.Add(5, 6);
            tree.Add(22, 23);
            tree.Add(26, 27);
            tree.Add(7, 8);
            tree.Add(23, 24);

            tree.Remove(8);
            tree.Remove(10);
            tree.Remove(6);
            tree.Remove(5);
            tree.Remove(23);
            tree.Remove(7);
            tree.Remove(22);
            Assert.AreEqual(0, tree.Height);
            Assert.IsNull(tree.GetNode(8));
            Assert.IsNotNull(tree.GetNode(26));
            tree.Remove(26);
        }

        [TestMethod]
        public void RemoveRoot4()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(8, 9);
            tree.Add(10, 11);
            tree.Add(6, 7);
            tree.Add(5, 6);
            tree.Add(22, 23);
            tree.Add(26, 27);
            tree.Add(7, 8);
            tree.Add(23, 24);

            tree.Remove(8);
            tree.Remove(10);
            tree.Remove(6);
            tree.Remove(5);
            tree.Remove(23);
            tree.Remove(7);
            tree.Remove(22);
            Assert.AreEqual(0, tree.Height);
            Assert.IsNull(tree.GetNode(8));
            Assert.IsNotNull(tree.GetNode(26));
            tree.Remove(26);
        }

        [TestMethod]
        public void PostOrderKeys()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(8, 7);
            tree.Add(10, 6);
            tree.Add(6, 2);
            tree.Add(5, 0);
            tree.Add(22, 5);
            tree.Add(26, 4);
            tree.Add(7, 1);
            tree.Add(23, 3);
            List<int> keys = tree.PostOrderKeys;
            Assert.AreEqual(5, keys[0]);
            Assert.AreEqual(7, keys[1]);
            Assert.AreEqual(6, keys[2]);
            Assert.AreEqual(23, keys[3]);
            Assert.AreEqual(26, keys[4]);
            Assert.AreEqual(22, keys[5]);
            Assert.AreEqual(10, keys[6]);
            Assert.AreEqual(8, keys[7]);

        }

        [TestMethod]
        public void PreOrderKeys()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(8, 7);
            tree.Add(10, 6);
            tree.Add(6, 2);
            tree.Add(5, 0);
            tree.Add(22, 5);
            tree.Add(26, 4);
            tree.Add(7, 1);
            tree.Add(23, 3);
            List<int> keys = tree.PreOrderKeys;
            Assert.AreEqual(8, keys[0]);
            Assert.AreEqual(6, keys[1]);
            Assert.AreEqual(5, keys[2]);
            Assert.AreEqual(7, keys[3]);
            Assert.AreEqual(10, keys[4]);
            Assert.AreEqual(22, keys[5]);
            Assert.AreEqual(26, keys[6]);
            Assert.AreEqual(23, keys[7]);

        }

        [TestMethod]
        public void InOrderKeys()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(8, 7);
            tree.Add(10, 6);
            tree.Add(6, 2);
            tree.Add(5, 0);
            tree.Add(22, 5);
            tree.Add(26, 4);
            tree.Add(7, 1);
            tree.Add(23, 3);
            List<int> keys = tree.InOrderKeys;
            Assert.AreEqual(5, keys[0]);
            Assert.AreEqual(6, keys[1]);
            Assert.AreEqual(7, keys[2]);
            Assert.AreEqual(8, keys[3]);
            Assert.AreEqual(10, keys[4]);
            Assert.AreEqual(22, keys[5]);
            Assert.AreEqual(23, keys[6]);
            Assert.AreEqual(26, keys[7]);

        }
    }
}