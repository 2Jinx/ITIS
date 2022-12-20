using System;
namespace ArrayTask
{
	public class Array
	{
		private int countLines;
		private int countColumns;
		private int[,] Matrix;

		public Array(int n, int m)
		{
            if (n < 1)
                throw new ArgumentException("количество строк должно быть больше 1");
            if (m < 1)
                throw new ArgumentException("количество столбцов должно быть больше 1");

            countLines = n;
			countColumns = m;
            Matrix = new int[countColumns, countLines];
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					Matrix[i, j] = 0;
		}

		public Array() : this(1, 1)
		{
            Matrix[1, 1] = 0;
        }
        
        public void PrintMatrix()
        {
            for (int i = 0; i < countColumns; i++)
            {
                for (int j = 0; j < countLines; j++)
                    Console.Write($"{Matrix[i, j],4}");
                Console.WriteLine();
                Console.WriteLine(); 
            }
        }

        public void SaveMatrixInFile(string file)
        {

            using (StreamWriter saver = new StreamWriter(file))
            {
                for (int i = 0; i < countColumns; i++)
                {
                    for (int j = 0; j < countColumns; j++)
                        saver.Write("{0} ", Matrix[i, j]);
                    saver.WriteLine();
                }
            }
        }

        public int[,] MatrixReaderFromFile(string file)
        {
            using StreamReader reader = new StreamReader(file);
            int[,] matrix = new int[countColumns, countColumns];
            for (int i = 0; i < countColumns; i++)
            {
                string[] s = reader.ReadLine().Split(' ');
                for (int j = 0; j < countColumns; j++)
                {
                    matrix[i, j] = int.Parse(s[j]);
                }

            }
            return matrix;
        }

        public int[,] GenerateRandomMatrix()
        {
            Random r = new Random();
            for (int i = 0; i < countColumns; i++)
                for (int j = 0; j < countLines; j++)
                    Matrix[i, j] = r.Next(10);

            return Matrix;
        }

        public void MatrixTransposition()
        {
            for (int i = 0; i < countColumns; i++)
            {
                for (int j = i + 1; j < countLines; j++)
                {
                    var t = Matrix[i, j];
                    Matrix[i, j] = Matrix[j, i];
                    Matrix[j, i] = t;
                }
            }
        }

        public bool IsSymmetric()
        {
            bool symm = true;
            for (int i = 0; i < countLines; i++)
            {
                for (int j = 0; j < countColumns; j++)
                    if (Matrix[i, j] != Matrix[j, i])
                    {
                        symm = false;
                        break;
                    }
                if (!symm)
                    break;
            }
            return symm;
        }

        public static Array operator+ (Array a, Array b)
        {
            if ((a.countLines == b.countLines) && (a.countColumns == b.countColumns))
            {
                Array c = new Array(a.countColumns, a.countLines);
                for (int i = 0; i < a.countColumns; i++)
                    for (int j = 0; j < a.countLines; j++)
                        c.Matrix[i, j] = a.Matrix[i, j] + b.Matrix[i, j];
                return c;     
            }
            else
            {
                throw new ArgumentException("Размеры матриц должны быть одинаковыми!!");
            }
        }

        public static Array operator- (Array a, Array b)
        {
            if ((a.countLines == b.countLines) && (a.countColumns == b.countColumns))
            {
                Array c = new Array(a.countColumns, a.countLines);
                for (int i = 0; i < a.countColumns; i++)
                    for (int j = 0; j < a.countLines; j++)
                        c.Matrix[i, j] = a.Matrix[i, j] - b.Matrix[i, j];
                return c;
            }
            else
            {
                throw new ArgumentException("Размеры матриц должны быть одинаковыми !!");
            }
        }

        public static Array operator* (Array a, int k)
        {
            Array b = new Array(a.countColumns, a.countLines);
            for (int i = 0; i < a.countColumns; i++)
                for (int j = 0; j < a.countLines; j++)
                    b.Matrix[i, j] = a.Matrix[i, j] * k;
            return b;
        }

        public static Array operator *(Array a, Array b)
        {
            if(a.countColumns == b.countLines)
            {
                Array c = new Array(a.countColumns, b.countLines);
                for (int i = 0; i < a.countColumns; i++)
                    for (int j = 0; j < b.countColumns; j++)
                        for (int k = 0; k < b.countLines; k++)
                            c.Matrix[i, j] += a.Matrix[i, k] * b.Matrix[k, j];
                return c;
            }
            else
            {
                throw new ArgumentException("Матрицы невозиожно перемножить !!");
            }
        }
    }
}

