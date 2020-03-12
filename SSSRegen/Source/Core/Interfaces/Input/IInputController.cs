namespace SSSRegen.Source.Core.Interfaces.Input
{
    public interface IInputController
    {
        void Initialize();
        void Update();

        bool IsLeftButtonPressed();
        bool IsLeftButtonHeld();
        bool IsRightButtonPressed();
        bool IsRightButtonHeld();
        bool IsUpButtonPressed();
        bool IsUpButtonHeld();
        bool IsDownButtonPressed();
        bool IsDownButtonHeld();
        bool IsStartButtonPressed();
        bool IsEscapeButtonPressed();
        bool IsFireButtonPressed();
    }
}