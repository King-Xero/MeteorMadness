using SSSRegen.Source.Core.Graphics;

namespace SSSRegen.Source.Core.Interfaces.Menus
{
    public interface ITextMenuOption : IMenuOption
    {
        UIText RegularText { get; }
        UIText SelectedText { get; }
    }
}