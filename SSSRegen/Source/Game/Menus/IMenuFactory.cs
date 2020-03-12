using SSSRegen.Source.Core.Interfaces.Menus;

namespace SSSRegen.Source.Game.Menus
{
    public interface IMenuFactory
    {
        IGameMenu CreateMainMenu();
        IGameMenu CreatePlayStatePauseMenu();
        IGameMenu CreatePlayStateGameOverMenu();
    }
}