using System;
using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces.Menus
{
    public interface IMenuOption
    {
        Action OptionAction { get; }
        Vector2 MaxSize { get; }
    }
}