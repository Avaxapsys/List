using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class LinkedList: IList
    {
        public int Length { get; private set; }
        public int this[int index]
        {
            get
            {
                IndexValidator(index);
                Node current = GetNodeByIndex(index);
                return current.Value;
            }
            set
            {
                Node current = GetNodeByIndex(index);
                current.Value = value;
            }
        }
        private Node _root;
        private Node _tail;
        public LinkedList()
        {
            Clear();
        }
        public LinkedList(int value)
        {
            CreateOneValueList(value);
        }
        public LinkedList(int[] values)
        {
            if (values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;
                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;
                }
                Length = values.Length;
            }
            else
            {
                Clear();
            }
        }

        public void Add(int value)
        {
            if (Length == 0)
            {
                _root = new Node(value);
                _tail = _root;
            }
            else
            {
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }

            Length++;
        }
        public void Add(IList inputList)
        {
            LinkedList list = new LinkedList();
            if (inputList is LinkedList)
            {
                list = (LinkedList)inputList;
            }
            for (int i = 0; i < list.Length; i++)
            {
                Add(list[i]);
            }
        }

        public void AddToBegin(int value)
        {
            Node temp = new Node(value);
            temp.Next = _root;
            _root = temp;
            Length++;
        }

        public void AddToBegin(IList inputList)
        {
            LinkedList list = new LinkedList();
            if (inputList is LinkedList)
            {
                list = (LinkedList)inputList;
            }
            for (int i = list.Length - 1; i >= 0; i--)
            {
                AddToBegin(list[i]);
            }
        }

        public void AddByIndex(int value, int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }

            Node current = _root;
            for (int i = 1; i < index; i++)
            {
                current = current.Next;
            }

            Node temp = current.Next;
            current.Next = new Node(value);
            current.Next.Next = temp;

            Length++;
        }

        public void AddByIndex(IList inputList, int index)
        {
            LinkedList list = new LinkedList();
            if (inputList is LinkedList)
            {
                list = (LinkedList)inputList;
            }
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index != 0 && index != Length)
            {
                for (int i = list.Length - 1; i >= 0; i--)
                {
                    AddByIndex(list[i], index);
                }
            }
            else
            {
                if (index == 0)
                {
                    AddToBegin(list);
                }
                if (index == Length)
                {
                    Add(list);
                }
            }
        }

        public void Remove()
        {
            if (Length != 1)
            {
                Node current = GetNodeByIndex(Length - 2);
                current.Next = null;
                _tail = current;
                Length--;
            }
            else
            {
                Clear();
            }
        }

        public void RemoveFromBegin()
        {
            if (Length != 1)
            {
                _root = _root.Next;
                Length--;
            }
            else
            {
                Clear();
            }
        }

        public void RemoveByIndex(int index, int number = 1)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (number < 0)
            {
                throw new ArgumentException();
            }
            if (index == 0)
            {
                RemoveFromBegin();
            }
            else
            {
                Node previousNode = GetNodeByIndex(index - 1);
                if (Length - index <= number)
                {
                    _tail = previousNode;
                    _tail.Next = null;
                    Length = index;
                }
                else
                {
                    for (int i = 0; i < number; i++)
                    {
                        previousNode.Next = previousNode.Next.Next;
                    }
                    Length -= number;
                }
            }
        }

        public void RemoveMultyElements(int count)
        {
            if (count > Length || count < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (Length != 1 && Length != count)
            {
                _tail = GetNodeByIndex(Length - 1 - count);
                _tail.Next = null;
                Length -= count;
            }
            else
            {
                if (Length == count)
                {
                    Clear();
                }
            }
        }

        public void RemoveByIndexMultyElements(int count, int index = 0)
        {
            if (count > Length || count < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index < 0 || index > Length || count > Length - index)
            {
                throw new IndexOutOfRangeException();
            }
            if (index != 0 && index != Length - 1)
            {
                Node current = GetNodeByIndex(index - 1);
                Node tmp = current;
                for (int i = 0; i <= count; i++)
                {
                    current = current.Next;
                }
                tmp.Next = current;
                if (tmp.Next == null)
                {
                    _tail = tmp;
                }
                Length = Length - count;
            }
            else if (index == Length - 1)
            {
                Remove();
            }
            else
            {
                Node current = GetNodeByIndex(count);
                _root = current;
                Length -= count;
            }
        }
        public int GetFirstIndexByValue(int value)
        {
            int index = -1;
            Node current = _root;
            for (int i = 0; i < Length; i++)
            {
                if (value == current.Value)
                {
                    index = i;
                }
                current = current.Next;
            }
            return index;
        }
        public void SetValueByIndex(int value, int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            GetNodeByIndex(index).Value = value;
        }
        public void RevertList()
        {
            Node prev = _root;
            Node next = null;
            _tail = _root;
            while (prev != null)
            {
                Node tmp = prev.Next;
                prev.Next = next;
                next = prev;
                prev = tmp;
            }
            _root = next;
        }

        public int GetMaxValue()
        {
            int max = _root.Value;
            Node tmp = _root.Next;
            for (int i = 1; i < Length; i++)
            {
                if (max < tmp.Value)
                {
                    max = tmp.Value;
                }
                tmp = tmp.Next;
            }
            return max;
        }

        public int GetMinValue()
        {
            int min = _root.Value;
            Node tmp = _root.Next;
            for (int i = 1; i < Length; i++)
            {
                if (min > tmp.Value)
                {
                    min = tmp.Value;
                }
                tmp = tmp.Next;
            }
            return min;
        }

        public int GetFirstIndexOfMaxValue()
        {
            int max = _root.Value;
            int index = 0;
            Node tmp = _root.Next;
            for (int i = 1; i < Length; i++)
            {
                if (max < tmp.Value)
                {
                    max = tmp.Value;
                    index = i;
                }
                tmp = tmp.Next;
            }
            return index;
        }

        public int GetFirstIndexOfMinValue()
        {
            int min = _root.Value;
            int index = 0;
            Node tmp = _root.Next;
            for (int i = 1; i < Length; i++)
            {
                if (min > tmp.Value)
                {
                    min = tmp.Value;
                    index = i;
                }
                tmp = tmp.Next;
            }
            return index;
        }

        public void UpSort()
        {
            Node iNode = _root;
            int tmp;
            for (int i = 0; i < Length; i++)
            {
                Node jNode = iNode.Next;
                for (int j = i + 1; j < Length; j++)
                {
                    if (iNode.Value > jNode.Value)
                    {
                        tmp = iNode.Value;
                        iNode.Value = jNode.Value;
                        jNode.Value = tmp;
                    }
                    jNode = jNode.Next;
                }
                iNode = iNode.Next;
            }
        }

        public void DownSort()
        {
            Node iNode = _root;
            int tmp;
            for (int i = 0; i < Length; i++)
            {
                Node jNode = iNode.Next;
                for (int j = i + 1; j < Length; j++)
                {
                    if (iNode.Value < jNode.Value)
                    {
                        tmp = iNode.Value;
                        iNode.Value = jNode.Value;
                        jNode.Value = tmp;
                    }
                    jNode = jNode.Next;
                }
                iNode = iNode.Next;
            }
        }

        public int RemoveFirstByValue(int value)
        {
            int index = -1;
            Node current = _root;
            if (value != _root.Value && value != _tail.Value)
            {
                for (int i = 0; i < Length - 1; i++)
                {
                    if (value == current.Next.Value)
                    {
                        current.Next = current.Next.Next;
                        index = i + 1;
                        Length--;
                        break;
                    }
                    current = current.Next;
                }
            }
            if (value == _root.Value)
            {
                index = 0;
                _root = _root.Next;
                Length--;
                return index;
            }
            if (value == _tail.Value)
            {
                index = Length - 1;
                for (int i = 0; i < Length - 2; i++)
                {
                    current = current.Next;
                }
                current.Next = null;
                _tail = current;
                Length--;

            }
            return index;
        }

        public int RemoveAllByValue(int value)
        {

            int count = 0;
            int index = GetFirstIndexByValue(value);
            while (index != -1)
            {
                RemoveByIndex(index);
                index = GetFirstIndexByValue(value);
                count++;
            }
            return count;
        }
        public override string ToString()
        {
            Node current = _root;
            string s = current.Value + " ";
            if (Length != 0)
            {
                while (!(current.Next is null))
                {
                    current = current.Next;
                    s += current.Value;
                }
            }

            return s;
        }

        public override bool Equals(object obj)
        {
            LinkedList list = (LinkedList)obj;
            if (this.Length != list.Length)
            {
                return false;
            }
            if (this.Length == 0)
            {
                return true;
            }
            if (this._tail.Value != list._tail.Value)
            {
                return false;
            }
            if (!(this._tail.Next is null) || !(list._tail.Next is null))
            {
                return false;
            }
            Node currentThis = this._root;
            Node currentList = list._root;

            while (!(currentThis.Next is null))
            {
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }
                currentList = currentList.Next;
                currentThis = currentThis.Next;
            }
            if (currentThis.Value != currentList.Value)
            {
                return false;
            }

            return true;
        }

        private Node GetNodeByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            Node current;
            if (index == Length - 1)
            {
                current = _tail;
            }
            else
            {
                current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
            }
            return current;
        }

        private void Clear()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        private void IndexValidator(int index)
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException("индекс не входит в массив");
            }
        }

        private void CreateOneValueList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }
    }
}
