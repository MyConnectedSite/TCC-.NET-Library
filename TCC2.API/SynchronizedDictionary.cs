using System;
using System.Collections;
using System.Collections.Generic;

namespace TCC2.API
{
    internal class SynchronizedDictionary<T, U> : IDictionary<T, U>
    {
        object m_SyncRoot = new object();
        protected Dictionary<T, U> m_Dictionary;

        public SynchronizedDictionary()
        {
            m_Dictionary = new Dictionary<T, U>();
        }

        public SynchronizedDictionary(int capacity)
        {
            m_Dictionary = new Dictionary<T, U>(capacity);
        }

        public SynchronizedDictionary(IEqualityComparer<T> comparer)
        {
            m_Dictionary = new Dictionary<T, U>(comparer);
        }

        public SynchronizedDictionary(IDictionary<T, U> dictionary)
        {
            m_Dictionary = new Dictionary<T, U>(dictionary);
        }

        public SynchronizedDictionary(int capacity, IEqualityComparer<T> comparer)
        {
            m_Dictionary = new Dictionary<T, U>(capacity, comparer);
        }

        public SynchronizedDictionary(IDictionary<T, U> dictionary, IEqualityComparer<T> comparer)
        {
            m_Dictionary = new Dictionary<T, U>(dictionary, comparer);
        }

        public void Add(T key, U value)
        {
            lock (m_SyncRoot)
            {
                m_Dictionary.Add(key, value);
            }
        }

        public bool ContainsKey(T key)
        {
            lock (m_SyncRoot)
            {
                return m_Dictionary.ContainsKey(key);
            }
        }

        public ICollection<T> Keys
        {
            get
            {
                lock (m_SyncRoot)
                {
                    return m_Dictionary.Keys;
                }
            }
        }

        public bool Remove(T key)
        {
            lock (m_SyncRoot)
            {
                return m_Dictionary.Remove(key);
            }
        }

        public bool TryGetValue(T key, out U value)
        {
            lock (m_SyncRoot)
            {
                return m_Dictionary.TryGetValue(key, out value);
            }
        }

        public ICollection<U> Values
        {
            get
            {
                lock (m_SyncRoot)
                {
                    return m_Dictionary.Values;
                }
            }
        }

        public U this[T key]
        {
            get
            {
                lock (m_SyncRoot)
                {
                    return m_Dictionary[key];
                }
            }
            set
            {
                lock (m_SyncRoot)
                {
                    m_Dictionary[key] = value;
                }
            }
        }

        public void Add(KeyValuePair<T, U> item)
        {
            lock (m_SyncRoot)
            {
                (m_Dictionary as ICollection<KeyValuePair<T, U>>).Add(item);
            }
        }

        public void Clear()
        {
            lock (m_SyncRoot)
            {
                m_Dictionary.Clear();
            }
        }

        public bool Contains(KeyValuePair<T, U> item)
        {
            lock (m_SyncRoot)
            {
                return (m_Dictionary as ICollection<KeyValuePair<T, U>>).Contains(item);
            }
        }

        public void CopyTo(KeyValuePair<T, U>[] array, int arrayIndex)
        {
            lock (m_SyncRoot)
            {
                (m_Dictionary as ICollection<KeyValuePair<T, U>>).CopyTo(array, arrayIndex);
            }
        }

        public int Count
        {
            get
            {
                lock (m_SyncRoot)
                {
                    return m_Dictionary.Count;
                }
            }
        }

        public bool IsReadOnly
        {
            get { return (m_Dictionary as ICollection<KeyValuePair<T, U>>).IsReadOnly; }
        }

        public bool Remove(KeyValuePair<T, U> item)
        {
            lock (m_SyncRoot)
            {
                return (m_Dictionary as ICollection<KeyValuePair<T, U>>).Remove(item);
            }
        }

        public IEnumerator<KeyValuePair<T, U>> GetEnumerator()
        {
            return m_Dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (m_Dictionary as IEnumerable).GetEnumerator();
        }

        public object SyncRoot
        {
            get { return m_SyncRoot; }
        }
    }
}
