using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core;

namespace SSSRegen.Source.Menus
{
    public interface ITextMenuOption : IMenuOption
    {
        UIText RegularText { get; }
        UIText SelectedText { get; }
    }
}