using System;
using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Menus
{
    public interface IMenuOption
    {
        Action OptionAction { get; }
        int MaxWidth { get; }
        int MaxHeight { get; }
    }
}