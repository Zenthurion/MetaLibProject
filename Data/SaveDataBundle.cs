using System.Collections;
using System.Collections.Generic;

namespace DwarvenSoftware.Framework.Data
{
    public class SaveDataBundle : ISaveDataBundle
    {
        private List<object> _data;

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