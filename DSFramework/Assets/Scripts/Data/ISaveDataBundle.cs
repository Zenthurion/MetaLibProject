using System.Collections;

namespace Data
{
    public interface ISaveDataBundle : IEnumerable
    {
        void AddData(object obj);
        void RemoveData(object obj);
    }
}