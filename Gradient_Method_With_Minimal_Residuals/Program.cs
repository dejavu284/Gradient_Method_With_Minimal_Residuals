using System;

namespace Gradient_Method_With_Minimal_Residuals
{
    class Program
    {
        static int[,] GetRandomMatrix_A()
        {
            int[,] Matrix_A = new int[2, 2];

            Random r = new Random();

            for (int i = 0; i < Matrix_A.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix_A.GetLength(1); j++)
                {
                    Matrix_A[i, j] = r.Next(-35, 35);
                }
            }
            return Matrix_A;
        }//рандомная

        static int[,] GetUserMatrix_A()
        {
            int[,] Matrix_A = new int[2, 2];

            for (int i = 0; i < Matrix_A.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix_A.GetLength(1); j++)
                {
                    Matrix_A[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine();
            return Matrix_A;
        }//пользовательская

        static int[,] GetDefaultMatrix_A(int count)
        {
            int[,] Matrix_A = null;
            switch (count)
            {
                case 1:
                    int[,] Matrix_1 =
                    {
                        { 33, 1},
                        { 1, 11}
                    };
                    Matrix_A = Matrix_1;
                    break;
                case 2:
                    int[,] Matrix_2 =
                    {
                        { 10, 11},
                        { 10, 11}
                    };
                    Matrix_A = Matrix_2;
                    break;
                case 3:
                    int[,] Matrix_3 =
                    {
                        { 10, 11, 12},
                        { 11, 11, 12},
                        { 12, 12, 12}
                    };
                    Matrix_A = Matrix_3;
                    break;
                default:
                    break;
            }
            return Matrix_A;
        }//стандартная

        static int[] GetRandomVector_B()
        {
            int[] Vector_B = new int[2];

            Random r = new Random();

            for (int i = 0; i < Vector_B.Length; i++)
            {
                Vector_B[i] = r.Next(-35, 35);
            }
            return Vector_B;
        }//рандомный

        static int[] GetUserVector_B()
        {
            int[] Vector_B = new int[2];

            for (int i = 0; i < Vector_B.Length; i++)
            {
                Vector_B[i] = int.Parse(Console.ReadLine());
            }
            return Vector_B;
        }//пользовательский

        static void PrintMatrix(int[,] Matrix)
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write("{0,4}",Matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }//вывод матрицы

        static void PrintVector<T>(T[] Vector)
        {
            for (int i = 0; i < Vector.Length; i++)
            {
                Console.WriteLine("{0,7:0.00}", Vector[i]);
            }
            Console.WriteLine();
        }//вывод вектора

        static double[] GetRandomVector_X()
        {
            double[] Vector_X = new double[2];

            Random r = new Random();

            for (int i = 0; i < Vector_X.Length; i++)
            {
                Vector_X[i] = r.NextDouble() + 0.2;
            }
            return Vector_X;
        }//рандомный

        static double[] GetUserVector_X()
        {
            double[] Vector_X = new double[2];

            for (int i = 0; i < Vector_X.Length; i++)
            {
                Vector_X[i] = double.Parse(Console.ReadLine());
            }
            return Vector_X;
        }//пользовательский

        static double[] MatrixOnVector(int[,] Matrix, double[] Vector)
        {
            double[] AX = new double[2];

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Vector.Length; j++)
                {
                    AX[i] += Matrix[i, j] * Vector[j];

                }
            }
            return AX;
        }//матрицу на вектор

        static double[] Vector_Subtraction_Vector(int[] Vector_first, double[] Vector_second)
        {
            double[] R = new double[2];
            R[0] = Vector_first[0] - Vector_second[0];
            R[1] = Vector_first[1] - Vector_second[1];
            return R;
        }

        static double Dot_Product(double[] Vector_first, double[] Vector_second)
        {
            double[] NewVec = new double[2];

            NewVec[0] += Vector_first[0] * Vector_second[0];
            NewVec[1] += Vector_first[1] * Vector_second[1];

            double sum = NewVec[0] + NewVec[1];

            return sum;

        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Начальные данные:\n");

//===========================================================================================// Создать матрицу А

                Console.WriteLine("Матрица A:");
                //int[,] Matrix_A = GetUserMatrix_A(); // Возвращает введённую пользователем матрицу А

                //int[,] Matrix_A = GetRandomMatrix_A(); // Возвращает рандомную матрицу А

                int[,] Matrix_A = GetDefaultMatrix_A(1); // Возвращает стандартную матрицу А

                PrintMatrix(Matrix_A); // Вывести матрицу А на экран

//===========================================================================================// Создать вектор В

                Console.WriteLine("Вектор B:");

                //int[] Vector_B = GetUserVector_B(); // Возвращает введённый пользователем вектор В

                //int[] Vector_B = GetRandomVector_B(); // Возвращает рандомный вектор В

                int[] Vector_B = { 34, 12 }; // Создаёт стандартный вектор В

                PrintVector(Vector_B); // Вывести вектор В на экран

//===========================================================================================// Создать вектор X

                Console.WriteLine("Вектор X:");
                //double[] Vector_X = GetRandomVector_X(); // Возвращает рандомный вектор X

                //double[] Vector_X = GetRandomVector_X(); // Возвращает Возвращает введённый пользователем вектор X

                double[] Vector_X = { 1, 1.1 }; // Задали значения X

                PrintVector(Vector_X); // Вывести вектор X на экран 

//===========================================================================================// Основная программа

                double Old_X0 = 0;
                double Old_X1 = 0;
                bool flag = false;
                int count = 0;
                while (count < 100)
                {
                    Console.WriteLine("//===========================================================================//");
                    Console.WriteLine("//=============================== Шаг - {0} ===================================//", count);
                    Console.WriteLine("//===========================================================================//\n");

                    Console.WriteLine("X:\n  Х1 = {0,5:0.000}\n  X2 = {1,5:0.000}\n", Vector_X[0], Vector_X[1]);

                    double[] AX = MatrixOnVector(Matrix_A, Vector_X);// Считаем AX
                    Console.WriteLine("AX:");
                    PrintVector(AX);

                    double[] R = Vector_Subtraction_Vector(Vector_B, AX);// Считаем R
                    Console.WriteLine("R:");
                    PrintVector(R);

                    double[] AR = MatrixOnVector(Matrix_A, R);// Считаем AR
                    Console.WriteLine("AR:");
                    PrintVector(AR);

                    double AR_R = Dot_Product(AR, R);// Считаем AR_R
                    Console.WriteLine("(AR,R):\n{0,7:0.00}\n", AR_R);

                    double AR_AR = Dot_Product(AR, AR);// Считаем AR_AR
                    Console.WriteLine("(AR,AR):\n{0,7:0.00}\n", AR_AR);

                    double alpha = AR_R / AR_AR;// Считаем 
                    Console.WriteLine("alpha:\n{0,8:0.0000}\n", alpha);

                    Old_X0 = Vector_X[0];// Сохраняем старые X
                    Old_X1 = Vector_X[1];
                    Console.WriteLine("Старые:\nХ1 = {0,5:0.000}\nX2 = {1,5:0.000}\n", Old_X0, Old_X1);

                    Vector_X[0] = (Vector_X[0] + (alpha * R[0]));// Считаем новые X
                    Vector_X[1] = (Vector_X[1] + (alpha * R[1]));
                    Console.WriteLine("Новые:\nХ1 = {0,5:0.000}\nX2 = {1,5:0.000}\n", Vector_X[0], Vector_X[1]);

                    double[] Eps_arr = new double[2];

                    Eps_arr[0] = Math.Abs(Old_X0 - Vector_X[0]);
                    Console.WriteLine("Эпсилон_1: {0,6:0.0000}", Eps_arr[0]);
                    Eps_arr[1] = Math.Abs(Old_X1 - Vector_X[1]);
                    Console.WriteLine("Эпсилон_2: {0,6:0.0000}", Eps_arr[1]);

                    double e = Math.Max(Eps_arr[0], Eps_arr[1]);// Считаем Епсилон
                    Console.WriteLine("Эпсилон max:\n{0,8:0.0000}\n", e);

                    count++;
                    if (e < 0.001)// Проверяем подходит ли по точности Епсилон
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    Console.WriteLine("Окончательный ответ Х1 = {0,5:0.000}, X2 = {1,5:0.000}", Old_X0, Old_X1);
                }

                else Console.WriteLine("Программа зациклилась, попробуйте другий значения");
                Console.ReadKey(true);

            }
        }
    }
}
