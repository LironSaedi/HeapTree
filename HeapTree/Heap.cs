using System;
using System.Collections.Generic;
using System.Text;

namespace HeapTree
{
    class Heap<T> where T : IComparable<T>
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

            HeapifyUp(Count - 1);
        }
        private void HeapifyUp(int ind)
        {
            int parent = (ind - 1) / 2;
            //Here we get the parent by using the equation to convert it from array to the tree.

            if (data[ind].CompareTo(data[parent]) < 0) // compare if the index is less than the parent. If it is swap the  index and the parent 0
            {
                T temporary = data[ind];
                data[ind] = data[parent];
                data[parent] = temporary;
            }

            HeapifyUp(parent); //Recursively call it and return the parent.
        }

        private void HeapifyDown(int index)
        {
            //Get left & Right
            int leftIndex = index * 2 + 1;

            //If no left then there will not be anything on the right.
            if (leftIndex >= Count)
            {
                return;
            }

            int rightIndex = index * 2 + 2;
            int swapIndex = 0;

            //If there is no right child at this point, the smaller child is the left child
            if (rightIndex >= Count)
            {
                swapIndex = leftIndex;
            }

            if (rightIndex > Count && leftIndex > Count)
            {
                if (data[rightIndex].CompareTo(data[leftIndex]) < 0)
                {

                    swapIndex = rightIndex;
                    //T temporary = data[right];
                    //data[right] = data[index];
                    //data[index] = temporary;
                    ////swapping the right
                }
                else
                {
                    swapIndex = leftIndex;
                    //swap.E = data[left];
                    //swapping the left
                }

            }
            T temp = data[index];
            data[index] = data[swapIndex];
            data[swapIndex] = temp;
            HeapifyDown(swapIndex);


        }

        public T Pop()
        {


            //Return the first element of the tree
            T root = data[0];

            //Put last element as first eelemt.
            data[0] = data[Count - 1];
            //
            //Update count
            Count--;

            //Heapify Down the last item that we put in the very front
            HeapifyDown(0);

            return root; //return the root
        }


    }
}
