namespace DwarvenSoftware.Framework.FSM
{
    public interface ITransition
    {
        bool Evaluate();
        void Execute();
    }
}