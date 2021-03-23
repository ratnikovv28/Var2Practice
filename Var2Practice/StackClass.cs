using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    //Класс разрабатывал Степанов Дмитрий
    public class StackClass<T>
    {
        private T[] elements; // массив, содержащий стек
        private int count;    // индекс вершины стека
        const int n = 10;

        //Построить класс StackClass для реализации стека изначального размера 10
        public StackClass()
        {
            elements = new T[n];
        }

        //Возвратить значение true, если стек пуст.
        public bool IsEmpty()
        {
            return count == 0;
        }

        // Возвратить общую ёмкость стека.
        public int Capacity()
        {
            return elements.Length;
        }

        // Поместить элементы в стек.
        public void Push(T element)
        {
            // увеличиваем стек
            if (count == elements.Length)
                Resize(elements.Length + 10);

            elements[count++] = element;
        }

        // Извлечь элемент из стека.
        public T Pop()
        {
            // Если стек пуст, выбраосить исключение.
            if (IsEmpty())
                throw new InvalidOperationException("Стек пуст");
            T element = elements[--count];
            elements[count] = default(T); // сбрасываем ссылку на последний элемент

            if (count > 0 && count < elements.Length - 10)
                Resize(elements.Length - 10);

            return element;
        }
        
        // Получить самый верхний элемент стека
        public T Peek()
        {
            return elements[count - 1];
        }

        // Динамическое изменение размера стека
        private void Resize(int max)
        {
            T[] tempItems = new T[max];
            for (int i = 0; i < count; i++)
                tempItems[i] = elements[i];
            elements = tempItems;
        }
    }
}
