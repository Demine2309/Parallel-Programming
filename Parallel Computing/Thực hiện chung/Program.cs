#region Đề bài
/*
 * Thực hiện bài nhân ma trận với vector, thử nghiệm với các kích thước khác nhau trong bài thực hành, in kết quả vào bài báo cáo. Đọc hiểu từng đoạn code
 */
#endregion

using System;
using System.Text;
using System.Threading.Tasks;

namespace ParallelComputing
{
    public class Matrix
    {
        private double[,] data;

        public Matrix(int rows, int cols)
        {
            data = new double[rows, cols];
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

            var tasks = new Task[data.GetLength(0)];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                int rowIndex = i;
                tasks[i] = Task.Run(() =>
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        result[rowIndex] += data[rowIndex, j] * vector[j];
                    }
                });
            }

            Task.WhenAll(tasks).Wait(); // Đợi tất cả các tác vụ hoàn thành.

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("Nhập số hàng của ma trận: ");
            int numRows = int.Parse(Console.ReadLine());

            Console.Write("Nhập số cột của ma trận: ");
            int numCols = int.Parse(Console.ReadLine());

            Matrix matrix = new Matrix(numRows, numCols);

            Console.WriteLine("Nhập giá trị cho ma trận:");
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    Console.Write($"Nhập giá trị cho matrix[{i},{j}]: ");
                    double value = double.Parse(Console.ReadLine());
                    matrix.SetData(i, j, value);
                }
            }

            Console.WriteLine("Nhập giá trị của vector:");
            double[] vector = new double[numCols];
            for (int i = 0; i < numCols; i++)
            {
                Console.Write($"Nhập giá trị cho vector[{i}]: ");
                vector[i] = double.Parse(Console.ReadLine());
            }

            try
            {
                double[] result = matrix.MultiplyByVector(vector);

                Console.WriteLine("Kết quả sau khi nhân ma trận với vector (song song):");
                for (int i = 0; i < result.Length; i++)
                {
                    Console.WriteLine($"result[{i}] = {result[i]}");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}