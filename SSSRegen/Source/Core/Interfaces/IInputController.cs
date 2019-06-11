namespace SSSRegen.Source.Core.Interfaces
{
    public interface IInputController
    {
        void Initialize();
        void Update();

        bool IsLeftButtonPressed();
        bool IsRightButtonPressed();
        bool IsUpButtonPressed();
        bool IsDownButtonPressed();
        bool IsStartButtonPressed();
    }
}