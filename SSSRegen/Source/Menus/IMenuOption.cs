using System;
using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Menus
{
    public interface IMenuOption
    {
        Action OptionAction { get; }
        Vector2 MaxSize { get; }
    }
}