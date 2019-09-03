namespace MetaLib.Tasks
{
    public interface ITaskStack
    {
        void PushImmediate(ITask task);
        void PushQueue(ITask task);
        ITask Current { get; }
        ITask Next { get; }

        void Evaluate();
        void Cancel();
        
        int Capacity { get; }
        int Count { get; }
    }
}