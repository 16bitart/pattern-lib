using System;
using System.Collections.Generic;

namespace PatternBuddy
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private List<T> _items = new List<T>();
        public int Count => _items.Count;
        public T Next => GetMin();
        public T PeekNext => _items[0];

        public T GetMin()
        {
            var item = _items[0];
            _items.Remove(item);
            SortDown(0);
            return item;
        }

        public void Add(T item)
        {
            _items.Add(item);
            SortUp(_items.IndexOf(item));
        }

        private void SortDown(int index)
        {
            while (true)
            {
                int childIndexLeft = index * 2 + 1;
                int childIndexRight = index * 2 + 2;
                int swapIndex = 0;

                if (childIndexLeft < Count)
                {
                    swapIndex = childIndexLeft;

                    if (childIndexRight < Count)
                    {
                        if (_items[childIndexRight].CompareTo(_items[childIndexLeft]) < 0)
                        {
                            swapIndex = childIndexRight;
                        }
                    }

                    if (_items[swapIndex].CompareTo(_items[index]) < 0)
                    {
                        Swap(swapIndex, index);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }

                index = swapIndex;
            }
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public bool Contains(T item, out int index)
        {
            if (Contains(item))
            {
                index = _items.IndexOf(item);
                return true;
            }

            index = -1;
            return false;
        }

        private void SortUp(int index)
        {
            int parentIndex = (index - 1) / 2;

            while (index > 0 && _items[index].CompareTo(_items[parentIndex]) < 0)
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void Swap(int indexA, int indexB)
        {
            (_items[indexA], _items[indexB]) = (_items[indexB], _items[indexA]);
        }
    }
}
