using DwarvenSoftware.Framework.Core;

namespace DwarvenSoftware.Framework.Interaction
{
    public interface IHighlightable
    {
        event DSEvent<IHighlightable> OnHighlight;
        event DSEvent<IHighlightable> OnUnhighlight;

        void Highlight();
        void Unhighlight();
    }
}