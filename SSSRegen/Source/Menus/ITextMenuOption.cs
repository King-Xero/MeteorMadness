using Microsoft.Xna.Framework.Graphics;

namespace SSSRegen.Source.Menus
{
    public interface ITextMenuOption : IMenuOption
    {
        string Text { get; }
        SpriteFont RegularFont { get; }
        SpriteFont SelectedFont { get; }
    }
}