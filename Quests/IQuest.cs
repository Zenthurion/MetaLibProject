using System.Collections.Generic;

namespace DwarvenSoftware.Framework.Quests
{
    public interface IQuest
    {
        List<IQuest> Prerequisites { get; }
    }
}