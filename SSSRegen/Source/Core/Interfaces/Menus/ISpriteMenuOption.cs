using SSSRegen.Source.Core.Interfaces.Graphics;

namespace SSSRegen.Source.Core.Interfaces.Menus
{
    public interface ISpriteMenuOption : IMenuOption
    {
        ISprite RegularSprite { get; }
        ISprite SelectedSprite { get; }
    }
}