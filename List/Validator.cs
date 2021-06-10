using System;

namespace List
{
    public class Validator
    {
        public void NullValidator(int value)
        {
            throw new ArgumentNullException(($"{value} is null"));
        }



        public void NullValidator(IList value)
        {
            throw new ArgumentNullException(($"{value} is null"));
        }

        public void OutOfRangeValidator(int[] array, int index)
        {
            if (index >= array.Length - 1 || index < 0)
            {
                throw new IndexOutOfRangeException($"{index} id out of {array}");
            }
        }
    }
}
