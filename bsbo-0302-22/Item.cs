using System;
namespace bsbo_0302_22
{
	public class Item
	{
		public int value = 0;
		public Item? next = null;

        public Item(int value = 0, Item? next = null)
        {
            this.value = value;
            this.next = next;
        }
    }
}

