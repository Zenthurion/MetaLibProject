using System.Collections;

namespace MetaLib.Data
{
    public interface ISaveDataBundle : IEnumerable
    {
        void AddData(object obj);
        void RemoveData(object obj); 
    }
}