namespace MetaLib.Core
{
    public delegate void ValueEvent<T>(MValue<T> value);
    public class MValue<T>
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