namespace SSSRegen.Source.Core.Interfaces
{
    public interface IGameStateMachine
    {
        GameState ActiveState { get; }
        void AddState(GameState newState, bool isReplacing = true);
        void RemoveState();
        void ProcessStateChanges();
    }
}