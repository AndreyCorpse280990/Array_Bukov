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
            // Создание объекта класса Array с длиной 5 и вывод его размера
            Array array1 = new Array(5);
            Console.WriteLine("Размер массива: " + array1.Size);

            // Вывод массива array1
            Console.WriteLine("Array1:");
            array1.Print();

            // Установка значения 10 для всех элементов массива и вывод массива
            array1.SetValue(10);
            Console.WriteLine("Array1 после установки значения:");
            array1.Print();

            // Создание объекта класса ArrayList с емкостью 5 и вывод емкости
            ArrayList arrayList1 = new ArrayList(5);
            Console.WriteLine("ArrayList ёмкость: " + arrayList1.Capacity);

            // до добавления элементов
            Console.WriteLine("ArrayList1 до добавления элементов:");
            arrayList1.Print();

            // Добавление элементов в массив arrayList1 и вывод его содержимого
            arrayList1.AddItem(5);
            arrayList1.AddItem(6);
            arrayList1.AddItem(9);
            Console.WriteLine("ArrayList1 после добавления элементов:");
            arrayList1.Print();

            Console.WriteLine("ArrayList1 емкость до сжатия: " + arrayList1.Capacity);

            // Сжатие массива arrayList1 и вывод его содержимого и емкости
            arrayList1.Shrink();
            Console.WriteLine("ArrayList1 после сжатия:");
            arrayList1.Print();
            Console.WriteLine("ArrayList1 емкость после сжатия: " + arrayList1.Capacity);
        }
    }
    public class Array
    {
        private const int DefaultLength = 10;
        protected int[] data;

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

        // Свойство для получения размера массиваВ
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
            k = 1.3; // Пример значения для коэффициента расширения
            capacity = 0; // Начальная емкость равна нулю
        }

        // Конструктор, создающий массив с изначальной емкостью
        public ArrayList(int capacity) : base(capacity)
        {
            k = 1.3; // Пример значения для коэффициента расширения
            this.capacity = capacity;
        }

        //конструктор, создающий массив заданной длины и емкости, заполненный значениями по умолчанию, если capacity < size то делать capacity = size;
        public ArrayList(int size, int capacity) : base(size > capacity ? size : capacity)
        {
            k = 1.3; 
            this.capacity = size > capacity ? size : capacity;
        }

        // конструктор, создающий массив заданной длины и емкости, заполненные переданными значением, если capacity < size то делать capacity = size
        public ArrayList(int size, int capacity, int value) : base(size > capacity ? size : capacity)
        {
            k = 1.3; // Пример значения для коэффициента расширения
            this.capacity = size > capacity ? size : capacity;

            // Заполнение массива переданным значением
            for (int i = 0; i < size; i++)
            {
                SetItem(i, value);
            }
        }

        public void AddItem(int value)
        {
            if (Size >= capacity)
            {
                int newCapacity = (int)(capacity * k); // Вычисление новой ёмкости
                Resize(newCapacity); // Изменение размера массива на новую емкость
                capacity = newCapacity; // Обновление значения текущей ёмкости
            }

            Resize(Size + 1); // Увеличивю размер массива
            SetItem(Size - 1, value); // устанавливаю значение в конец массива
        }


        // метод сжатия массива с уменьшением capacity до размера size
        public void Shrink()
        {
            int newSize = Size;
            Resize(newSize);
            capacity = newSize;
        }

        private void Resize(int newSize)
        {
            int[] newData = new int[newSize]; // новый массив с новым размером

            // копирование элементов из старого массива в новый
            for (int i = 0; i < Size && i < newSize; i++)
            {
                newData[i] = GetItem(i);
            }

            data = newData; // Обновляю ссылку на массив
        }
    }
}
     


