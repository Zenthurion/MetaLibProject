using System.Collections.Generic;
using MetaLib.Core;
using UnityEngine;

namespace MetaLib.Interaction
{
    public class MetaSelections : MetaSingleton<MetaSelections>
    {
        private List<ISelectable> _previousSelection;
        private List<ISelectable> _selection;

        public IReadOnlyList<ISelectable> ReadonlySelection => _selection.AsReadOnly();

        protected override void Awake()
        {
            base.Awake();
            _selection = new List<ISelectable>();
            _previousSelection = new List<ISelectable>();
        }


        public void Add(ISelectable selectable)
        {
            if(_selection.Contains(selectable) || !selectable.IsSelectable) return;
            _selection.Add(selectable);
            selectable.OnSelect();
            
            Debug.Log("Selected: " + (selectable as MonoBehaviour)?.name);
        }

        public void Remove(ISelectable selectable)
        {
            if(!_selection.Contains(selectable)) return;
            _selection.Remove(selectable);
            selectable.OnDeselect();
            
            Debug.Log("Deselected: " + (selectable as MonoBehaviour)?.name);
        }

        public void Clear()
        {
            if(_selection.Count == 0) return;
            
            var swap = _previousSelection;
            _previousSelection = _selection;
            _selection = swap;
            _selection.Clear();
            
            _previousSelection.ForEach((s) => s.OnDeselect());
            
            Debug.Log("Clearing Selection");
        }

        public void ReselectPrevious()
        {
            var swap = _previousSelection;
            _previousSelection = _selection;
            _selection = swap;

            _selection.ForEach((s) => s.OnSelect());
        }

        public bool IsSelected(ISelectable selectable)
        {
            return _selection.Contains(selectable);
        }
    }
}