namespace StruttureDati
{
    public class IntArray
    {
        int[] array;

        public int Length
        {
            get { return array.Length; }
        }

        public IntArray(int numberOfElement) 
        {
            array = new int[numberOfElement];
        }

        public IntArray(int[] array)
        {
            this.array = array;
        }

        public IntArray(int numberOfElement, int min, int max) :this(numberOfElement)
        {
            Random rnd = new Random();

            for(int i=0; i<array.Length; i++)
            {
                array[i]= rnd.Next(min,max);
            }
        }

        public IntArray(int numberOfElement, bool ordered) : this(numberOfElement)
        {
            Random rnd = new Random();
            if (ordered)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = i;
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(array.Length); ;
                }
            }
        }

        
        public int ElementAt(int index)
        {
            try
            {
                return array[index];
            }
            catch (Exception e)
            {
                throw new Exception("ElementAt Error: " + e.Message);
            }
        }

        public void InsertElementAt(int index, int value)
        {
            try
            {
                array[index] = value;
            }
            catch (Exception e)
            {
                throw new Exception("InsertElementAt Error: " + e.Message);
            }
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

       
        public void BubbleSort()
        {
            throw new NotImplementedException();
        }

        public void SelectionSort()
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                // cerco il minimo
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (array[j] < array[min_idx])
                        min_idx = j;

                // Scambio
                int temp = array[min_idx];
                array[min_idx] = array[i];
                array[i] = temp;
            }
        }

        public int? Search(int element)
        {
            for(int i=0; i<array.Length; i++)
            {
                if (array[i] == element)
                    return i;
            }

            return null;

        }

        public int? BinarySearch(int element)
        {
            int start = 0, end = array.Length - 1, middle = 0;

            while (start <= end)
            {
                middle = (start + end) / 2;
                if (element < array[middle])
                {
                    end = middle - 1;
                }
                else
                {
                    if (element > array[middle])
                        start = middle + 1;
                    else
                        return middle;
                }
            }
            return null;
        }

    }
}
