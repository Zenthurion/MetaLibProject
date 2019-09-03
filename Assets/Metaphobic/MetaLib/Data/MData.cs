namespace MetaLib.Data
{
    public delegate ISaveDataBundle SaveDataListener();

    public class MData
    {
        private event SaveDataListener OnSave;

        public void Save()
        {
            var res = OnSave?.Invoke();
        }

        public void AddSaveListener(SaveDataListener saveDataListener)
        {
            OnSave += saveDataListener;
        }

        public void RemoveSaveListener(SaveDataListener saveDataListener)
        {
            OnSave -= saveDataListener;
        }
    }
}