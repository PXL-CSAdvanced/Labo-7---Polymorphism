using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_7___Polymorphism.Data
{
    class Store<T>
    {
        //public T Data { get; set; }
        private List<T> _data = new List<T>();

        public void AddItem(T item)
        {
            _data.Add(item);
        }

        public IEnumerable<T> GetAllItems()
        {
            return _data;
        }

        public bool RemoveItem(T item)
        {
            return _data.Remove(item);
        }

        public void ClearAllItems()
        {
            _data.Clear();
        }

        public int Count
        {
            get { return _data.Count; }
        }

        public void SortItems(Comparison<T> comparison)
        {
            _data.Sort(comparison);
        }

        public T FindItem(Predicate<T> match)
        {
            return _data.Find(match);
        }

        public bool UpdateItem(T oldItem, T newItem)
        {
            int index = _data.IndexOf(oldItem);
            if (index != -1)
            {
                _data[index] = newItem;
                return true;
            }
            return false;
        }

        public IEnumerable<T> FilterItems(Predicate<T> match)
        {
            return _data.FindAll(match);
        }
    }
}
