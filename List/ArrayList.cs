using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class ArrayList: IList
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
            if (value.Length == 0)
            {
                throw new ArgumentNullException("List shouldn't be empty in this way, try with another constructor");
            }
            Length = value.Length;
            _array = value;

        }
        public void Add(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
                
            }
            _array[Length] = value;
            Length++;
        }

        public void Add(IList inputList)
        {
            ArrayList list = new ArrayList();
            if (inputList is ArrayList)
            {
                list = (ArrayList)inputList;
            }
            SetList(list, Length);
        }

        public void AddToBegin(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            Length++;
            MoveRight(0, 1);
            _array[0] = value;
            
        }

        public void AddToBegin(IList inputList)
        {
            ArrayList list = new ArrayList();
            if (inputList is ArrayList)
            {
                list = (ArrayList)inputList;
            }
            SetList(list);
        }

        public void AddByIndex(int value, int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException($"The length of list is less than {index} or index ");
            }

            if (Length == _array.Length)
            {
                UpSize();
            }

            Length++;
            MoveRight(index, 1);
            _array[index] = value;
        }

        public void AddByIndex(IList inputList, int index)
        {
            if(index > Length)
            {
                throw new IndexOutOfRangeException($"The length of list is less than index");
            }
            ArrayList list = new ArrayList();
            if (inputList is ArrayList)
            {
                list = (ArrayList)inputList;
            }
            SetList(list, index);
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

        public void RemoveByIndex(int index, int number = 1)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException("Index < 0 or more list Length");
            }

            if (number < 0)
            {
                throw new ArgumentException();
            }

            if (number >= Length - index)
            {
                Length -= Length - index;
            }
            else
            {
                for (int i = index; i + number < Length; i++)
                {
                    _array[i] = _array[i + number];
                }
                Length -= number;

            }
            if (Length <= (int)(_array.Length * 0.67 + 1))
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


        public void RemoveByIndexMultyElements (int count, int index = 0)
        {
            if (Length < count + index)
            {
                throw new IndexOutOfRangeException("The list is less than expected");
            }
            for (int i = index; i < Length - count; i++)
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

        public void UpSort()
        {
            if (Length == 0)
            {
                throw new ArgumentNullException("The list is empty");
            }
            // InsertSort
            for (int i = 1; i < Length; i++)
            {
                int value = _array[i];
                int position = i;

                while (position > 0 && _array[position - 1] > value)
                {
                    _array[position] = _array[position - 1];
                    position--;
                }
                _array[position] = value;
            }
        }

        public void DownSort()
        {
            if (Length == 0)
            {
                throw new ArgumentNullException("The list is empty");
            }
            // SelectionSort
            for (int i = 0; i < Length; i++)
            {
                int iMin = i;
                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[j] > _array[iMin])
                    {
                        iMin = j;
                    }
                }

                int minValue = _array[iMin];
                _array[iMin] = _array[i];
                _array[i] = minValue;
            }
        }

        public int RemoveFirstByValue(int value)
        {
            if (Length == 0)
            {
                throw new ArgumentNullException("The list is empty");
            }
            int index = -1;
            for (int i =0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    index = i;
                    RemoveByIndex(i);
                    break;
                }
            }
            return index;
        }

        public int RemoveAllByValue(int value)
        {
            if (Length == 0)
            {
                throw new ArgumentNullException("The list is empty");
            }
            int count = 0;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    RemoveByIndex(i);
                    i--;
                    count++;
                }
            }
            return count;
        }

        private void SetList(IList inputList, int index = 0)
        {
            ArrayList list = new ArrayList();
            if (inputList is ArrayList)
            {
                list = (ArrayList)inputList;
            }
            Length += list.Length;
            UpSize(list.Length);

            if(index < Length)
            {
                MoveRight(index, list.Length);
            }

            int j = 0;
            for (int i = index; i < index + list.Length; i++)
            {
                _array[i] = list[j];
                j++;
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


        private void UpSize(int cell = 0)
        {
            int newLength = (int)(_array.Length * 1.33d + 1 + cell);
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

            for (int i = 0; i < Length; i++)
            {
                tempArray[i] = _array[i];
            }

            _array = tempArray;
        }

        private void MoveRight(int start, int cells)
        {
            if (start >= Length || start < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (cells < 0)
            {
                throw new ArgumentException();
            }

            for (int i = Length - 1; i >= start + cells; i--)
            {
                _array[i] = _array[i - cells];
            }
        }

        private void MoveLeft(int start, int cells)
        {
            if (start >= Length || start < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (cells < 0)
            {
                throw new ArgumentException();
            }

            for (int i = start; i < Length; i++)
            {
                _array[i] = _array[i + cells];
            }
        }

    }
}
