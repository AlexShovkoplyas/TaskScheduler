﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskScheduler.Manager
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private T[] _elements;
        private int _size;
        private int _count;

        public MinHeap(int size)
        {
            _elements = new T[size];
        }

        public MinHeap(IEnumerable<T> list)
        {
            _elements = list.OrderBy(x => x).ToArray();
        }

        private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
        private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

        private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;
        private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;
        private bool IsRoot(int elementIndex) => elementIndex == 0;

        private T GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
        private T GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
        private T GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = _elements[firstIndex];
            _elements[firstIndex] = _elements[secondIndex];
            _elements[secondIndex] = temp;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public T Peek()
        {
            if (_size == 0)
                throw new IndexOutOfRangeException();

            return _elements[0];
        }

        public T Pop()
        {
            if (_size == 0)
                throw new IndexOutOfRangeException();

            var result = _elements[0];
            _elements[0] = _elements[_size - 1];
            _size--;

            ReCalculateDown();

            return result;
        }

        public void Add(T element)
        {
            if (_size == _elements.Length)
                throw new IndexOutOfRangeException();

            if (_elements.Length < ++_count)
            {
                var newElements = new T[_elements.Length * 2];
                _elements.CopyTo(newElements, 0);
                _elements = newElements;
            }

            _elements[_size] = element;
            _size++;

            ReCalculateUp();
        }

        private void ReCalculateDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index).CompareTo(GetLeftChild(index)) < 0)
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (_elements[smallerIndex].CompareTo(_elements[index]) >= 0)
                {
                    break;
                }

                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }

        private void ReCalculateUp()
        {
            var index = _size - 1;
            while (!IsRoot(index) && _elements[index].CompareTo(GetParent(index)) < 0)
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }
    }
}
