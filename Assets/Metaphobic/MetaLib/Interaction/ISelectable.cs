using MetaLib.Core;

namespace MetaLib.Interaction
{
    public interface ISelectable
    {
        event MEvent<ISelectable> OnSelected;
        event MEvent<ISelectable> OnDeselected;
        
        bool IsSelectable { get; }
        bool IsSelected { get; }
        
        void OnSelect();
        void OnDeselect();
    }
}