namespace SSSRegen.Source.Core.Interfaces
{
    public interface IGameStateMachine
    {
        IGameState ActiveState { get; }
        void AddState(IGameState newState, bool isReplacing = true);
        void RemoveState();
        void ProcessStateChanges();
    }
}