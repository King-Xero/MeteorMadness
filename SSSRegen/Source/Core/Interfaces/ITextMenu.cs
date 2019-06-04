using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface ITextMenu
    {
        int SelectedIndex { get; set; }
        //ToDo Create menu item interface
        //Change SetMenuItems signature to take collection of menu item interface
        //Create menu base class that SetsMenuItems, Initializes, Updates, and Draws
        void SetMenuItems(Dictionary<string, Action> items);
        void SelectCurrentItem();
        void Initialize();
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}