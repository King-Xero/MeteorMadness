namespace SSSRegen.Source.Core.Interfaces
{
    public interface IInputController
    {
        bool IsLeftButtonPressed();
        bool IsRightButtonPressed();
        bool IsUpButtonPressed();
        bool IsDownButtonPressed();
        bool IsStartButtonPressed();
    }
}