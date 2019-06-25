namespace SSSRegen.Source.Menus
{
    public interface IMenuFactory
    {
        IGameMenu CreateMainMenu();
        IGameMenu CreatePlayStateMenu();
    }
}