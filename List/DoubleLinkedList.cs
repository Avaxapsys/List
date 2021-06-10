using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class DoubleLinkedList: IList
    {
        public int Length { get; private set; }

        private Node _root;
        private Node _tail;

        public int this[int index]
        {
            get
            {
                return GetNodeByIndex(index).Value;
            }
            set
            {
                GetNodeByIndex(index).Value = value;
            }
        }
        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = _root;
        }
        public DoubleLinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }
        public DoubleLinkedList(int[] values)
        {
            if (values is null)
            {
                _root = null;
                _tail = null;
                Length = 0;

            }
            if (values.Length != 0)
            {
                Length = 1;
                _root = new Node(values[0]);
                _tail = _root;
                for (int i = 1; i < values.Length; i++)
                {
                    Add(values[i]);
                }
            }
            else
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
        }

        public void Add(int value)
        {
            if (Length != 0)
            {
                Length++;
                _tail.Next = new Node(value);
                _tail.Next.Previous = _tail;
                _tail = _tail.Next;
            }
            else
            {
                Length = 1;
                _root = new Node(value);
                _tail = _root; 
            }
        }

        public void Add(IList inputList)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            if (inputList is DoubleLinkedList)
            {
                list = (DoubleLinkedList)inputList;
            }
            for (int i = 0; i < list.Length; i++)
            {
                Add(list[i]);
            }
        }

        public void AddToBegin(int value)
        {
            Length++;
            Node first = new Node(value);
            first.Next = _root;
            _root = first;
            if (!(_root.Next is null))
            {
                _root.Next.Previous = _root;
            }
        }

        public void AddToBegin(IList inputList)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            if (inputList is DoubleLinkedList)
            {
                list = (DoubleLinkedList)inputList;
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
            if (index != 0 && index != Length)
            {
                Node current = GetNodeByIndex(index - 1);
                Node tmp = new Node(value);
                tmp.Next = current.Next;
                tmp.Previous = current;
                current.Next = tmp;
                Length++;
            }
            else
            {
                if (index == 0)
                {
                    AddToBegin(value);
                }
                if (index == Length)
                {
                    Add(value);
                }
            }
        }

        public void AddByIndex(IList inputList, int index)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            if (inputList is DoubleLinkedList)
            {
                list = (DoubleLinkedList)inputList;
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
                _root.Previous = null;
                Length--;
            }
            else
            {
                Clear();
            }
        }

        public void RemoveByIndex(int index, int number = 1)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index != 0 && index != Length - 1)
            {
                Node current = _root;

                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
                if (!(current.Next is null))
                    current.Next.Previous = current;

                Length--;
            }
            else if (index == 0)
            {
                RemoveFromBegin();
            }
            else if (index == Length - 1)
            {
                Remove();
            }
            if (Length == 1)
            {
                _tail = _root;
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
            if (count > Length || count < 0 || count > Length - index)
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
                if (!(current is null))
                {
                    current.Previous = tmp;
                }
                Length = Length - count;
            }
            else if (index == Length - 1)
            {
                Remove();
            }
            else
            {
                RemoveByIndexMultyElements(count);
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
                    break;
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
            Node temp = null;
            Node current = _root;
            for (int i = 0; i < Length; i++)
            {
                temp = current.Previous;
                current.Previous = current.Next;
                current.Next = temp;
                current = current.Previous;
            }
            _tail = _root;
            if (temp != null)
            {
                _root = temp.Previous;
            }
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
            if (Length != 0)
            {
                Node currentNode = _root;
                int tmp;
                for (int i = 0; i < Length; i++)
                {
                    Node nextNode = currentNode.Next;
                    for (int j = i + 1; j < Length; j++)
                    {
                        if (currentNode.Value > nextNode.Value)
                        {
                            tmp = currentNode.Value;
                            currentNode.Value = nextNode.Value;
                            nextNode.Value = tmp;
                        }
                        nextNode = nextNode.Next;
                    }
                    currentNode = currentNode.Next;
                }
            }
        }

        public void DownSort()
        {
            if (Length != 0)
            {
                Node currentNode = _root;
                int tmp;
                for (int i = 0; i < Length; i++)
                {
                    Node nextNode = currentNode.Next;
                    for (int j = i + 1; j < Length; j++)
                    {
                        if (currentNode.Value < nextNode.Value)
                        {
                            tmp = currentNode.Value;
                            currentNode.Value = nextNode.Value;
                            nextNode.Value = tmp;
                        }
                        nextNode = nextNode.Next;
                    }
                    currentNode = currentNode.Next;
                }
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
                        current.Next.Previous = current.Next;
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
                _root.Previous = null;
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
            if (Length != 0)
            {
                Node current = _root;
                string s = current.Value + " ";
                while (!(current.Next is null))
                {
                    current = current.Next;
                    s += current.Value + " ";
                }
                return s;
            }
            else
            {
                return String.Empty;
            }
        }
        public override bool Equals(object obj)
        {
            DoubleLinkedList list = (DoubleLinkedList)obj;
            if (this._tail is null && list._tail is null)
            {
                return true;
            }
            if (this.Length != list.Length)
            {
                return false;
            }
            if (this._tail.Value != list._tail.Value)
            {
                return false;
            }
            Node currentThis = _root;
            Node currentList = list._root;
            if (currentList is null && currentThis is null)
            {
                return true;
            }

            while (!(currentThis.Next is null))
            {
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }
                currentThis = currentThis.Next;
                currentList = currentList.Next;
            }
            if (currentThis.Value != currentList.Value)
            {
                return false;
            }

            return true;
        }
        private Node GetNodeByIndex(int index)
        {
            if ((index < 0) || (index > Length))
            {
                throw new IndexOutOfRangeException();
            }

            Node root = _root;
            Node tail = _tail;

            if (index < Length / 2)
            {
                for (int i = 0; i < index; i++)
                {
                    root = root.Next;
                }

                return root;
            }
            else
            {
                for (int i = Length - 1; i >= index; i--)
                {
                    tail = tail.Previous;
                }

                return tail.Next;
            }

        }
        private void Clear()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }
    }
}
