using System.Collections;
using System.Collections.Generic;

namespace DwarvenSoftware.Framework.Data
{
    public class SaveDataBundle : ISaveDataBundle
    {
        private readonly List<object> _data;

        public SaveDataBundle()
        {
            _data = new List<object>();
        }

        public IEnumerator GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public void AddData(object obj)
        {
            _data.Add(obj);
        }

        public void RemoveData(object obj)
        {
            _data.Remove(obj);
        }
    }
}