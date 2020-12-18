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
        public int GetValue(int index)
        {
            return (int)items[index].Value;
        }
        public Monster GetKey(int index)
        {
            return (Monster)items[index].Key;
        }
        public void DictByStrongest(Monster[] monsterfield, int counter)
        {
            ItemsInUse = 0;
            for (int i = 0; i < counter; i++)
            {
                if(monsterfield[i]!=null)
                {
                    Add(monsterfield[i], i);
                }
            }
            for (int i = 0; i < ItemsInUse - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < ItemsInUse; j++)
                {
                    items.GetValue(1);
                    if (GetKey(j).attack > GetKey(max).attack)
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
            for (int i = 0; i < counter; i++)
            {
                if (monsterfield[i] != null)
                {
                    Add(monsterfield[i], i);
                }
            }
            for (int i = 0; i < ItemsInUse - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < ItemsInUse; j++)
                {
                    if (GetKey(j).attack < GetKey(max).attack)
                    {
                        max = j;
                    }
                }
                var temp = items[max];
                items[max] = items[i];
                items[i] = temp;
            }
        }
        private Boolean TryGetIndexOfKey(Object key, out Int32 index)
        {
            for (index = 0; index < ItemsInUse; index++)
            {
                // If the key is found, return true (the index is also returned).
                if (items[index].Key.Equals(key)) return true;
            }

            // Key not found, return false (index should be ignored by the caller).
            return false;
        }
        public int this[Monster key]
        {
            get
            {
                // If this key is in the dictionary, return its value.
                Int32 index;
                if (TryGetIndexOfKey(key, out index))
                {
                    // The key was found; return its value.
                    return (int)items[index].Value;
                }
                else
                {
                    // The key was not found; return null.
                    return -1;
                }
            }

            set
            {
                // If this key is in the dictionary, change its value.
                Int32 index;
                if (TryGetIndexOfKey(key, out index))
                {
                    // The key was found; change its value.
                    items[index].Value = value;
                }
                else
                {
                    // This key is not in the dictionary; add this key/value pair.
                    Add(key, value);
                }
            }
        }

        public ICollection<Monster> Keys
        {
            get
            {
                // Return an array where each item is a key.
                Monster[] keys = new Monster[ItemsInUse];
                for (Int32 n = 0; n < ItemsInUse; n++)
                    keys[n] = (Monster)items[n].Key;
                return keys;
            }
        }
        public ICollection<int> Values
        {
            get
            {
                // Return an array where each item is a value.
                int[] values = new int[ItemsInUse];
                for (Int32 n = 0; n < ItemsInUse; n++)
                    values[n] = (int)items[n].Value;
                return values;
            }
        }

        public int Count { get { return ItemsInUse; } }

        public bool IsReadOnly { get { return false; } }

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
            Int32 index;
            return TryGetIndexOfKey(key, out index);
        }
        public bool IsFixedSize { get { return false; } }
        public void Remove(object key)
        {
            if (key == null) throw new ArgumentNullException("key");
            // Try to find the key in the DictionaryEntry array
            Int32 index;
            if (TryGetIndexOfKey(key, out index))
            {
                // If the key is found, slide all the items up.
                Array.Copy(items, index + 1, items, index, ItemsInUse - index - 1);
                ItemsInUse--;
            }
            else
            {
                // If the key is not in the dictionary, just return.
            }
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

        public DictionaryEntry Pair(int index)
        {
            return items[index];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary)this).GetEnumerator();
        }
    }
}
