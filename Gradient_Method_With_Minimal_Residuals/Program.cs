using System;

namespace Gradient_Method_With_Minimal_Residuals
{
    class Program
    {
        static double[,] GetRandomMatrix_A(int size, double start, double end)
        {
            double[,] Matrix_A = new double[size, size];

            Random r = new Random();

            double between = end - start;

            for (int i = 0; i < Matrix_A.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix_A.GetLength(1); j++)
                {
                    Matrix_A[i, j] = start + r.NextDouble() * between;
                }
            }
            return Matrix_A;
        }//рандомная

        static double[,] GetUserMatrix_A(int size)
        {
            Console.WriteLine("Матрица должна быть симмитричной");
            double[,] Matrix_A = new double[size, size];

            for (int i = 0; i < Matrix_A.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix_A.GetLength(1); j++)
                {
                    Console.WriteLine("Элемент с индексами: {0}{1}",i,j);
                    Matrix_A[i, j] = double.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine();
            return Matrix_A;
        }//пользовательская

        static double[,] GetDefaultMatrix_A(int count)
        {
            double[,] Matrix_A = null;
            switch (count)
            {
                case 1:
                    double[,] Matrix_1 =
                    {
                        { 33, 1},
                        { 1, 11}
                    };
                    Matrix_A = Matrix_1;
                    break;
                case 2:
                    double[,] Matrix_2 =
                    {
                        { 10, 11},
                        { 11, 11}
                    };
                    Matrix_A = Matrix_2;
                    break;
                case 3:
                    double[,] Matrix_3 =
                    {
                        { 33, 1, 2},
                        { 1, 11, 3},
                        { 2, 3, 12}
                    };
                    Matrix_A = Matrix_3;
                    break;
                default:
                    break;
            }
            return Matrix_A;
        }//стандартная

        static double[] GetRandomVector(int size, double start, double end)
        {
            double[] Vector_B = new double[size];

            Random r = new Random();

            double between = end - start;

            for (int i = 0; i < Vector_B.Length; i++)
            {
                Vector_B[i] = start + r.NextDouble() * between;
            }
            return Vector_B;
        }//рандомный

        static double[] GetUserVector(int size)
        {
            double[] Vector_B = new double[size];

            for (int i = 0; i < Vector_B.Length; i++)
            {
                Vector_B[i] = double.Parse(Console.ReadLine());
            }
            return Vector_B;
        }//пользовательский

        static void PrintMatrix<T>(T[,] Matrix)
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write("{0,7:0.00}", Matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }//вывод матрицы

        static void PrintVector<T>(T[] Vector)
        {
            for (int i = 0; i < Vector?.Length; i++)
            {
                Console.WriteLine("{0,7:0.00}", Vector[i]);
            }
            Console.WriteLine();
        }//вывод вектора

        static double[] MatrixOnVector(double [,] Matrix, double[] Vector)
        {
            double[] AX = new double[2];

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Vector?.Length; j++)
                {
                    AX[i] += Matrix[i, j] * Vector[j];

                }
            }
            return AX;
        }//матрицу на вектор

        static double[] Vector_Subtraction_Vector(double[] Vector_first, double[] Vector_second)
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
            try
            {
                while (true)
                {
                    double[,] Matrix_A = null;
                    double[] Vector_B = null;
                    double[] Vector_X = null;
                    Console.WriteLine("Начальные данные:\n");

                    Console.WriteLine("Выберете количество линейных уравнений в слау:");
                    int size = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ок.\n");

                    Console.WriteLine("Матрица A:");
                    bool flag1 = true;
                    while (flag1)
                    {
                        Console.WriteLine("Выберите способ создания матрицы А:\n1 - Ввод с клавиатуры\n2 - Создание рандомной матрицы\n3 - Создание стандартной матрицы\n");
                        Console.Write(": ");
                        int otvet = int.Parse(Console.ReadLine());
                        switch (otvet)
                        {
                            case 1:
                                Matrix_A = GetUserMatrix_A(size); // Возвращает введённую пользователем матрицу А выбранного размера
                                flag1 = false;
                                break;

                            case 2:
                                Console.WriteLine("Введите диапазон значений(от - до)\nОт:");
                                double first = double.Parse(Console.ReadLine());
                                Console.WriteLine("До:");
                                double second = double.Parse(Console.ReadLine());
                                Matrix_A = GetRandomMatrix_A(size, first, second); // Возвращает рандомную матрицу А выбранного размера, с диапазоном значений
                                flag1 = false;
                                break;

                            case 3:
                                Matrix_A = GetDefaultMatrix_A(1); // Возвращает стандартную матрицу А, есть несколько стандартных матриц, возращает матрицу по номеру
                                flag1 = false;
                                break;

                            default:
                                Console.WriteLine("Введён некоректный символ, попробуй еще раз...");
                                break;
                        }
                    }
                    Console.WriteLine();
                    PrintMatrix(Matrix_A); // Вывести матрицу А на экран


                    Console.WriteLine("Вектор B:");

                    //Vector_B = GetUserVector(size); // Возвращает введённый пользователем вектор В

                    //Vector_B = GetRandomVector(size, 10.2, 20.2); // Возвращает рандомный вектор В

                    //Vector_B = { 34, 12 }; // Создаёт стандартный вектор В

                    PrintVector(Vector_B); // Вывести вектор В на экран


                    Console.WriteLine("Вектор X:");
                    //Vector_X = GetUserVector(); // Возвращает введённый пользователем вектор X

                    //Vector_X = GetRandomVector(); // Возвращает рандомный вектор X

                    //Vector_X = { 1, 1.1 }; // Задали значения X

                    PrintVector(Vector_X); // Вывести вектор X на экран 


                    double Old_X0 = 0;
                    double Old_X1 = 0;
                    bool flag = false;
                    int count = 0;
                    while (count < 100)
                    {
                        Console.WriteLine("//===========================================================================//");
                        Console.WriteLine("//=============================== Шаг - {0} ===================================//", count);
                        Console.WriteLine("//===========================================================================//\n");

                        Console.WriteLine("X:\n  Х1 = {0,5:0.000}\n  X2 = {1,5:0.000}\n", Vector_X?[0], Vector_X?[1]);

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
            catch
            {
                Console.WriteLine("Что-то пошло не так)");
            }
        }
    }
}
