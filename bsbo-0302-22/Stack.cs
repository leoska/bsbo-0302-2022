using System;
namespace bsbo_0302_22
{
	public class Stack
	{
		private Item? top = null;

		// Проверка на пустоту стэка
		public bool isEmpty()
		{
			Application.N_OP += 1;
            return top == null; // 1
		}

		// Добавление Item в вверх стэка
		public void Push(Item newItem)
		{
			if (!isEmpty()) // 3
			{
                newItem.next = top; // 2
			}

			top = newItem; // 1
            Application.N_OP += 6;
        }

		// Извлечение Item из стэка
		public Item Pop()
		{
			if (isEmpty()) // 2
			{
				throw new Exception("Stack is empty");
			}

			Item result = top; // 1
			top = top?.next; // 3


			result.next = null; // 2
            Application.N_OP += 8;
            return result;
        }

		// Получение доступа на чтение к элементу по индексу по правилам работы со Стэком
		public int Get(int index, Stack tmp)
		{
			if (isEmpty()) // 2
			{
                throw new Exception("Stack is empty");
            }
            Application.N_OP += 2;

            // 2
            for (int i = 0; i < index; i++)
			{
				tmp.Push(Pop()); // 1 + 1 + 1 = 3

				if (isEmpty()) // 2
				{
					while (!tmp.isEmpty())
						Push(tmp.Pop());

					throw new Exception("Out of range stack!");
				}

				// 2
				Application.N_OP += 7;
            }
            Application.N_OP += 2;

            int result = top.value; // 2
            Application.N_OP += 2;

			// 2 + 1 + 1 = 4
			while (!tmp.isEmpty())
			{
                Push(tmp.Pop()); // 1 + 2 + 1 = 4
				// 4
                Application.N_OP += 8;
            }
            Application.N_OP += 4;


            return result;
		}

        // Получение доступа на запись к элементу по индексу по правилам работы со Стэком
        public void Set(int index, int newValue, Stack tmp)
		{
            if (isEmpty()) // 2
            {
                throw new Exception("Stack is empty");
            }
            Application.N_OP += 2;

            for (int i = 0; i < index; i++)
            {
                tmp.Push(Pop());

                if (isEmpty())
                {
                    while (!tmp.isEmpty())
                        Push(tmp.Pop());

                    throw new Exception("Out of range stack!");
                }
                Application.N_OP += 7;
            }
            Application.N_OP += 2;

            top.value = newValue;
            Application.N_OP += 2;

            while (!tmp.isEmpty())
			{
                Push(tmp.Pop());
                Application.N_OP += 8;
            }
            Application.N_OP += 4;
            
        }

		// Вывод всего содержимого стэка
		public void Print()
		{
			Item? current = top;

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
			get
			{
                Application.N_OP += 4;
                return Get(index, Application.tmp);
			}
			set
			{
                Application.N_OP += 5;
                Set(index, value, Application.tmp);
			}
		}
	}
}

