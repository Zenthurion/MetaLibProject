using System.Collections.Generic;
using DwarvenSoftware.Framework.Core;

namespace DwarvenSoftware.Framework.Interaction
{
    public class DSSelections : DSSingleton<DSSelections>
    {
        private List<ISelectable> _previousSelection;
        private List<ISelectable> _selection;

        public IReadOnlyList<ISelectable> ReadonlySelection => _selection.AsReadOnly();

        public void Add(ISelectable selectable)
        {
            _selection.Add(selectable);
            selectable.Select();
        }

        public void Remove(ISelectable selectable)
        {
            _selection.Remove(selectable);
            selectable.Deselect();
        }

        public void Clear()
        {
            var swap = _previousSelection;
            _previousSelection = _selection;
            _selection = swap;
            _selection.Clear();
            
            _previousSelection.ForEach((s) => s.Deselect());
        }

        public void ReselectPrevious()
        {
            var swap = _previousSelection;
            _previousSelection = _selection;
            _selection = swap;

            _selection.ForEach((s) => s.Select());
        }
    }
}