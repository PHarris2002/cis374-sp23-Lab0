using System;
using System.ComponentModel;
using System.Xml.Linq;

namespace Lab0
{
	public class BinarySearchTree<T> : IBinarySearchTree<T>
	{

        private BinarySearchTreeNode<T> Root { get; set; }

        public BinarySearchTree()
		{
            Root = null;
            Count = 0;
		}

        public bool IsEmpty => Root == null;

        public int Count { get; private set; }

        // TODO
        public int Height => HeightRecursive(Root);

        private int HeightRecursive(BinarySearchTreeNode<T> node)
        {
            int leftHeight = 0;
            int rightHeight = 0;

            //Traverse through the all possible paths of the tree
            //Find a way to compare counts between recursions

            if (node == null)
            {
                return -1;
            }

            leftHeight = HeightRecursive(node.Left);
            rightHeight = HeightRecursive(node.Right);

            if (leftHeight >= rightHeight)
                {
                return 1 + leftHeight;
                }

            else
            {
                return 1 + rightHeight;
            }
        }

        public int? MinKey => MinKeyRecursive(Root);

        private int? MinKeyRecursive(BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }

            else if (node.Left == null)
            {
                return node.Key;
            }

            else
            {
                return MinKeyRecursive(node.Left);
            }
        }

        // TODO
        public int? MaxKey => MaxKeyRecursive(Root);

        private int? MaxKeyRecursive(BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }

            else if (node.Right == null)
            {
                return node.Key;
            }

            else
            {
                return MaxKeyRecursive(node.Right);
            }
        }

        // TODO
        public Tuple<int, T> Min => throw new NotImplementedException();

        // TODO
        public Tuple<int, T> Max => throw new NotImplementedException();

        // TODO
        public double MedianKey => throw new NotImplementedException();


        public BinarySearchTreeNode<T> GetNode(int key)
        {
            return GetNodeRecursive(Root, key);
        }

        private BinarySearchTreeNode<T>? GetNodeRecursive(BinarySearchTreeNode<T> node, int key)
        {
            if (node == null)
            {
                return null;
            }

            if(node.Key == key)
            {
                return node;
            }

            else if(key < node.Key)
            {
                return GetNodeRecursive(node.Left, key);
            }

            else
            {
                return GetNodeRecursive(node.Right, key);
            }
        }


        public void Add(int key, T value)
        {
            if (Root == null)
            { 
                Root = new BinarySearchTreeNode<T>(key, value);
                Count++;
            }

            else
            {
                AddRecursive(key, value, Root);
            }
        }
 
        private void AddRecursive(int key, T value, BinarySearchTreeNode<T> parent)
        {
            if (key < parent.Key)
            {
                if (parent.Left == null)
                {
                    var newNode = new BinarySearchTreeNode<T>(key, value);
                    parent.Left = newNode;
                    newNode.Parent = parent;
                    Count++;
                }

                else
                {
                    AddRecursive(key, value, parent.Left);
                }
            }

            else
            {
                //duplicate found - Do NOT add to BST
                if (key == parent.Key)
                {
                    return;
                }

                if (parent.Right == null)
                {
                    var newNode = new BinarySearchTreeNode<T>(key, value);
                    parent.Right = newNode;
                    newNode.Parent = parent;
                    Count++;
                }

                else
                {
                    AddRecursive(key, value, parent.Right);
                }
            }
        }

        public void Clear()
        {
            Root = null;
        }

        public bool Contains(int key)
        {
            var node = GetNode(key);

            if(node == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        // TODO (Why am I failing two tests?)
        public BinarySearchTreeNode<T> Next(BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }

            else if (node.Left == null)
            {
                if (node.Right == null)
                {
                    return null;
                }

                else
                {
                    return node.Right;
                }
            }

            else
            {
                return node.Left;
            }
        }

        // TODO (Why am I failing two tests?)
        public BinarySearchTreeNode<T> Prev(BinarySearchTreeNode<T> node)
        {
            if (node == null || node.Parent == null)
            {
                return null;
            }
            
            else
            {
                return node.Parent;
            }
        }

        // TODO
        public List<BinarySearchTreeNode<T>> RangeSearch(int min, int max)
        {
            //create list
            List<BinarySearchTreeNode<T>> rangeSearchResult = new List<BinarySearchTreeNode<T>>();

            //make a loop that iterates through each number in the given range
            for (int key = min; key <= max; key++)
            {
            //at each iteration, check if the key exists. if it does, add value to list. If not, continue.
                if (Contains(key) == true)
                {
                    rangeSearchResult.Add(GetNode(key));
                }
                
                else
                {
                    continue;
                }
            }

            //return list

            return rangeSearchResult;
        }

        public void Remove(int key)
        {
            throw new NotImplementedException();
        }

        // TODO
        public T Search(int key)
        {
            if (Contains(key))
            {
                var node = GetNode(key);
                return node.Value;
            }

            else
            {
                return default(T);
            }
        }

        // TODO
        public void Update(int key, T value)
        {
            throw new NotImplementedException();
        }


        // TODO
        public List<int> InOrderKeys
        {
            get
            {
                List<int> keys = new List<int>();
                InOrderKeysRecursive(Root, keys);

                return keys;

            }
        }

        private void InOrderKeysRecursive(BinarySearchTreeNode<T> node, List<int> keys)
        {
            // left
            // root
            // right

            if(node == null)
            {
                return;
            }

            InOrderKeysRecursive(node.Left, keys);
            keys.Add(node.Key);
            InOrderKeysRecursive(node.Right, keys);
        }

        // TODO
        public List<int> PreOrderKeys
        {
            get
            {
                List<int> keys = new List<int>();
                PreOrderKeysRecursive(Root, keys);

                return keys;
            }
        }

        private void PreOrderKeysRecursive(BinarySearchTreeNode<T> node, List<int> keys)
        {
            if (node == null)
            {
                return;
            }

            keys.Add(node.Key);
            PreOrderKeysRecursive(node.Left, keys);
            PreOrderKeysRecursive(node.Right, keys);
        }

        // TODO
        public List<int> PostOrderKeys
        {
            get
            {
                List<int> keys = new List<int>();
                PostOrderKeysRecursive(Root, keys);
                return keys;
            }
        }

        private void PostOrderKeysRecursive(BinarySearchTreeNode<T> node, List<int> keys)
        {
            if (node == null)
            {
                return;
            }

            PostOrderKeysRecursive(node.Left, keys);
            PostOrderKeysRecursive(node.Right, keys);
            keys.Add(node.Key);
        }
    }
}

