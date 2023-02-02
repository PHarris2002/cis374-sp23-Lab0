using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        public Tuple<int, T> Min
        {
            get
            {
                if (IsEmpty)
                {
                    return null;
                }

                var minNode = MinNode(Root);
                return Tuple.Create(minNode.Key, minNode.Value);
            }
        }

        // TODO
        public Tuple<int, T> Max => throw new NotImplementedException();

        // TODO
        public double MedianKey
        {
            get
            {
                // get the inorder keys
                var keys = InOrderKeys;

                //odd
                if(keys.Count % 2 == 1)
                {
                    int middleIndex = keys.Count / 2;
                    return keys[middleIndex];
                }

                //even
                else
                {
                    int middleIndex1 = keys.Count / 2 - 1;
                    int middleIndex2 = keys.Count / 2;

                    int sum = keys[middleIndex1] + keys[middleIndex2];

                    return (double)sum / 2.0;
                }
            }
        }

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

            if (node.Key == key)
            {
                return node;
            }

            else if (key < node.Key)
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

            if (node == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        public BinarySearchTreeNode<T> Next(BinarySearchTreeNode<T> node)
        {
            //case where the node has a right sub-tree
            if (node.Right != null)
            {
                return MinNode(node.Right);
            }

            var nodeParent = node.Parent;
            
            //code that climbs up the tree and looks for successor
            while (nodeParent != null && node == nodeParent.Right)
            {
                node = nodeParent;
                nodeParent = nodeParent.Parent;
            }

            return nodeParent;
        }

        public BinarySearchTreeNode<T> Prev(BinarySearchTreeNode<T> node)
        {
            //case where the node has a left sub-tree
            if (node.Left != null)
            {
                return MaxNode(node.Left);
            }

            var nodeParent = node.Parent;

            //code that climbs up the tree and looks for successor
            while (nodeParent != null && node == nodeParent.Left)
            {
                node = nodeParent;
                nodeParent = nodeParent.Parent;
            }

            return nodeParent;
        }

        public List<BinarySearchTreeNode<T>> RangeSearch(int min, int max)
        { 
            //create list
            List<BinarySearchTreeNode<T>> rangeSearchResult = new List<BinarySearchTreeNode<T>>();

            //if min is greater than the max
            if (min > max)
            {
                return rangeSearchResult;
            }

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
            var node = GetNode(key);
            var parent = node.Parent;

            if (node == null)
            {
                return;
            }

            Count--;

            // 1. leaf node
            if (node.Left == null && node.Right == null)
            {
                if (parent.Left == node)
                {
                    parent.Left = null;
                    node.Parent = null;
                }

                else if (parent.Right == node)
                {
                    parent.Right = null;
                    node.Parent = null;
                }

                return;
            }

            // 2. parent with one child
            if (node.Left == null && node.Right != null)
            {
                //only has a right child
                var child = node.Right;

                if (parent.Left == node)
                {
                    parent.Left = child;
                    child.Parent = parent;
                }

                else if (parent.Right == node)
                {
                    parent.Right = child;
                    child.Parent = parent;
                }

                return;
            }

            if (node.Left != null && node.Right == null)
            {
                //only has a left child
                var child = node.Left;

                if (parent.Left == node)
                {
                    parent.Left = child;
                    child.Parent = parent;

                    //cleanup
                    node.Parent = null;
                    node.Left = null;
                }

                else if (parent.Right == node)
                {
                    parent.Right = child;
                    child.Parent = parent;

                    //cleanup
                    node.Parent = null;
                    node.Right = null;
                }

                return;
            }

            // 3. parent with two children
            // Find the node to remove
            // Find the next node (successor in this case)
            // Swap with the in order successor and then delete the current leaf.
            // Remove the succesor (a leaf node) (like case 1)

        }

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

            if (node == null)
            {
                return;
            }

            InOrderKeysRecursive(node.Left, keys);
            keys.Add(node.Key);
            InOrderKeysRecursive(node.Right, keys);
        }

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

        public BinarySearchTreeNode<T> MinNode(BinarySearchTreeNode<T> node)
        {
            return MinNodeRecursive(node);
        }

        private BinarySearchTreeNode<T> MinNodeRecursive(BinarySearchTreeNode<T> node)
        {
            if (node.Left == null)
            {
                return node;
            }

            return MinNodeRecursive(node.Left);
        }

        public BinarySearchTreeNode<T> MaxNode(BinarySearchTreeNode<T> node)
        {
            {
                return MaxNodeRecursive(node);
            }
        }

        private BinarySearchTreeNode<T> MaxNodeRecursive(BinarySearchTreeNode<T> node)
        {
            if (node.Right == null)
            {
                return node;
            }

            return MaxNodeRecursive(node.Right);
        }
    }
}

