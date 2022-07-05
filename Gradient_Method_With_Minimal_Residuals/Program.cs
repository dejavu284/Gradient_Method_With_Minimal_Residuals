using System;
using System.Linq;
using System.Threading;

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
                    Thread.Sleep(200);//заморозка потока, можно убрать.
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
                case 2:
                    double[,] Matrix_1 =
                    {
                        { 33, 1},
                        { 1, 11}
                    };
                    Matrix_A = Matrix_1;
                    break;
                case 3:
                    double[,] Matrix_3 =
                    {
                        { 33, 1, 2},
                        { 1, 11, 3},
                        { 2, 3, 11}
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
                Console.WriteLine("Элемент с индексом: {0}", i);
                Vector_B[i] = double.Parse(Console.ReadLine());
            }
            return Vector_B;
        }//пользовательский

        static double[] GetDefaultVector(int count)
        {
            double[] Vector = null;
            switch (count)
            {
                case 1:
                    double[] Vector_1 = { 34, 12 };
                    Vector = Vector_1;
                    break;
                case 2:
                    double[] Vector_2 = { 1, 1.1 };
                    Vector = Vector_2;
                    break;
                case 3:
                    double[] Vector_3 = { 34, 12, 23};
                    Vector = Vector_3;
                    break;
                case 4:
                    double[] Vector_4 = { 1, 1.1, 1.2 };
                    Vector = Vector_4;
                    break;
                default:
                    break;
            }
            return Vector;
        }

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
            double[] AX = new double[Vector.Length];

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
            double[] R = new double[Vector_first.Length];
            for (int i = 0; i < Vector_first.Length; i++)
            {
                R[i] = Vector_first[i] - Vector_second[i];
            }
            
            return R;
        }

        static double Dot_Product(double[] Vector_first, double[] Vector_second)
        {
            double[] NewVec = new double[Vector_first.Length];

            double sum = 0;

            for (int i = 0; i < Vector_first.Length; i++)
            {
                NewVec[i] += Vector_first[i] * Vector_second[i];
                sum += NewVec[i];
            }

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
                    Thread.Sleep(100);//заморозка потока, можно убрать.

                    Console.WriteLine("Выберете количество линейных уравнений в СЛАУ:\nДопустимые значения[2,10]");
                    int size = int.Parse(Console.ReadLine());
                    Thread.Sleep(100);//заморозка потока, можно убрать.
                    if (size >= 2 && size <= 10) Console.WriteLine("Ок.\n");
                    else
                    {
                        Console.WriteLine("Недопустимое значение, начни сначала...");
                        continue;
                    }

                    Thread.Sleep(300);//заморозка потока, можно убрать.
                    Console.WriteLine("Матрица A:");
                    Thread.Sleep(300);//заморозка потока, можно убрать.
                    bool flag1 = true;
                    while (flag1)
                    {
                        Console.WriteLine("Выберите способ создания матрицы А:\n1 - Ввод с клавиатуры\n2 - Создание рандомной матрицы\n3 - Создание матрицы для тестового примера\n");
                        Thread.Sleep(200);//заморозка потока, можно убрать.
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
                                Console.WriteLine("Есть 2 стандартных матрицы А, размерностью 2 и 3.");
                                Thread.Sleep(200);//заморозка потока, можно убрать.
                                Console.WriteLine("Будет создана матрица размерностью {0}",size);
                                if (size == 2 || size == 3) Matrix_A = GetDefaultMatrix_A(size); // Возвращает матрицу А для тестового примера
                                else
                                {
                                    Console.WriteLine("\nПод такую размерность нет тестовых примеров.\n");
                                    continue;
                                }
                                flag1 = false;
                                break;

                            default:
                                Console.WriteLine("\nВведён некоректный символ, попробуй еще раз...\n");
                                break;
                        }
                    }
                    Thread.Sleep(300);//заморозка потока, можно убрать.
                    Console.WriteLine();
                    PrintMatrix(Matrix_A); // Вывести матрицу А на экран

                    Thread.Sleep(400);//заморозка потока, можно убрать.
                    Console.WriteLine("Вектор B:");
                    Thread.Sleep(100);//заморозка потока, можно убрать.

                    bool flag2 = true;
                    while (flag2)
                    {
                        Console.WriteLine("Выберите способ создания вектора B:\n1 - Ввод с клавиатуры\n2 - Создание рандомного вектора\n3 - Создание вектора для тестового примера\n");
                        Thread.Sleep(100);//заморозка потока, можно убрать.
                        Console.Write(": ");
                        int otvet = int.Parse(Console.ReadLine());
                        switch (otvet)
                        {
                            case 1:
                                Vector_B = GetUserVector(size); // Возвращает введённый пользователем вектор В
                                flag2 = false;
                                break;

                            case 2:
                                Console.WriteLine("Введите диапазон значений(от - до)\nОт:");
                                double first = double.Parse(Console.ReadLine());
                                Console.WriteLine("До:");
                                double second = double.Parse(Console.ReadLine());
                                Vector_B = GetRandomVector(size, first, second); // Возвращает рандомный вектор В выбранного размера, с диапазоном значений
                                flag2 = false;
                                break;

                            case 3:
                                Console.WriteLine("Есть 2 стандартных вектора B, размерностью 2 и 3.");
                                Thread.Sleep(200);//заморозка потока, можно убрать.
                                Console.WriteLine("Будет создан вектор подходящего под СЛАУ размера");
                                if (size == 2)
                                {
                                    Vector_B = GetDefaultVector(1); // Возвращает вектор В для тестового примера
                                }
                                else if (size == 3)
                                {
                                    Vector_B = GetDefaultVector(3); // Возвращает вектор В для тестового примера
                                }
                                else
                                {
                                    Console.WriteLine("Под такую размерность нет тестовых примеров.\n");
                                    continue;
                                }
                                flag2 = false;
                                break;

                            default:
                                Console.WriteLine("Введён некоректный символ, попробуй еще раз...\n");
                                break;
                        }
                    }
                    Console.WriteLine();
                    Thread.Sleep(300);//заморозка потока, можно убрать.
                    PrintVector(Vector_B); // Вывести вектор В на экран

                    Thread.Sleep(300);//заморозка потока, можно убрать.
                    Console.WriteLine("Вектор X:");
                    bool flag3 = true;
                    while (flag3)
                    {
                        Console.WriteLine("Выберите способ создания вектора X:\n1 - Ввод с клавиатуры\n2 - Создание рандомного вектора\n3 - Создание вектора для тестового примера\n");
                        Thread.Sleep(200);//заморозка потока, можно убрать.
                        Console.Write(": ");
                        int otvet = int.Parse(Console.ReadLine());
                        switch (otvet)
                        {
                            case 1:
                                Vector_X = GetUserVector(size); // Возвращает введённый пользователем вектор X
                                flag3 = false;
                                break;

                            case 2:
                                Console.WriteLine("Введите диапазон значений(от - до)\nОт:");
                                double first = double.Parse(Console.ReadLine());
                                Console.WriteLine("До:");
                                double second = double.Parse(Console.ReadLine());
                                Vector_X = GetRandomVector(size, first, second); // Возвращает рандомный вектор X выбранного размера, с диапазоном значений
                                flag3 = false;
                                break;

                            case 3:
                                Console.WriteLine("Есть 2 стандартных вектора X, размерностью 2 и 3.");
                                Thread.Sleep(200);//заморозка потока, можно убрать.
                                Console.WriteLine("Будет создан вектор подходящего под СЛАУ размера");
                                if (size == 2)
                                {
                                    Vector_X = GetDefaultVector(2); // Возвращает вектор X для тестового примера
                                }
                                else if (size == 3)
                                {
                                    Vector_X = GetDefaultVector(4); // Возвращает вектор X для тестового примера
                                }
                                else
                                {
                                    Console.WriteLine("Под такую размерность нет тестовых примеров.\n");
                                    continue;
                                }
                                flag3 = false;
                                break;

                            default:
                                Console.WriteLine("Введён некоректный символ, попробуй еще раз...\n");
                                break;
                        }
                    }
                    Console.WriteLine();
                    Thread.Sleep(200);//заморозка потока, можно убрать.
                    PrintVector(Vector_X); // Вывести вектор X на экран 

                    Thread.Sleep(400);//заморозка потока, можно убрать.
                    Console.WriteLine("В итоге начальные данные такие...\n");
                    Thread.Sleep(400);//заморозка потока, можно убрать.
                    Console.WriteLine("Матрица A:");
                    Thread.Sleep(200);//заморозка потока, можно убрать.
                    PrintMatrix(Matrix_A);
                    Thread.Sleep(400);//заморозка потока, можно убрать.
                    Console.WriteLine("Вектор B:");
                    Thread.Sleep(200);//заморозка потока, можно убрать.
                    PrintVector(Vector_B);
                    Thread.Sleep(400);//заморозка потока, можно убрать.
                    Console.WriteLine("Вектор X:");
                    Thread.Sleep(200);//заморозка потока, можно убрать.
                    PrintVector(Vector_X);
                    Thread.Sleep(400);//заморозка потока, можно убрать.


                    double[] Old_X = new double[size];
                    bool flag = false;
                    int count = 0;
                    double alpha;
                    double e;
                    Console.WriteLine("Нажмите любую клавишу чтоб продолжить");
                    Console.ReadKey(true);
                    while (count < 100)
                    {
                        Console.WriteLine("//===========================================================================//");
                        Console.WriteLine("//=============================== Шаг - {0} ===================================//", count);
                        Console.WriteLine("//===========================================================================//\n");

                        Console.WriteLine("X:");
                        for (int i = 0; i < Vector_X?.Length; i++)
                        {
                            Console.Write("Х{0} = {1,5:0.000}\n", i, Vector_X?[i]);
                        }
                        Console.WriteLine();

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

                        if (AR_AR != 0 || AR_R != 0) alpha = AR_R / AR_AR;// Считаем альфа
                        else
                        {
                            Console.WriteLine("(AR,AR) = 0, делить на ноль нельзя, попробуйте другие начальные данные...");
                            continue;
                        }
                        Console.WriteLine("alpha:\n  {0}\n", alpha);

                        Console.WriteLine("Старые:");

                        for (int i = 0; i < size; i++)
                        {
                            Old_X[i] = Vector_X[i];// Сохраняем старые X
                            Console.WriteLine("Х{0} = {1,5:0.000}", i, Old_X[i]);
                        }
                        Console.WriteLine();

                        Console.WriteLine("Новые:");
                        for (int i = 0; i < Vector_X?.Length; i++)
                        {
                            Vector_X[i] = (Vector_X[i] + (alpha * R[i]));// Считаем новые X
                            Console.Write("Х{0} = {1,5:0.000}\n", i, Vector_X?[i]);
                        }
                        Console.WriteLine();

                        double[] Eps_arr = new double[size];

                        for (int i = 0; i < Eps_arr.Length; i++)
                        {
                            Eps_arr[i] = Math.Abs(Old_X[i] - Vector_X[i]);
                            Console.WriteLine("Эпсилон_{0}: {1,6:0.0000}",i, Eps_arr[i]);
                        }
                        Console.WriteLine();
                        
                        e = Eps_arr.Max();// Считаем Епсилон

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
                        Console.WriteLine("Окончательный ответ:");
                        for (int i = 0; i < size; i++)
                        {
                            Console.WriteLine("Х{0} = {1,5:0.000}", i, Old_X[i]);
                        }
                    }

                    else Console.WriteLine("Программа зациклилась, попробуйте другий значения\n");
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
