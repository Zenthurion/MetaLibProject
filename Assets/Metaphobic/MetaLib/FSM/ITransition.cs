namespace MetaLib.FSM
{
    public interface ITransition
    {
        bool Evaluate();
        void Execute();
    }
}