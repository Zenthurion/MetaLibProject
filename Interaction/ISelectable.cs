using DwarvenSoftware.Framework.Core;

namespace DwarvenSoftware.Framework.Interaction
{
    public interface ISelectable
    {
        event DSEvent<ISelectable> OnSelected;
        event DSEvent<ISelectable> OnDeselected;
        
        bool IsSelectable { get; }
        bool IsSelected { get; }
        
        void Select();
        void Deselect();
    }
}