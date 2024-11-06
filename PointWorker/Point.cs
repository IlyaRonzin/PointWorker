using System;

namespace PointWorker
{
    public class Point
    {
        public double X { get; private set; }  // Координата X
        public double Y { get; private set; }  // Координата Y
        public string Name { get; private set; }  // Имя точки

        public Point(string name, double x, double y)
        {
            Name = name;
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{Name}: X = {X}, Y = {Y}";  // Переопределение для вывода информации о точке
        }

        // Увеличение координаты X на 1 (унарная операция ++)
        public static Point operator ++(Point point)
        {
            return new Point(point.Name, point.X + 1, point.Y);
        }

        // Уменьшение координаты X на 1 (унарная операция --)
        public static Point operator --(Point point)
        {
            return new Point(point.Name, point.X - 1, point.Y);
        }

        // Явное приведение к int (возвращает целую часть координаты X)
        public static explicit operator int(Point point)
        {
            return (int)point.X;
        }

        // Неявное приведение к double (возвращает координату Y)
        public static implicit operator double(Point point)
        {
            return point.Y;
        }

        // Расстояние между двумя точками (бинарная операция +)
        public static double operator +(Point A, Point B)
        {
            return Point.GetDistance(A, B);
        }

        // Увеличение координаты X на целое число (правосторонняя версия)
        public static Point operator +(Point point, int value)
        {
            return new Point(point.Name, point.X + value, point.Y);
        }

        // Увеличение координаты X на целое число (левосторонняя версия)
        public static Point operator +(int value, Point point)
        {
            return new Point(point.Name, point.X + value, point.Y);
        }

        // Метод для расчета расстояния между двумя точками
        public static double GetDistance(Point A, Point B)
        {
            double dx = B.X - A.X;
            double dy = B.Y - A.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}