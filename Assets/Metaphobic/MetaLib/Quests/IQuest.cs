using System.Collections.Generic;

namespace MetaLib.Quests
{
    public interface IQuest
    {
        List<IQuest> Prerequisites { get; }
    }
}