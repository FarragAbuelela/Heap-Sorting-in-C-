internal class Program
{
    static void PushDown(ref List<int> array, int heapSize, int index)
    {
        while(index < heapSize)
        {
            int leftElement = 2 * index + 1;
            int rightElement = leftElement + 1;
            int indexOfMaxNumberBetweenLeftAndRight = 0;
            if (leftElement >= heapSize)
            {
                break;
            }
            if (rightElement >= heapSize)
            {
                indexOfMaxNumberBetweenLeftAndRight = leftElement;
            }
            else
            {
                indexOfMaxNumberBetweenLeftAndRight =
                array[leftElement] > array[rightElement] ? leftElement : rightElement;
            }

            if (array[indexOfMaxNumberBetweenLeftAndRight] > array[index])
            {
                int temp = array[indexOfMaxNumberBetweenLeftAndRight];
                array[indexOfMaxNumberBetweenLeftAndRight] = array[index];
                array[index] = temp;
                index = indexOfMaxNumberBetweenLeftAndRight;
            }
            else break;
        }
    }

    static void PushUp(ref List<int> array, int index)
    {
        while(index != 0)
        {
            int parent = (index - 1) / 2;
            if (array[parent] < array[index])
            {
                int temp = array[parent];
                array[parent] = array[index];
                array[index] = temp;
                index = parent;
            }
            else break;
        }
    }

    static void Add(ref List<int> array, int valueIndex, int value)
    {
        array[valueIndex] = value;
        PushUp(ref array, valueIndex);
    }
    
    static void RemoveMax(ref List<int> array, int valueIndex)
    {
        array[0] = array[--valueIndex];
        PushDown(ref array, valueIndex,0);
    }

    static void HeapSort(ref List<int> array)
    {
        for (var item = 1; item < array.Count; item++)
        {
            Add(ref array, item, array[item]);
        }
        for (int item = array.Count; item > 0; item--)
        {
            int maxValue = array[0];
            RemoveMax(ref array, item);
            array[item - 1] = maxValue;
        }
    }

    private static void Main(string[] args)
    {
        var heap = new List<int> {5,9,3,1,2,6,5,6 };
        HeapSort(ref heap);
        foreach (var item in heap)
        {
            Console.WriteLine(item);
        }
    }
}