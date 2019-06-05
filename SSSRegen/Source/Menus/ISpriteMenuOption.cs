using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Menus
{
    public interface ISpriteMenuOption : IMenuOption
    {
        ISprite RegularSprite { get; }
        ISprite SelectedSprite { get; }
    }
}