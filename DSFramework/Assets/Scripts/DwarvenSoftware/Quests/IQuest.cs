using System.Collections.Generic;

namespace DwarvenSoftware.Quests
{
    public interface IQuest
    {
        List<IQuest> Prerequisites { get; }
    }
}