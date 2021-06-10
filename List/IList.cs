using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public interface IList
    {
        void Add(int value);
        void Add(IList inputList);
        void AddToBegin(int value);
        void AddToBegin(IList inputList);
        void AddByIndex(int value, int index);
        void AddByIndex(IList inputList, int index);
        void Remove();
        void RemoveFromBegin();
        void RemoveByIndex(int index, int number = 1);
        void RemoveMultyElements(int count);
        void RemoveByIndexMultyElements(int count, int index = 0);
        int GetFirstIndexByValue(int value);
        void SetValueByIndex(int value, int index);
        void RevertList();
        int GetMaxValue();
        int GetMinValue();
        int GetFirstIndexOfMaxValue();
        int GetFirstIndexOfMinValue();
        void UpSort();
        void DownSort();
        int RemoveFirstByValue(int value);
        int RemoveAllByValue(int value);
    }
}
