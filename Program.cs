using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Bukov
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Array
    {
        private const int DefaultLength = 10;
        private int[] data;

        // Конструктор по умолчанию
        public Array()
        {
            data = new int[DefaultLength];
        }

        // Конструктор для создания массива заданной длины, заполненного значениями по умолчанию
        public Array(int n)
        {
            data = new int[n];
        }

        // Конструктор для создания массива заданной длины, элементы которого содержат переданное значение
        public Array(int n, int value)
        {
            data = new int[n];
            for (int i = 0; i < n; i++)
            {
                data[i] = value;
            }
        }

        // Свойство для получения размера массива
        public int Size
        {
            get { return data.Length; }
        }

        // вывод массива в консоль, элементы разделены пробелом, в конце перенос строки
        public void Print()
        {
            foreach (int i in data)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        // получение значения элемента массива по индексу
        // Получение значения элемента массива по индексу
        public int GetItem(int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            return data[index];
        }

        //  установка значения элемента массива по индексу
        public void SetItem(int index, int value)
        {
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            data[index] = value;
        }

        //установка переданного значения во все элементы массива
        public void SetValue(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = value;
            }
        }
    }

    public class ArrayList : Array
    {
        private double k;
        private int capacity;

        public int Capacity { get { return capacity; } }

        // Конструктор по умолчанию, создает массив дефолтной емкости нулевой длины
        public ArrayList() : base()
        {
            k = 1.5; // Пример значения для коэффициента расширения
            capacity = 0; // Начальная емкость равна нулю
        }

        // Конструктор, создающий массив с изначальной емкостью
        public ArrayList(int capacity) : base(capacity)
        {
            k = 1.5; // Пример значения для коэффициента расширения
            this.capacity = capacity;
        }

        //конструктор, создающий массив заданной длины и емкости, заполненный значениями по умолчанию, если capacity < size то делать capacity = size;
        public ArrayList(int size, int capacity) : base(size > capacity ? size : capacity)
        {
            k = 1.5; 
            this.capacity = size > capacity ? size : capacity;
        }

        // конструктор, создающий массив заданной длины и емкости, заполненные переданными значением, если capacity < size то делать capacity = size
        public ArrayList(int size, int capacity, int value) : base(size > capacity ? size : capacity)
        {
            k = 1.5; // Пример значения для коэффициента расширения
            this.capacity = size > capacity ? size : capacity;

            // Заполнение массива переданным значением
            for (int i = 0; i < size; i++)
            {
                SetItem(i, value);
            }
        }
    }
}

