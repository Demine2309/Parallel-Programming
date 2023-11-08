#region Đề bài
/*
 * Thực hiện bài nhân ma trận với vector, thử nghiệm với các kích thước khác nhau trong bài thực hành, in kết quả vào bài báo cáo. Đọc hiểu từng đoạn code
 */
#endregion

using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ParallelComputing
{
    public class Matrix
    {
        private double[,] data;
        private Random random;

        public Matrix(int rows, int cols)
        {
            data = new double[rows, cols];
            random = new Random();
        }

        public void SetData(int row, int col, double value)
        {
            data[row, col] = value;
        }

        public double[] MultiplyByVector(double[] vector)
        {
            if (data.GetLength(1) != vector.Length)
            {
                throw new ArgumentException("Kích thước ma trận và vector không phù hợp để thực hiện phép nhân.");
            }

            double[] result = new double[data.GetLength(0)];


            // Sử dụng đa luồng để tính các phần tử của vector mới song song
            Parallel.For(0, data.GetLength(0), rowIndex =>
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    result[rowIndex] += data[rowIndex, j] * vector[j];
                }
            });

            // Tính lần lượt các phần tử của Vector mới
            //for (int rowIndex = 0; rowIndex < data.GetLength(0); rowIndex++)
            //{
            //    for (int j = 0; j < data.GetLength(1); j++)
            //    {
            //        result[rowIndex] += data[rowIndex, j] * vector[j];
            //    }
            //}

            return result;
        }

        public void DisplayMatrix()
        {
            Console.WriteLine("Matrix đầu vào:");

            for (int i = 1; i <= data.GetLength(0); i++)
            {
                for (int j = 1; j <= data.GetLength(1); j++)
                {
                    Console.Write($"{data[i - 1, j - 1]}\t");
                }

                Console.WriteLine();
            }
        }

        public void DisplayVector(double[] vector)
        {
            Console.WriteLine("Vector Đầu vào:");

            for (int i = 1; i <= vector.Length; i++)
            {
                Console.WriteLine(vector[i - 1]);
            }
        }

        public void RandomizeMatrix()
        {
            for (int i = 1; i <= data.GetLength(0); i++)
            {
                for (int j = 1; j <= data.GetLength(1); j++)
                {
                    data[i - 1, j - 1] = random.Next(-50, 51);
                }
            }
        }

        public void RandomizeVector(double[] vector)
        {
            for (int i = 1; i <= vector.Length; i++)
            {
                vector[i - 1] = random.Next(-50, 51);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("TÍNH TÍCH CỦA MA TRẬN VÀ VECTOR\n\n");

            Console.Write("Nhập số hàng của ma trận: ");
            int numRows = int.Parse(Console.ReadLine());

            Console.Write("Nhập số cột của ma trận: ");
            int numCols = int.Parse(Console.ReadLine());

            // Tạo các phần tử của ma trận
            Matrix matrix = new Matrix(numRows, numCols);
            matrix.RandomizeMatrix();

            Console.WriteLine();
            matrix.DisplayMatrix();

            // Tạo các phần tử của vector
            double[] vector = new double[numCols];
            matrix.RandomizeVector(vector);

            Console.WriteLine();
            matrix.DisplayVector(vector);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                double[] result = matrix.MultiplyByVector(vector);
                stopwatch.Stop();
                TimeSpan elapsedTime = stopwatch.Elapsed;

                Console.WriteLine("\nKết quả sau khi nhân ma trận với vector, ta thu được một vector mới: ");

                for (int i = 1; i <= result.Length; i++)
                {
                    Console.WriteLine($"Vector[{i}]: {result[i - 1]}");
                }

                Console.WriteLine($"\nThời gian thực hiện: {elapsedTime.TotalMilliseconds} ms");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}