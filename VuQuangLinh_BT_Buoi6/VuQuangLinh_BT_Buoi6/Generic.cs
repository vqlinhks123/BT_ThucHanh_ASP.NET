using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi6
{
    public class MyGeneric<T>
    {
        private List<T> list;
        public MyGeneric(int size)
        {
            list = new List<T>(size+1);
        }
        public void AddItem(T value)
        { 
            list.Add(value); 
        }
        public T GetItem(int index)
        {
            return list[index];
        }
        public void SetItem(int index, T value)
        {
            list[index] = value;
        }
        public void RemoveItem(int index)
        {
            list.RemoveAt(index);
        }
        public int Count()
        {
            return (list.Count);
        }
    }
}
