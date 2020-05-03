using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest   //шаблон фасад
{
    /// <summary>класс - хранилище объектов</summary>
    internal abstract class Storage<TItem> : IEnumerable<TItem> //мы заранее не знаем что будем тут хранить, но позже будем работать с классом TItom
    {
        private readonly List<TItem> _Items = new List<TItem>();

        public int Count => _Items.Count;


        //private Func<int, double, string, bool>
        private Action<TItem> _AddObservers;

        public virtual TItem this[int index]
        {
            get
            {
                return _Items[index];
            }
            set
            {
                if (_Items.Contains(value)) return;
                _Items[index] = value;
            }
        }

        public void SubscribeToAdd(Action<TItem> Observer)
        {
            _AddObservers = Observer;
        }

        public virtual void Add(TItem item)
        {
            if (_Items.Contains(item)) return;
            _Items.Add(item);

            if (_AddObservers != null)
                _AddObservers(item);
        }

        public virtual bool Remove(TItem item)
        {
            return _Items.Remove(item);
        }

        public virtual bool IsContains(TItem item)
        {
            return _Items.Contains(item);
        }

        public virtual void Clear()
        {
            _Items.Clear();
        }

        public abstract void SafeToFile(string FileName);

        public virtual void LoadFromFile(string FileName)
        {
            Clear();
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return _Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
