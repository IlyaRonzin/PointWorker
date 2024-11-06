using System;
using System.Collections.Generic;

namespace PointWorker
{
    public class Program
    {
        private static List<Point> points = new List<Point>();  // Список точек

        public static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в систему работы с точками!");
                Console.WriteLine("1. Создать точку");
                Console.WriteLine("2. Найти расстояние между точками");
                Console.WriteLine("3. Увеличить X на 1");
                Console.WriteLine("4. Уменьшить Х на 1");
                Console.WriteLine("5. Вернуть целую часть координаты X");
                Console.WriteLine("6. Вернуть кординату Y");
                Console.WriteLine("7. Найти расстояние между точками через +");
                Console.WriteLine("8. Увеличить координату Х");
                Console.WriteLine("9. Вывести все точки");
                Console.WriteLine("10. Выйти");
                Console.Write("Выберите действие: ");

                // Считывание выбора пользователя
                string choice = Console.ReadLine();

                // Выполнение действия в зависимости от выбора пользователя
                switch (choice)
                {
                    case "1":
                        CreatePoint();
                        break;
                    case "2":
                        GetDistancePoints();
                        break;
                    case "3":
                        IncreaseX();
                        break;
                    case "4":
                        DecreaseX();
                        break;
                    case "5":
                        GetIntegerPartOfX();
                        break;
                    case "6":
                        GetYCoordinate();
                        break;
                    case "7":
                        GetDistanceUsingPlusOperator();
                        break;
                    case "8":
                        IncreaseXByValue();
                        break;
                    case "9":
                        ShowAllPoints();
                        break;
                    case "10":
                        Console.WriteLine("Выход...");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        // Метод для создания новой точки
        public static void CreatePoint()
        {
            Console.WriteLine("\nСоздание точки:");

            string name = ReadString("Введите имя точки: ");
            double x = ReadDouble("Введите координату X: ");
            double y = ReadDouble("Введите координату Y: ");

            // Создание и добавление точки в список
            Point point = new Point(name, x, y);
            points.Add(point);

            Console.WriteLine($"\nТочка создана:\n{point}");
        }

        // Метод для нахождения расстояния между двумя точками
        public static void GetDistancePoints()
        {
            if (points.Count < 2)
            {
                Console.WriteLine("Для расчета расстояния требуется минимум 2 точки.");
                return;
            }
            Console.WriteLine("\nВыберите точку А:");
            Point A = SelectPoint();
            Console.WriteLine("\nВыберите точку В:");
            Point B = SelectPoint();
            double distance = Point.GetDistance(A, B);
            Console.WriteLine($"Расстояние между точками: {distance}");
        }

        // Увеличение координаты X выбранной точки на 1
        public static void IncreaseX()
        {
            if (points.Count == 0)
            {
                Console.WriteLine("Нет доступных точек.");
                return;
            }
            Console.WriteLine("\nВыберите точку для увеличения X на 1:");
            int index = SelectPointIndex();
            Point point = points[index];
            points[index] = ++point;
            Console.WriteLine($"X увеличен на 1: {points[index]}");
        }

        // Уменьшение координаты X выбранной точки на 1
        public static void DecreaseX()
        {
            if (points.Count == 0)
            {
                Console.WriteLine("Нет доступных точек.");
                return;
            }
            Console.WriteLine("\nВыберите точку для уменьшения X на 1:");
            int index = SelectPointIndex();
            Point point = points[index];
            points[index] = --point;
            Console.WriteLine($"X уменьшен на 1: {points[index]}");
        }

        // Выбор индекса точки из списка
        public static int SelectPointIndex()
        {
            ShowAllPoints();
            int index;
            while (true)
            {
                index = (int)ReadDouble("Введите номер точки: ") - 1;
                if (index >= 0 && index < points.Count)
                {
                    return index;
                }
                else
                {
                    Console.WriteLine("Неверный выбор точки. Пожалуйста, попробуйте еще раз.");
                }
            }
        }

        // Получение целой части координаты X
        public static void GetIntegerPartOfX()
        {
            if (points.Count == 0)
            {
                Console.WriteLine("Нет доступных точек.");
                return;
            }
            Console.WriteLine("\nВыберите точку для получения целой части X:");
            Point point = SelectPoint();
            int intX = (int)point;
            Console.WriteLine($"Целая часть X: {intX}");
        }

        // Получение координаты Y
        public static void GetYCoordinate()
        {
            if (points.Count == 0)
            {
                Console.WriteLine("Нет доступных точек.");
                return;
            }
            Console.WriteLine("\nВыберите точку для получения координаты Y:");
            Point point = SelectPoint();
            double y = point;
            Console.WriteLine($"Координата Y: {y}");
        }

        // Метод для нахождения расстояния между двумя точками через оператор +
        public static void GetDistanceUsingPlusOperator()
        {
            if (points.Count < 2)
            {
                Console.WriteLine("Для расчета расстояния требуется минимум 2 точки.");
                return;
            }
            Console.WriteLine("\nВыберите точку А:");
            Point A = SelectPoint();
            Console.WriteLine("\nВыберите точку В:");
            Point B = SelectPoint();
            double distance = A + B;
            Console.WriteLine($"Расстояние между точками через +: {distance}");
        }

        // Увеличение координаты X выбранной точки на указанное значение
        public static void IncreaseXByValue()
        {
            if (points.Count == 0)
            {
                Console.WriteLine("Нет доступных точек.");
                return;
            }

            Console.WriteLine("Выберите метод увеличения:");
            Console.WriteLine("1. Ввести число");
            Console.WriteLine("2. Выбрать точку");

            string choice = Console.ReadLine();
            int index = -1;  // Предварительная инициализация
            Point point = null; // Предварительная инициализация

            switch (choice)
            {
                case "1":
                    int value = ReadInt("Введите значение для увеличения: ");
                    Console.WriteLine("\nВыберите точку для увеличения X:");
                    index = SelectPointIndex();
                    point = points[index];
                    point = point + value;
                    break;

                case "2":
                    Console.WriteLine("\nВыберите точку для увеличения X:");
                    index = SelectPointIndex();
                    point = points[index];
                    value = ReadInt("Введите значение для увеличения: ");
                    point = value + point;
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    return;
            }

            // Заменяем исходную точку в списке обновленной версией
            points[index] = point;
            Console.WriteLine($"Координата X увеличена: {point}");
        }

        // Выбор конкретной точки из списка
        public static Point SelectPoint()
        {
            ShowAllPoints();
            int index;
            while (true)
            {
                index = (int)ReadDouble("Введите номер точки: ") - 1;
                if (index >= 0 && index < points.Count)
                {
                    return points[index];
                }
                else
                {
                    Console.WriteLine("Неверный выбор точки. Пожалуйста, попробуйте еще раз.");
                }
            }
        }

        // Показ всех точек
        public static void ShowAllPoints()
        {
            if (points.Count == 0)
            {
                Console.WriteLine("Точек нет");
                return;
            }

            Console.WriteLine("\nСписок всех точек:");
            for (int i = 0; i < points.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {points[i]}");
            }
        }

        // Безопасное считывание double с проверкой
        private static double ReadDouble(string message)
        {
            double result;
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out result))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка: введите корректное число.");
                }
            }
            return result;
        }

        // Безопасное считывание int с проверкой
        private static int ReadInt(string message)
        {
            int result;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка: введите корректное число.");
                }
            }
            return result;
        }

        // Чтение строки
        private static string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}