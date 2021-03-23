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
            for(int i = 0; i < Length - 1; i++)
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
            for (int i = index; i < Length - 1; i++)
            {
                _array[i] = _array[i + count];
            }
            Length -= count;
            if (Length < _array.Length / 2)
            {
                DownSize();
            }
        }

        public int GetFirstIndexByValue(int value)
        {
            int result = 0;
            for(int i = 0; i < Length; i++)
            {
                if(_array[i] == value)
                {
                    result = i;
                    return result;
                }
            }
            if (result == 0)
            {
                throw new ArgumentException($"List does not have argumet {value}");
            }
            return result;
        }

        public void SetValueByIndex(int value, int index)
        {
            if (Length < index)
            {
                throw new IndexOutOfRangeException("The list length is less than index");
            }
            _array[index] = value;
        }

        public void RevertList()
        {
            if( Length <= 1)
            {
                throw new ArgumentException("The list is empty or contains only one element");
            }
            //_array.Reverse();
            int cursor = Length - 1;
            for (int i = 0; i < cursor; i++)
            {
                int tempValue = _array[i];
                _array[i] = _array[cursor];
                _array[cursor] = tempValue;
                cursor--;
            }
        }

        public int GetMaxValue()
        {
            if (Length == 0)
            {
                throw new ArgumentNullException("The list is empty");
            }

            int max = 0;
            for (int i = 0; i <= Length - 1; i++)
            {
                if (max < _array[i])
                {
                    max = _array[i];
                }
            }
            return max;
        }

        public int GetMinValue()
        {
            if (Length == 0)
            {
                throw new ArgumentNullException("The list is empty");
            }

            int min = _array[0];
            for (int i = 0; i <= Length - 1; i++)
            {
                if (min > _array[i])
                {
                    min = _array[i];
                }
            }
            return min;
        }

        public int GetFirstIndexOfMaxValue()
        {
            if (Length == 0)
            {
                throw new ArgumentNullException("The list is empty");
            }
            int index = 0;
            for(int i = 1; i < Length; i++)
            {
                if(_array[i] > _array[index])
                {
                    index = i;
                }
            }
            return index;
        }

        public int GetFirstIndexOfMinValue()
        {
            if (Length == 0)
            {
                throw new ArgumentNullException("The list is empty");
            }
            int index = 0;
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < _array[index])
                {
                    index = i;
                }
            }
            return index;
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

        //private void ActualSize()
        //{
        //    Length = _array.Length;
        //    int[] tempArray = new int[Length];
        //    for (int i = 0; i < Length; i++)
        //    {
        //        tempArray[i] = _array[i];
        //    }

        //    _array = tempArray;
        //}
    }
}
