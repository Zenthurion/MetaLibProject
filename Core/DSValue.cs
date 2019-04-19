namespace DwarvenSoftware.Framework.Core
{
    public delegate void ValueEvent<T>(DSValue<T> value);
    public class DSValue<T>
    {
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnChange?.Invoke(this);
            }
        }

        public event ValueEvent<T> OnChange;


    }
}