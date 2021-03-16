using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class ArrayList<T>
    {
        public int Lenght { get; private set; }

        private T[] _array;

        public ArrayList()
        {
            Lenght = 0;

            _array = new T[10];
        }

        public void Add(T value)
        {
            if(Lenght == _array.Length)
            {
                UpSize();
            }
            _array[Lenght] = value;
            Lenght++;
        }

        public void AddToBegin(T value)
        {
            if (Lenght == _array.Length)
            {
                UpSize();
            }
            for(int i = 0; i < Lenght; i++)
            {
                _array[i + 1] = _array[i];
            }

            _array[0] = value;
            Lenght++;
        }

        public void AddByIndex(T value, int index)
        {
            if (Lenght == _array.Length)
            {
                UpSize();
            }
            Lenght++;
            for (int i = Lenght; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[index] = value;
        }

        public void Remove(T value)
        {
            if (Lenght == 0)
            {
                throw new ArgumentNullException("The list is already empty");
            }
            Lenght--;
            if (Lenght < _array.Length / 2)
            {
                DownSize();
            }
        }

        public void RemoveFromBegin()
        {
            if (Lenght == 0)
            {
                throw new ArgumentNullException("The list is already empty");
            }

            for(int i = 0; i < Lenght; i++)
            {
                _array[i] = _array[i + 1]; 
            }
            Lenght--;
            if (Lenght < _array.Length / 2)
            {
                DownSize();
            }
        }

        public void RemoveByIndex(int index)
        {
            if (index < 0 || index > Lenght)
            {
                throw new IndexOutOfRangeException("Index < 0 or more list lenght");
            }
            for (int i = index; i < Lenght; i++)
            {
                _array[index] = _array[index + 1];
            }
            Lenght--;
            if (Lenght < _array.Length / 2)
            {
                DownSize();
            }
        }

        private void UpSize()
        {
            int newLenght = (int)(_array.Length * 1.33d + 1);
            T[] tempArray = new T[newLenght];

            for (int i = 0; i > _array.Length; i++)
            {
                tempArray[i] = _array[i];
            }
        }

        private void DownSize()
        {
            int newLenght = (int)(_array.Length * 0.67d + 1);
            T[] tempArray = new T[newLenght];

            for (int i = 0; i > _array.Length; i++)
            {
                tempArray[i] = _array[i];
            }
        }

    }
}
