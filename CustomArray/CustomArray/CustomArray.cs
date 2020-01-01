using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomArray
{
    class CustomArray<T>:IEnumerable<T>
    {
        private T[] innerArray;
        private int deltaOfIndex=0;

        public int Count { get; private set; } = -1;

        public CustomArray(int deltaOfIndex, int lastIndex)
        {
            this.innerArray = new T[lastIndex - deltaOfIndex];
            this.deltaOfIndex = deltaOfIndex;
            setDefaultValues();
        }

        private void setDefaultValues()
        {
            for (int i = 0; i < innerArray.Length; i++)
            {
                innerArray[i] = default(T);
            }
        }

        public void Add(T item)
        {
            if (Count < innerArray.Length)
            {
                innerArray[Count] = item;
                Count++;
            }
            else
            {
                throw new IndexOutOfRangeException($"Can not add {item} because array is full");
            }
        }

        public void Clear()
        {
            setDefaultValues();
            Count = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < Count; i++)
            {
                yield return this.innerArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public CustomArray()
        {
            innerArray = new T[10];
            setDefaultValues();
        }

        public T this[int index]
        {
            get
            {
                if (index >= deltaOfIndex && index <Count)
                {
                    return innerArray[index-deltaOfIndex];
                }
                else
                {
                    throw new Exception($"Wrong index {index}");
                }
            }
            set
            {
                if (index >= deltaOfIndex && index <innerArray.Length)
                {
                    innerArray[index - deltaOfIndex]=value;
                    Count++;
                }
                else
                {
                    throw new Exception($"Wrong index {index}");
                }
            }
        }
    }
}
