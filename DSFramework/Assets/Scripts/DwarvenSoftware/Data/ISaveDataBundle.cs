using System.Collections;

namespace DwarvenSoftware.Data
{
    public interface ISaveDataBundle : IEnumerable
    {
        void AddData(object obj);
        void RemoveData(object obj);
    }
}