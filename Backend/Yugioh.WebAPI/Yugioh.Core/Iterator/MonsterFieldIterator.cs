using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Classes;

namespace Yugioh.Core.Iterator
{
    public class MonsterFieldIterator : IDictionary<Monster, int>
    {
        private Int32 ItemsInUse = 0;
        private DictionaryEntry[] items;
        public MonsterFieldIterator()
        {
            items = new DictionaryEntry[6];
        }
        public void DictByStrongest(Monster[] monsterfield, int counter)
        {
            ItemsInUse = 0;
            Dictionary<Monster, int> dict= new Dictionary<Monster, int>();
            for (int i = 0; i < counter; i++)
            {
                if(monsterfield[i]!=null)
                {
                    dict.Add(monsterfield[i], i);
                }
            }
            for (int i = 0; i < ItemsInUse - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < ItemsInUse; j++)
                {
                    if (monsterfield[j].attack > monsterfield[max].attack)
                    {
                        max = j;
                    }
                }
                var temp = items[max];
                items[max] = items[i];
                items[i] = temp;
            }
        }
        public void DictBySWeakest(Monster[] monsterfield, int counter)
        {
            ItemsInUse = 0;
            Dictionary<Monster, int> dict = new Dictionary<Monster, int>();
            for (int i = 0; i < counter; i++)
            {
                if (monsterfield[i] != null)
                {
                    dict.Add(monsterfield[i], i);
                }
            }
            for (int i = 0; i < ItemsInUse - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < ItemsInUse; j++)
                {
                    if (monsterfield[j].attack < monsterfield[max].attack)
                    {
                        max = j;
                    }
                }
                var temp = items[max];
                items[max] = items[i];
                items[i] = temp;
            }
        }
        public int this[Monster key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<Monster> Keys => throw new NotImplementedException();

        public ICollection<int> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(Monster key, int value)
        {
            if (ItemsInUse == items.Length)
                throw new InvalidOperationException("The dictionary cannot hold any more items.");
            items[ItemsInUse++] = new DictionaryEntry(key, value);
        }

        public void Add(KeyValuePair<Monster, int> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<Monster, int> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(Monster key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<Monster, int>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<Monster, int>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Monster key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<Monster, int> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(Monster key, out int value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
