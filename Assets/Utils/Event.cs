namespace Utils
{
    public class TypedEvent<T>
    {
        public delegate void EventType(T sender);

        public event EventType EventInstance;

        public void TriggerEvent(T sender)
        {
            EventInstance?.Invoke(sender);
        }
    }
}