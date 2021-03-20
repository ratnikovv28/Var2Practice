using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class StackClass<T>
    {
        public T[] items { get; set; }

        const int n = 10;

        private Stack<int> stack = new Stack<int>();
        public bool IsEmpty()
        {
            if (Count == 0) return false;
            else return true;
        }
        public int Count { get; private set; }

        public void Push(T item)
        {
            // увеличиваем стек
            if (Count == items.Length)
                Resize(items.Length + 10);

            items[Count++] = item;
        }
        public T Pop()
        {
            // если стек пуст, выбрасываем исключение
            if (IsEmpty())
                throw new InvalidOperationException("Стек пуст");
            T item = items[--Count];
            items[Count] = default(T); // сбрасываем ссылку

            if (Count > 0 && Count < items.Length - 10)
                Resize(items.Length - 10);

            return item;
        }
        public T Peek()
        {
            return items[Count - 1];
        }

        private void Resize(int max)
        {
            T[] tempItems = new T[max];
            for (int i = 0; i < Count; i++)
                tempItems[i] = items[i];
            items = tempItems;
        }
    }
}
