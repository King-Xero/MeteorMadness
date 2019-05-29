namespace SSSRegen.Source.Core.Interfaces
{
    public interface IInputManager
    {
        bool IsLeftButtonPressed();
        bool IsRightButtonPressed();
        bool IsUpButtonPressed();
        bool IsDownButtonPressed();
        bool IsStartButtonPressed();
    }
}