using System.Collections;

namespace DwarvenSoftware.Framework.Data
{
    public interface ISaveDataBundle : IEnumerable
    {
        void AddData(object obj);
        void RemoveData(object obj);
    }
}