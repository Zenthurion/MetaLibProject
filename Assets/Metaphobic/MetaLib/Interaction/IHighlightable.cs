using MetaLib.Core;

namespace MetaLib.Interaction
{
    public interface IHighlightable
    {
        event MEvent<IHighlightable> OnHighlight;
        event MEvent<IHighlightable> OnUnhighlight;

        void Highlight();
        void Unhighlight();
    }
}