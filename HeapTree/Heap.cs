using System;
using System.Collections.Generic;
using System.Text;

namespace HeapTree
{
    class Heap<T>
    {
        public int Count = 0;
        T[] data = new T[10];
        
        private void EnsureCapacity()
        {
            if (Count < data.Length)
            {
                return;
            }

            T[] tempData = new T[data.Length * 2];
            for (int i = 0; i < data.Length; i++)
            {
                tempData[i] = data[i];
            }

            data = tempData;
        }
        
        public void Insert(T newItem)
        {
            EnsureCapacity();

            data[Count] = newItem;
            Count++;

            HeapifyUp(data);
        }
        private void HeapifyUp(T[] data)
        {
            //int indexOfParent;

        }

        public void Pop()
        {

        }

        private void HeapifyDown()
        {

        }
    }
}
