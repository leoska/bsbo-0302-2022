using System;
namespace bsbo_0302_22
{
	public class Stack
	{
		private Item top = null;

		// Проверка на пустоту стэка
		public bool isEmpty()
		{
			return top == null;
		}

		// Добавление Item в вверх стэка
		public void Push(Item newItem)
		{
			if (!isEmpty())
			{
                newItem.next = top;
			}

			top = newItem;
        }

		// Извлечение Item из стэка
		public Item Pop()
		{
			if (isEmpty())
			{
				throw new Exception("Stack is empty");
			}

			Item result = top;
			top = top.next;


			result.next = null;
            return result;
        }

		// Получение доступа на чтение к элементу по индексу по правилам работы со Стэком
		public int Get(int index, Stack tmp)
		{
			if (isEmpty())
			{
                throw new Exception("Stack is empty");
            }

			for (int i = 0; i < index; i++)
			{
				tmp.Push(Pop());

				if (isEmpty())
				{
					while (!tmp.isEmpty())
						Push(tmp.Pop());

					throw new Exception("Out of range stack!");
				}
			}

			int result = top.value;

            while (!tmp.isEmpty())
                Push(tmp.Pop());

            return result;
		}

        // Получение доступа на запись к элементу по индексу по правилам работы со Стэком
        public void Set(int index, int newValue, Stack tmp)
		{
            if (isEmpty())
            {
                throw new Exception("Stack is empty");
            }

            for (int i = 0; i < index; i++)
            {
                tmp.Push(Pop());

                if (isEmpty())
                {
                    while (!tmp.isEmpty())
                        Push(tmp.Pop());

                    throw new Exception("Out of range stack!");
                }
            }

			top.value = newValue;

            while (!tmp.isEmpty())
                Push(tmp.Pop());
        }

		// Вывод всего содержимого стэка
		public void Print()
		{
			Item current = top;

			while(current != null)
			{
				Console.Write($"{current.value.ToString()} ");
				current = current.next;
			}

			Console.WriteLine();
		}

		// Перегрузка оператора индексации []
		public int this[int index]
		{
			get => Get(index, Application.tmp);
			set => Set(index, value, Application.tmp);
		}
	}
}

