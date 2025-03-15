namespace _2DimensionLists
{
    class Matrix
    {
        private int[,] matrix;
        private int _size;

        public Matrix(int size)
        {
            if (size <1)
                throw new ArgumentException("Invalid value for the matrix");
            _size = size;
            matrix = new int[size, size];
            Random rnd = new Random();
            for (int i = 0, k = 0; i < _size; i++)
                for (int j = 0; j < _size; j++, k++)
                    matrix[i, j] = rnd.Next(0,100);
        }

        public bool IsDiagonallyDominant()
        {
            for (int i = 0; i < _size; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < _size; j++)
                {
                    if (i != j)
                        rowSum += Math.Abs(matrix[i, j]);
                }
                if (Math.Abs(matrix[i, i]) < rowSum)
                    return false;
            }
            return true;
        }

        public int LongestConsecutiveSequence()
        {
            int maxLength = 1;

            void CheckSequence(int[] arr)
            {
                int count = 1;
                for (int j = 1; j < arr.Length; j++)
                {
                    if (arr[j] == arr[j - 1])
                    {
                        count++;
                        maxLength = Math.Max(maxLength, count);
                    }
                    else
                    {
                        count = 1;
                    }
                }
            }

            for (int i = 0; i < _size; i++)
            {
                int[] row = new int[_size];
                int[] col = new int[_size];
                for (int j = 0; j < _size; j++)
                {
                    row[j] = matrix[i, j];
                    col[j] = matrix[j, i];
                }
                CheckSequence(row);
                CheckSequence(col);
            }

            for (int d = -_size + 1; d < _size; d++)
            {
                int[] diag1 = new int[_size];
                int[] diag2 = new int[_size];
                int count1 = 0, count2 = 0;
                for (int i = 0; i < _size; i++)
                {
                    int j1 = i + d;
                    int j2 = _size - 1 - i - d;
                    if (j1 >= 0 && j1 < _size) diag1[count1++] = matrix[i, j1];
                    if (j2 >= 0 && j2 < _size) diag2[count2++] = matrix[i, j2];
                }
                CheckSequence(diag1[..count1]);
                CheckSequence(diag2[..count2]);
            }

            return maxLength;
        }

        public void Display()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
