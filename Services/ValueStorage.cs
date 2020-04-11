namespace HelloWorld.Services{
    public class ValueStorage : IValueStorage
    {
        private int _value = 0;
        public int GetValue()
        {
            return _value;
        }

        public void SetValue(int newValue)
        {
            _value = newValue;
        }
    }
}