using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class ArrayList
    {
        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= Length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[index];
            }
            set
            {
                if (index >= Length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[index] = value;
            }
        }

        private int [] _array;

        public ArrayList()
        {
            Length = 0;

            _array = new int[10];
        }

        public ArrayList(int value)
        {
            Length = 1;

            _array = new int[10];
            _array[0] = value;
        }
        public ArrayList(int [] value)
        {
            Length = value.Length;

            _array = value;
            UpSize();
        }
        public void Add(int value)
        {
            if(Length == _array.Length)
            {
                UpSize();
                
            }
            _array[Length] = value;
            Length++;
        }

        public void AddToBegin(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            for(int i = Length; i > 0; i--)
            {
                _array[i] = _array[i-1];
            }

            _array[0] = value;
            Length++;
        }

        public void AddByIndex(int value, int index)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            
            for (int i = Length; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[index] = value;
            Length++;
        }

        public void Remove()
        {
            if (Length == 0)
            {
                throw new ArgumentNullException("The list is already empty");
            }
            Length--;
            if (Length < _array.Length / 2)
            {
                DownSize();
            }
        }

        public void RemoveFromBegin()
        {
            if (Length == 0)
            {
                throw new ArgumentNullException("The list is already empty");
            }

            for(int i = 0; i < Length; i++)
            {
                _array[i] = _array[i + 1]; 
            }
            Length--;
            if (Length < _array.Length / 2)
            {
                DownSize();
            }
        }

        public void RemoveByIndex(int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException("Index < 0 or more list Length");
            }
            for (int i = index; i < Length; i++)
            {
                _array[index] = _array[index + 1];
            }
            Length--;
            if (Length < _array.Length / 2)
            {
                DownSize();
            }
        }

        public void RemoveMultyElements(int count)
        {
            if (Length < count)
            {
                throw new IndexOutOfRangeException("The list is already empty");
            }

            Length -= count;
            if (Length < _array.Length / 2)
            {
                DownSize();
            }
        }

        public void RemoveFromBeginMultyElements (int count)
        {
            if (Length < count)
            {
                throw new IndexOutOfRangeException("The list is less than expected");
            }

            for (int i = 0; i < Length - count; i++)
            {
                _array[i] = _array[i + count];
            }
            Length -= count;
            if (Length < _array.Length / 2)
            {
                DownSize();
            }
        }

        public void RemoveByIndexMultyElements (int count, int index)
        {
            if (Length < count + index)
            {
                throw new IndexOutOfRangeException("The list is less than expected");
            }

            for (int i = index; i < Length; i++)
            {
                _array[i] = _array[i + count];
            }
            Length -= count;
            if (Length < _array.Length / 2)
            {
                DownSize();
            }
        }

        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (this.Length != arrayList.Length)
            {
                return false;
            }
            for (int i = 0; i < Length; i++)
            {
                if (this._array[i] != arrayList._array[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            string str = "";
            for(int i = 0; i < _array.Length; i++)
            {
                str += _array[i] + " ";
            }
            return str;
        }


        private void UpSize()
        {
            int newLength = (int)(_array.Length * 1.33d + 1);
            int[] tempArray = new int[newLength];

            for (int i = 0; i < _array.Length; i++)
            {
                tempArray[i] = _array[i];
            }
            _array = tempArray;
        }

        private void DownSize()
        {
            int newLength = (int)(_array.Length * 0.67d + 1);
            int[] tempArray = new int[newLength];

            for (int i = 0; i < _array.Length; i++)
            {
                tempArray[i] = _array[i];
            }

            _array = tempArray;
        }
    }
}
